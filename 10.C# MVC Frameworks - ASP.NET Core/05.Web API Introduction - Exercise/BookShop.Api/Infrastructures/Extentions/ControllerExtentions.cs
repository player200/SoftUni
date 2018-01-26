namespace BookShop.Api.Infrastructures.Extentions
{
    using Microsoft.AspNetCore.Mvc;

    public static class ControllerExtentions
    {
        public static IActionResult OkOrNotFound(this Controller controller, object model)
        {
            if (model == null)
            {
                return controller.NotFound();
            }

            return controller.Ok(model);
        }
    }
}