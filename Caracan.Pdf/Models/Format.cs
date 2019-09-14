namespace Caracan.Pdf.Models
{
    public class Format
    {
        public FormatType Type { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
    }

    public enum FormatType
    {
        None,
        A0,
        A1,
        A2,
        A3,
        A4,
        A5,
        A6,
        Letter,
        Legal,
        Tabloid,
        Ledger
    }
}
