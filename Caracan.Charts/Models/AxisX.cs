namespace Caracan.Charts.Models
{
    public class AxisX
    {
        public bool ShowLabel { get; set; }
        public bool ShowGrid { get; set; }
        public int Offset { get; set; }
        // On the x-axis start means top and end means bottom
        public string Position { get; set; }
    }
}
