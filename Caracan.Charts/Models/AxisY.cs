namespace Caracan.Charts.Models
{
    public class AxisY
    {
        public bool OnlyInteger { get; set; }
        public int Offset { get; set; }
        // On the y-axis start means left and end means right
        public string Position { get; set; }
    }
}
