using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Data;

namespace CAR_RENTAL_MANAGEMENT_SYSTEM.Helpers
{
    public static class PDFGenerator
    {
        public static void GenerateInvoice(DataRow billRow, string customerName, string filePath)
        {
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(11).FontFamily(Fonts.Arial));

                    page.Header().Element(compose => ComposeHeader(compose, billRow));
                    page.Content().Element(compose => ComposeContent(compose, billRow, customerName));
                    page.Footer().Element(ComposeFooter);
                });
            })
            .GeneratePdf(filePath);
        }

        private static void ComposeHeader(IContainer container, DataRow billRow)
        {
            container.Row(row =>
            {
                row.RelativeItem().Column(column =>
                {
                    column.Item().Text("DriveFlow Invoice").FontSize(20).SemiBold().FontColor(Colors.Blue.Darken2);
                    column.Item().Text("DriveFlow — Professional Car Rental");
                    column.Item().Text("123 Business Road, Dhaka, Bangladesh");
                });

                row.ConstantItem(100).AlignRight().Column(column =>
                {
                    column.Item().Text($"Invoice #{billRow["BillID"]}").FontSize(14).SemiBold();
                    column.Item().Text($"Date: {Convert.ToDateTime(billRow["BillDate"]).ToString("dd MMM yyyy")}");
                });
            });
        }

        private static void ComposeContent(IContainer container, DataRow billRow, string customerName)
        {
            container.PaddingVertical(1, Unit.Centimetre).Column(column =>
            {
                column.Spacing(20);

                column.Item().Text($"Billed To: {customerName}").FontSize(14).SemiBold();

                column.Item().Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn(3);
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                    });

                    table.Header(header =>
                    {
                        header.Cell().Element(HeaderCellStyle).Text("Description");
                        header.Cell().Element(HeaderCellStyle).AlignRight().Text("Rate (BDT)");
                        header.Cell().Element(HeaderCellStyle).AlignRight().Text("Days");
                        header.Cell().Element(HeaderCellStyle).AlignRight().Text("Total");

                        static IContainer HeaderCellStyle(IContainer container)
                        {
                            return container.DefaultTextStyle(x => x.SemiBold()).PaddingVertical(5).BorderBottom(1).BorderColor(Colors.Black);
                        }
                    });

                    table.Cell().Element(DataCellStyle).Text(billRow["CarDetails"].ToString());
                    table.Cell().Element(DataCellStyle).AlignRight().Text(Convert.ToDecimal(billRow["DailyRate"]).ToString("F2"));
                    table.Cell().Element(DataCellStyle).AlignRight().Text(billRow["DaysRented"].ToString());
                    
                    decimal baseTotal = Convert.ToDecimal(billRow["DailyRate"]) * Convert.ToInt32(billRow["DaysRented"]);
                    table.Cell().Element(DataCellStyle).AlignRight().Text(baseTotal.ToString("F2"));

                    static IContainer DataCellStyle(IContainer container)
                    {
                        return container.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).PaddingVertical(5);
                    }
                });

                column.Item().AlignRight().Column(inner =>
                {
                    decimal lateFee = Convert.ToDecimal(billRow["LateFee"]);
                    decimal totalAmount = Convert.ToDecimal(billRow["TotalAmount"]);
                    
                    if (lateFee > 0)
                    {
                        inner.Item().Text($"Late Fee: {lateFee:F2} BDT").FontSize(12).FontColor(Colors.Red.Medium);
                    }
                    inner.Item().Text($"Total Amount: {totalAmount:F2} BDT").FontSize(14).SemiBold();
                    inner.Item().Text($"Payment Status: {billRow["PaymentStatus"]}").FontSize(12).FontColor(billRow["PaymentStatus"].ToString() == "Paid" ? Colors.Green.Medium : Colors.Red.Medium);
                });
            });
        }

        private static void ComposeFooter(IContainer container)
        {
            container.AlignCenter().Text(x =>
            {
                x.Span("Page ");
                x.CurrentPageNumber();
                x.Span(" of ");
                x.TotalPages();
            });
        }
    }
}
