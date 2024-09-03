using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;
using System.Data.Common;



QuestPDF.Settings.License= LicenseType.Community;

Document.Create(Container =>
{
    Container.Page(page =>
    {
        page.Size(PageSizes.A4);
        page.Margin(2, Unit.Centimetre);
        page.PageColor(Colors.White);
        page.DefaultTextStyle(x => x.FontSize(20));
        page.Header()
                  .Text("hello from Noa!")
                 .SemiBold().FontSize(30).FontColor(Colors.Black);

        page.Content()
             .PaddingVertical(1, Unit.Centimetre)
             .Column(x =>
             {
                 x.Spacing(20);
                 x.Item().Text(Placeholders.Paragraph());
                 x.Item().Image(Placeholders.Image(200, 100));
                 //x.Item().Table(Placeholders)
                 x.Item().Table(table =>
                 {
                     // Define the columns
                     table.ColumnsDefinition(columns =>
                     {
                         columns.RelativeColumn(); // Adjust columns based on content
                         columns.RelativeColumn();
                         columns.RelativeColumn();
                     });

                     // Add table header
                     table.Header(header =>
                     {
                         header.Cell().Text("Header 1").Bold();
                         header.Cell().Text("Header 2").Bold();
                         header.Cell().Text("Header 3").Bold();
                     });

                     // Add rows
                     table.Cell().Text("Row 1, Cell 1");
                     table.Cell().Text("Row 1, Cell 2");
                     table.Cell().Text("Row 1, Cell 3");

                     table.Cell().Text("Row 2, Cell 1");
                     table.Cell().Text("Row 2, Cell 2");
                     table.Cell().Text("Row 2, Cell 3");

                     // Add more rows as needed
                 });
             });
        page.Footer()
        .AlignCenter()
        .Text(x =>
        {
            x.Span("Page ");
            x.CurrentPageNumber();
        });

    });
})
    .ShowInPreviewer();

