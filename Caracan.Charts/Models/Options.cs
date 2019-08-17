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
        public int scaleMinSpace { get; set; }
        // Can be set to true or false. If set to true, the scale will be generated with whole numbers only.
        public bool OnlyInteger { get; set; }
        // The reference value can be used to make sure that this value will always be on the chart. This is especially useful on bipolar charts where the bipolar center always needs to be part of the chart.
        public int ReferenceValue { get; set; }

        //OTHER
        public bool fullWidth { get; set; }

        public ChartPadding ChartPadding { get; set; }

        public AxisY AxisY { get; set; }
    }
}
