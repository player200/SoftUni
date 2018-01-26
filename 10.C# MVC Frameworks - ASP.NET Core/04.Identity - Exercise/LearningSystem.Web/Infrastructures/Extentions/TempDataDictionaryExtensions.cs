namespace LearningSystem.Web.Infrastructures.Extentions
{
    using Microsoft.AspNetCore.Mvc.ViewFeatures;

    public static class TempDataDictionaryExtensions
    {
        public static void AddSuccessMessage(this ITempDataDictionary tempData, string message)
        {
            tempData[WebConstants.TempDataSuccessMessageKey] = message;
        }
    }
}