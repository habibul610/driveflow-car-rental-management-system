using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace CAR_RENTAL_MANAGEMENT_SYSTEM.Helpers
{
    /// <summary>
    /// A message in a multi-turn conversation history.
    /// Role is "system", "user", or "assistant".
    /// </summary>
    public record ChatMessage(string Role, string Content);

    /// <summary>
    /// Thin async wrapper around the Ollama REST API.
    /// Supports single-turn and multi-turn (chat history) streaming.
    /// Model: qwen2.5:0.5b  |  Endpoint: http://localhost:11434
    /// </summary>
    public static class OllamaService
    {
        private const string BaseUrl = "http://localhost:11434";
        private const string Model   = "qwen2.5:0.5b";

        // One HttpClient per app lifetime (best practice)
        private static readonly HttpClient _http = new HttpClient { Timeout = TimeSpan.FromSeconds(180) };

        // ── Core internal streaming engine ──────────────────────────────────────

        private static async Task StreamMessagesAsync(
            object[] messages,
            Action<string> onToken,
            CancellationToken ct)
        {
            var body = new { model = Model, stream = true, messages };
            string json = JsonSerializer.Serialize(body);

            using var content = new StringContent(json, Encoding.UTF8, "application/json");
            using var request = new HttpRequestMessage(HttpMethod.Post, $"{BaseUrl}/api/chat")
            {
                Content = content
            };

            using var response = await _http.SendAsync(
                request, HttpCompletionOption.ResponseHeadersRead, ct);
            response.EnsureSuccessStatusCode();

            using var stream = await response.Content.ReadAsStreamAsync(ct);
            using var reader = new System.IO.StreamReader(stream);

            while (!reader.EndOfStream)
            {
                ct.ThrowIfCancellationRequested();
                string? line = await reader.ReadLineAsync();
                if (string.IsNullOrWhiteSpace(line)) continue;

                try
                {
                    using var doc = JsonDocument.Parse(line);
                    var root = doc.RootElement;

                    if (root.TryGetProperty("message", out var msg) &&
                        msg.TryGetProperty("content", out var tokenProp))
                    {
                        string token = tokenProp.GetString() ?? "";
                        if (!string.IsNullOrEmpty(token)) onToken(token);
                    }

                    if (root.TryGetProperty("done", out var done) && done.GetBoolean())
                        break;
                }
                catch (JsonException) { /* skip malformed line */ }
            }
        }

        // ── Public API ───────────────────────────────────────────────────────────

        /// <summary>
        /// Single-turn: system prompt + one user message, streamed token-by-token.
        /// </summary>
        public static Task StreamAsync(
            string systemPrompt,
            string userMessage,
            Action<string> onToken,
            CancellationToken cancellationToken = default)
        {
            var messages = new object[]
            {
                new { role = "system", content = systemPrompt },
                new { role = "user",   content = userMessage  }
            };
            return StreamMessagesAsync(messages, onToken, cancellationToken);
        }

        /// <summary>
        /// Multi-turn chat: sends the complete conversation history.
        /// Caller maintains and grows the history list between calls.
        /// </summary>
        public static Task StreamChatAsync(
            IReadOnlyList<ChatMessage> history,
            Action<string> onToken,
            CancellationToken cancellationToken = default)
        {
            var messages = history
                .Select(m => (object)new { role = m.Role, content = m.Content })
                .ToArray();
            return StreamMessagesAsync(messages, onToken, cancellationToken);
        }

        /// <summary>
        /// Non-streaming single-turn: returns the complete response as a string.
        /// </summary>
        public static async Task<string> AskAsync(
            string systemPrompt,
            string userMessage,
            CancellationToken cancellationToken = default)
        {
            var sb = new StringBuilder();
            await StreamAsync(systemPrompt, userMessage, t => sb.Append(t), cancellationToken);
            return sb.ToString();
        }

        /// <summary>
        /// Returns true if Ollama is reachable at localhost:11434.
        /// </summary>
        public static async Task<bool> IsAvailableAsync()
        {
            try
            {
                var resp = await _http.GetAsync($"{BaseUrl}/api/tags",
                    new CancellationTokenSource(TimeSpan.FromSeconds(4)).Token);
                return resp.IsSuccessStatusCode;
            }
            catch { return false; }
        }
    }
}
