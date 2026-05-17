# 🏎️ DriveFlow: Advanced Car Rental Management System

[![Framework](https://img.shields.io/badge/Framework-.NET%2010.0-blue.svg)](https://dotnet.microsoft.com/)
[![Language](https://img.shields.io/badge/Language-C%23-green.svg)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![Database](https://img.shields.io/badge/Database-SQL%20Server-red.svg)](https://www.microsoft.com/en-us/sql-server/)
[![AI](https://img.shields.io/badge/AI-Ollama%20%7C%20Qwen2-purple.svg)](https://ollama.com/)

**DriveFlow** is a premium, enterprise-grade Car Rental Management System (CRMS) designed to automate fleet operations, enhance security through real-time GPS telemetry, and provide data-driven business insights using localized AI models.

---

## 🚀 Core Features

### 🏢 Multi-Role Management
- **Administrator Panel:** Comprehensive oversight of revenue, users, and fleet performance.
- **Fleet Manager Dashboard:** Dedicated tools for booking approvals, maintenance logs, and live tracking.
- **Customer Portal:** Modern interface for car browsing, side-by-side comparisons, and rental history.

### 🛰️ Real-Time GPS & Geofencing
- **Live Telemetry:** High-frequency tracking (500ms) of coordinates and speed (km/h).
- **Interactive Map:** Custom-rendered canvas with visual "Safe Zone" geofencing.
- **Instant Alerts:** Real-time visual warnings for geofence breaches or speeding.

### 🤖 AI-Powered Intelligence
- **Ollama Integration:** Seamless connection to a local AI server for 100% data privacy.
- **Qwen2:0.5b Model:** Ultra-low latency natural language processing.
- **Intelligent Assistant:** Natural language car suggestions based on user requirements.
- **Business Insights:** Automated analysis of fleet utilization and growth strategies.

### 💰 Automated Financials
- **Dynamic Billing:** Real-time cost calculation based on duration and late fees.
- **Pro Invoicing:** Professional PDF generation using the industrial-standard QuestPDF engine.
- **Visual Analytics:** Interactive revenue and fleet distribution charts.

---

## 🛠 Technology Stack

- **Frontend:** C# WinForms (Modern Dark Theme)
- **Backend:** 3-Tier Architecture (UI, BLL, DAL)
- **Database:** Microsoft SQL Server (ACID Compliant)
- **Reporting:** LiveChartsCore (Analytics) & QuestPDF (Invoicing)
- **AI Engine:** Ollama API with Qwen2:0.5b LLM
- **Security:** BCrypt Password Hashing & RBAC

---

## ⚙️ Installation & Setup

### Prerequisites
- Visual Studio 2022 or newer
- .NET 10.0 SDK
- Microsoft SQL Server (Express or Developer)
- [Ollama](https://ollama.com/) (For AI features)

### 1. Database Setup
1. Open **SQL Server Management Studio (SSMS)**.
2. Run the provided [setup.sql](Database/setup.sql) script to initialize the `CarRentingDB` database.
3. Verify the connection string in `DAL/DBConnection.cs`:
   ```csharp
   private static readonly string connectionString = "Server=localhost\\SQLEXPRESS;Database=CarRentingDB;Integrated Security=True;TrustServerCertificate=True;";
   ```

### 2. AI Model Setup (Optional)
To enable the AI features:
1. Install Ollama.
2. Run the following command in your terminal:
   ```bash
   ollama run qwen2:0.5b
   ```

### 3. Build & Run
```bash
dotnet build
dotnet run
```

---

## 🔑 Default Credentials

| Role | Username | Password |
| :--- | :--- | :--- |
| **Administrator** | `admin` | `Admin@123` |
| **Fleet Manager** | `manager` | `Manager@123` |
| **Customer** | `john_doe` | `Customer@123` |

---

## 📂 Documentation
For a detailed look at the project's vision and full feature list, please refer to:
- [Project Description](projectdescription.md) - Professional introduction and case study.
- [Full Features List](full_features_list.md) - Exhaustive technical and functional capabilities.

---

## 🛡️ License
Distributed under the MIT License. See `LICENSE` for more information.

## ✉️ Contact
**DriveFlow Support Team** - [support@driveflow.com](mailto:support@driveflow.com)

---
*DriveFlow: Precision, Performance, and Intelligence for the Modern Fleet.*
