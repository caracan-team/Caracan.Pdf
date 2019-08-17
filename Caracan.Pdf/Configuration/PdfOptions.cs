using System;

namespace Caracan.Pdf.Configuration
{
    public class PdfOptions
    {
        public Decimal Scale { get; set; } = Decimal.One;
        public bool DisplayHeaderFooter { get; set; }
        public string HeaderTemplate { get; set; } = string.Empty;
        public string FooterTemplate { get; set; } = string.Empty;
        public bool PrintBackground { get; set; }
        public bool Landscape { get; set; }
        public string PageRanges { get; set; } = string.Empty;
        //public PaperFormat Format { get; set; }
        public object Width { get; set; }
        public object Height { get; set; }
        //public MarginOptions MarginOptions { get; set; } = new MarginOptions();
        public bool PreferCSSPageSize { get; set; }
    }
}
