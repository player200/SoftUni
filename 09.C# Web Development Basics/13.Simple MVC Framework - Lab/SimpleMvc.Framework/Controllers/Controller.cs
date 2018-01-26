namespace SimpleMvc.Framework.Controllers
{
    using SimpleMvc.Framework.Contracts;
    using SimpleMvc.Framework.Contracts.Generic;
    using SimpleMvc.Framework.Helper;
    using SimpleMvc.Framework.ViewEngine;
    using SimpleMvc.Framework.ViewEngine.Generic;
    using System.Runtime.CompilerServices;

    public abstract class Controller
    {
        protected IActionResult View([CallerMemberName] string caller = "")
        {
            var controllerName = ControllerHelpers.GetControllerName(this);

            var fullQualifiedName = ControllerHelpers.GetViewFullQualifiedName(controllerName, caller);

            return new ActionResult(fullQualifiedName);
        }

        protected IActionResult View(string controller, string action)
        {
            var fullQualifiedName = ControllerHelpers.GetViewFullQualifiedName(controller, action);

            return new ActionResult(fullQualifiedName);
        }

        protected IActionResult<T> View<T>(T model, [CallerMemberName] string caller = "")
        {
            var controllerName = ControllerHelpers.GetControllerName(this);

            var fullQualifiedName = ControllerHelpers.GetViewFullQualifiedName(controllerName, caller);

            return new ActionResult<T>(fullQualifiedName, model);
        }

        protected IActionResult<T> View<T>(T model, string controller, string action)
        {
            var fullQualifiedName = ControllerHelpers.GetViewFullQualifiedName(controller, action);

            return new ActionResult<T>(fullQualifiedName, model);
        }
    }
}
