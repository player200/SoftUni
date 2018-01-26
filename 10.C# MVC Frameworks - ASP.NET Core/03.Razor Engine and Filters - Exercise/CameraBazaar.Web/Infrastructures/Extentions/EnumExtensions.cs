namespace CameraBazaar.Web.Infrastructures.Extentions
{
    using CameraBazaar.Data.Models;

    public static class EnumExtensions
    {
        public static string ToDisplayName(this LightMetering lightMetering)
        {
            if (lightMetering == LightMetering.Spot)
            {
                return "Spot";
            }
            else if (lightMetering == LightMetering.CenterWeighted)
            {
                return "Center-Weighted";
            }
            else
            {
                return "Evaluative";
            }
        }
    }
}