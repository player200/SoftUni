namespace SimpleMvc.Framework.Attributes.Property
{
    public class NumberRangeAttribute : PropertyAttribute
    {
        private readonly double minValue;
        private readonly double maxValue;

        public NumberRangeAttribute(double minValue, double maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override bool IsValid(object value)
        {
            return this.minValue <= (double)value && this.maxValue >= (double)value;
        }
    }
}