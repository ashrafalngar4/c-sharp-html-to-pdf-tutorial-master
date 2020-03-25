using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using IronPdf;

namespace HtmlToPdfTutorial
{
    public partial class Examples
    {
        public static void HtmlFileToPdfExample()
        {
            // Create a PDF from an existing HTML
            var Renderer = new HtmlToPdf();

            Renderer.PrintOptions.MarginTop = 50;  //millimeters
            Renderer.PrintOptions.MarginBottom = 50;
            Renderer.PrintOptions.CssMediaType = PdfPrintOptions.PdfCssMediaType.Print;

            Renderer.PrintOptions.Header = new SimpleHeaderFooter()
            {
                CenterText = "{pdf-title}",
                DrawDividerLine = true,
                FontSize = 16
            };

            Renderer.PrintOptions.Footer = new SimpleHeaderFooter()
            {
                LeftText = "{date} {time}",
                RightText = "Page {page} of {total-pages}",
                DrawDividerLine = true,
                FontSize = 14
            };
            var GetDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var x = GetDirectory.Replace("bin\\Debug","");
            var PDF = Renderer.RenderHTMLFileAsPdf($"{x}Assets\\TestInvoice1.html");
            var OutputPath = "Invoice.pdf";
            PDF.SaveAs(OutputPath);

            // This neat trick opens our PDF file so we can see the result
            System.Diagnostics.Process.Start(OutputPath);
        }
    }
}
