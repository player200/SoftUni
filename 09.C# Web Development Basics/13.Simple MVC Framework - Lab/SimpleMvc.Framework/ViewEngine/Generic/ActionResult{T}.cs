namespace SimpleMvc.Framework.ViewEngine.Generic
{
    using SimpleMvc.Framework.Contracts.Generic;
    using System;

    public class ActionResult<T> : IActionResult<T>
    {
        public ActionResult(string viewFullQualifiedName, T model)
        {
            this.Action = (IRenderable<T>)Activator
                .CreateInstance(Type.GetType(viewFullQualifiedName));
            this.Action.Model = model;
        }

        public IRenderable<T> Action { get; set; }

        public string Invoke()
        {
            return this.Action.Render();
        }
    }
}