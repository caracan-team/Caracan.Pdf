
namespace Caracan.Pdf.Configuration
{
    public class PdfOptions
    {
        public object Height { get; set; }
        public object Width { get; set; }

       // public PaperFormat Format { get; set; }
       
        public string PageRanges { get; set; }
        public bool Landscape { get; set; }
        public bool PrintBackground { get; set; }
        public string FooterTemplate { get; set; }
        public string HeaderTemplate { get; set; }
        public bool DisplayHeaderFooter { get; set; }
        public decimal Scale { get; set; }
        //public MarginOptions MarginOptions { get; set; }
        public bool PreferCSSPageSize { get; set; }
    }
}
