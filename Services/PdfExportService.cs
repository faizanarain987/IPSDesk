using IPSDesk.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace IPSDesk.Services;

public class PdfExportService
{
    public byte[] GeneratePackageHistoryReport(Customer customer, List<MonthlyPackageHistory> history, DateTime startDate, DateTime endDate)
    {
        var document = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4.Landscape());
                page.Margin(1, Unit.Centimetre);
                page.PageColor(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(10).FontFamily(Fonts.Arial));

                page.Header().Element(x => ComposeHeader(x, customer, startDate, endDate));
                page.Content().Element(x => ComposeContent(x, history));
                page.Footer().Element(ComposeFooter);
            });
        });

        return document.GeneratePdf();
    }

    private void ComposeHeader(IContainer container, Customer customer, DateTime startDate, DateTime endDate)
    {
        container.Row(row =>
        {
            row.RelativeItem().Column(column =>
            {
                column.Item().Text("DIAMOND NET").FontSize(24).SemiBold().FontColor(Colors.Blue.Darken2);
                column.Item().Text("Monthly Package History Report").FontSize(14).FontColor(Colors.Grey.Medium);
                column.Item().PaddingTop(4).Text(text =>
                {
                    text.Span("Report Period: ").SemiBold();
                    text.Span($"{startDate:MMM dd, yyyy} - {endDate:MMM dd, yyyy}");
                });
            });

            row.ConstantItem(200).AlignRight().Column(column =>
            {
                column.Item().Text(customer.Name).FontSize(14).SemiBold();
                column.Item().Text($"ID: {customer.ConnectionId}").FontColor(Colors.Grey.Medium);
                column.Item().Text(customer.Phone).FontColor(Colors.Grey.Medium);
            });
        });
    }

    private void ComposeContent(IContainer container, List<MonthlyPackageHistory> history)
    {
        container.PaddingVertical(1, Unit.Centimetre).Column(column =>
        {
            column.Spacing(5);
            column.Item().Element(x => ComposeTable(x, history));

            if (!history.Any())
            {
                column.Item().PaddingTop(20).AlignCenter().Text("No package history found for the selected date range.").FontColor(Colors.Grey.Medium).Italic();
            }
        });
    }

    private void ComposeTable(IContainer container, List<MonthlyPackageHistory> history)
    {
        container.Table(table =>
        {
            table.ColumnsDefinition(columns =>
            {
                columns.ConstantColumn(30); // #
                columns.RelativeColumn(2);  // Package
                columns.RelativeColumn(2);  // Package Amount
                columns.RelativeColumn(2);  // Discount
                columns.RelativeColumn(2);  // Amount Paid
                columns.RelativeColumn(2);  // Date
                columns.RelativeColumn(1);  // Status
                columns.RelativeColumn(5);  // Comment
            });

            table.Header(header =>
            {
                header.Cell().Element(CellStyle).Text("#");
                header.Cell().Element(CellStyle).Text("Package");
                header.Cell().Element(CellStyle).AlignRight().Text("Package Amount");
                header.Cell().Element(CellStyle).AlignRight().Text("Discount");
                header.Cell().Element(CellStyle).AlignRight().Text("Amount");
                header.Cell().Element(CellStyle).Text("Date of Renew");
                header.Cell().Element(CellStyle).Text("Status");
                header.Cell().Element(CellStyle).Text("Comment");

                static IContainer CellStyle(IContainer container)
                {
                    return container.DefaultTextStyle(x => x.SemiBold()).PaddingVertical(5).PaddingHorizontal(5).BorderBottom(1).BorderColor(Colors.Black);
                }
            });

            int index = 1;
            foreach (var item in history)
            {
                var rowColor = index % 2 == 0 ? Colors.Grey.Lighten4 : Colors.White;
                var netAmount = item.PackagePrice - item.Discount;
                string displayStatus = item.Status;
                var statusColor = Colors.Green.Medium;
                if (item.Status == "Reversed")
                {
                    statusColor = Colors.Red.Medium;
                }
                else if (item.RenewalDate.AddMonths(1).Date < DateTime.Now.Date)
                {
                    displayStatus = "Expired";
                    statusColor = Colors.Orange.Medium;
                }

                table.Cell().Element(c => CellStyle(c, rowColor)).Text(index.ToString());
                table.Cell().Element(c => CellStyle(c, rowColor)).Text(item.Package?.Name ?? "N/A");
                table.Cell().Element(c => CellStyle(c, rowColor)).AlignRight().Text($"Rs. {item.PackagePrice:N0}");
                table.Cell().Element(c => CellStyle(c, rowColor)).AlignRight().Text($"Rs. {item.Discount:N0}");
                table.Cell().Element(c => CellStyle(c, rowColor)).AlignRight().PaddingRight(5).Text($"Rs. {netAmount:N0}");
                table.Cell().Element(c => CellStyle(c, rowColor)).Text(item.RenewalDate.ToString("MMM dd, yyyy"));
                table.Cell().Element(c => CellStyle(c, rowColor)).Text(displayStatus).FontColor(statusColor).SemiBold();
                
                string commentDisplay = string.IsNullOrEmpty(item.Comment) ? "-" : $"[Updated at {(item.UpdatedAt ?? item.CreatedAt):MMM dd, yyyy hh:mm tt}] {item.Comment}";
                table.Cell().Element(c => CellStyle(c, rowColor)).Text(commentDisplay).FontSize(8).FontColor(Colors.Grey.Darken2);

                index++;
            }

            static IContainer CellStyle(IContainer container, string backgroundColor)
            {
                return container.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Background(backgroundColor).PaddingVertical(5).PaddingHorizontal(5);
            }
        });
    }

    public byte[] GenerateLedgerReport(Customer customer, List<CustomerLedger> ledgers, DateTime startDate, DateTime endDate)
    {
        var document = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4.Landscape());
                page.Margin(1, Unit.Centimetre);
                page.PageColor(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(10).FontFamily(Fonts.Arial));

                page.Header().Element(x => ComposeLedgerHeader(x, customer, startDate, endDate));
                page.Content().Element(x => ComposeLedgerContent(x, ledgers));
                page.Footer().Element(ComposeFooter);
            });
        });

        return document.GeneratePdf();
    }

    private void ComposeLedgerHeader(IContainer container, Customer customer, DateTime startDate, DateTime endDate)
    {
        container.Row(row =>
        {
            row.RelativeItem().Column(column =>
            {
                column.Item().Text("DIAMOND NET").FontSize(24).SemiBold().FontColor(Colors.Blue.Darken2);
                column.Item().Text("Account Ledger Report").FontSize(14).FontColor(Colors.Grey.Medium);
                column.Item().PaddingTop(4).Text(text =>
                {
                    text.Span("Report Period: ").SemiBold();
                    text.Span($"{startDate:MMM dd, yyyy} - {endDate:MMM dd, yyyy}");
                });
            });

            row.ConstantItem(200).AlignRight().Column(column =>
            {
                column.Item().Text(customer.Name).FontSize(14).SemiBold();
                column.Item().Text($"ID: {customer.ConnectionId}").FontColor(Colors.Grey.Medium);
                column.Item().Text(customer.Phone).FontColor(Colors.Grey.Medium);
            });
        });
    }

    private void ComposeLedgerContent(IContainer container, List<CustomerLedger> ledgers)
    {
        container.PaddingVertical(1, Unit.Centimetre).Column(column =>
        {
            column.Spacing(5);
            column.Item().Element(x => ComposeLedgerTable(x, ledgers));

            if (!ledgers.Any())
            {
                column.Item().PaddingTop(20).AlignCenter().Text("No ledger history found for the selected date range.").FontColor(Colors.Grey.Medium).Italic();
            }
        });
    }

    private void ComposeLedgerTable(IContainer container, List<CustomerLedger> ledgers)
    {
        container.Table(table =>
        {
            table.ColumnsDefinition(columns =>
            {
                columns.ConstantColumn(30); // #
                columns.RelativeColumn(3);  // Date
                columns.RelativeColumn(6);  // Description
                columns.RelativeColumn(2);  // Debit
                columns.RelativeColumn(2);  // Credit
                columns.RelativeColumn(2);  // Balance
            });

            table.Header(header =>
            {
                header.Cell().Element(CellStyle).Text("#");
                header.Cell().Element(CellStyle).Text("Date");
                header.Cell().Element(CellStyle).Text("Description");
                header.Cell().Element(CellStyle).AlignRight().Text("Debit (Dr)");
                header.Cell().Element(CellStyle).AlignRight().Text("Credit (Cr)");
                header.Cell().Element(CellStyle).AlignRight().Text("Balance");

                static IContainer CellStyle(IContainer container)
                {
                    return container.DefaultTextStyle(x => x.SemiBold()).PaddingVertical(5).PaddingHorizontal(5).BorderBottom(1).BorderColor(Colors.Black);
                }
            });

            int index = 1;
            foreach (var item in ledgers)
            {
                var rowColor = index % 2 == 0 ? Colors.Grey.Lighten4 : Colors.White;

                table.Cell().Element(c => CellStyle(c, rowColor)).Text(index.ToString());
                table.Cell().Element(c => CellStyle(c, rowColor)).Text(item.TransactionDate.ToString("MMM dd, yyyy hh:mm tt"));
                table.Cell().Element(c => CellStyle(c, rowColor)).Text(item.Description);
                
                var debitText = item.Debit > 0 ? $"Rs. {item.Debit:N0}" : "-";
                table.Cell().Element(c => CellStyle(c, rowColor)).AlignRight().PaddingRight(5).Text(debitText).FontColor(Colors.Red.Medium);
                
                var creditText = item.Credit > 0 ? $"Rs. {item.Credit:N0}" : "-";
                table.Cell().Element(c => CellStyle(c, rowColor)).AlignRight().PaddingRight(5).Text(creditText).FontColor(Colors.Green.Medium);
                
                table.Cell().Element(c => CellStyle(c, rowColor)).AlignRight().PaddingRight(5).Text($"Rs. {item.Balance:N0}").SemiBold();

                index++;
            }

            static IContainer CellStyle(IContainer container, string backgroundColor)
            {
                return container.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Background(backgroundColor).PaddingVertical(5).PaddingHorizontal(5);
            }
        });
    }

    private void ComposeFooter(IContainer container)
    {
        container.AlignCenter().Text(x =>
        {
            x.Span("Page ");
            x.CurrentPageNumber();
            x.Span(" of ");
            x.TotalPages();
            x.Span($" | Generated on {DateTime.Now:MMM dd, yyyy hh:mm tt}").FontColor(Colors.Grey.Medium);
        });
    }
}
