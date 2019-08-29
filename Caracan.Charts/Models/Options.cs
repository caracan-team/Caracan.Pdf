namespace Caracan.Charts.Models
{
    public class Options
    {
        //CHARTIST.AUTOSCALEAXIS

        // If high is specified then the axis will display values explicitly up to this value and the computed maximum from the data is ignored
        public int High { get; set; }
        // If low is specified then the axis will display values explicitly down to this value and the computed minimum from the data is ignored
        public int Low { get; set; }
        // This option will be used when finding the right scale division settings. The amount of ticks on the scale will be determined so that as many ticks as possible will be displayed, while not violating this minimum required space (in pixel).
        public int ScaleMinSpace { get; set; }
        // Can be set to true or false. If set to true, the scale will be generated with whole numbers only.
        public bool OnlyInteger { get; set; }
        // The reference value can be used to make sure that this value will always be on the chart. This is especially useful on bipolar charts where the bipolar center always needs to be part of the chart.
        public int ReferenceValue { get; set; }

        //OTHER
        public bool FullWidth { get; set; }

        public ChartPadding ChartPadding { get; set; }

        public AxisY AxisY { get; set; }

        public bool ShowArea { get; set; }

        public bool ShowLine { get; set; }

        public bool ShowPoint { get; set; }

        public AxisX AxisX { get; set; }

        public int SeriesBarDistance { get; set; }

        public bool StackBars { get; set; }

        public bool ReverseData { get; set; }

        public bool HorizontalBars { get; set; }

        public bool DistributeSeries { get; set; }

        public bool Donut { get; set; }

        public int DonutWidth { get; set; }
        
        public int StartAngle { get; set; }

        public int Total { get; set; }

        public bool ShowLabel { get; set; }

        public bool DonutSolid { get; set; }
    }
}
