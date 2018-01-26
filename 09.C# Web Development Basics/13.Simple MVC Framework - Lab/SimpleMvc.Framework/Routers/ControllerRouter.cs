namespace SimpleMvc.Framework.Routers
{
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Contracts;
    using SimpleMvc.Framework.Controllers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using WebServer.Contracts;
    using WebServer.Enums;
    using WebServer.Http.Contracts;
    using WebServer.Http.Response;

    public class ControllerRouter : IHandleable
    {
        private const int ControllerAndActionUrlLength = 3;
        private IDictionary<string, string> getParams;
        private IDictionary<string, string> postParams;
        private string requestMethod;
        private string controllerName;
        private string actionName;
        private object[] methodParams;

        public IHttpResponse Handle(IHttpRequest request)
        {
            this.getParams = new Dictionary<string, string>(request.UrlParameters);
            
            this.postParams = new Dictionary<string, string>(request.FormData);

            this.requestMethod = request.Method.ToString().ToUpper();
            
            this.PrepareControllerAndActionNames(request);

            var method = this.GetMethod();

            if (method == null)
            {
                return new NotFoundResponse();
            }

            IEnumerable<ParameterInfo> parameters = method.GetParameters();

            this.methodParams = new object[parameters.Count()];
            var index = 0;

            foreach (var param in parameters)
            {
                if (param.ParameterType.IsPrimitive ||
                    param.ParameterType == typeof(string))
                {
                    var value = this.getParams[param.Name];

                    this.methodParams[index] = Convert.ChangeType(
                        value,
                        param.ParameterType);
                    index++;
                }
                else
                {
                    var bindingModelType = param.ParameterType;
                    var bindingModel = Activator.CreateInstance(bindingModelType);
                    var properties = bindingModelType.GetProperties();

                    foreach (var property in properties)
                    {
                        property.SetValue(
                            bindingModel,
                            Convert.ChangeType(
                                this.postParams[property.Name],
                                property.PropertyType)
                        );
                    }

                    this.methodParams[index] = Convert.ChangeType(
                        bindingModel,
                        bindingModelType);
                    index++;
                }
            }

            var actionResult = (IInvocable)this.GetMethod()
                .Invoke(this.GetController(), this.methodParams);

            var content = actionResult.Invoke();

            var response = new ContentResponse(HttpStatusCode.Ok, content);

            return response;
        }

        private void PrepareControllerAndActionNames(IHttpRequest request)
        {
            var url = request.Path;

            if (url.Contains("/"))
            {
                var parts = url.Split(new[] { '/' });

                if (parts.Length == ControllerAndActionUrlLength)
                { 
                    var controllerName = parts[1];
                    var actionName = parts[2];

                    var controller = controllerName.First().ToString().ToUpper()
                                     + controllerName.Substring(1)
                                     + "Controller";

                    var actionSubstring = actionName.Substring(1);

                    if (actionName.Contains("?"))
                    {
                        actionSubstring =
                            actionName.Substring(1, actionName.IndexOf("?", StringComparison.Ordinal) - 1);
                    }

                    var action = actionName.First().ToString().ToUpper()
                                 + actionSubstring;

                    this.controllerName = controller;
                    this.actionName = action;
                }
            }
        }

        private MethodInfo GetMethod()
        {
            foreach (var methodInfo in this.GetSuitableMethods())
            {
                var attributes =
                    methodInfo.GetCustomAttributes().Where(a => a is HttpMethodAttribute);

                if (!attributes.Any() && this.requestMethod == "GET")
                {
                    return methodInfo;
                }

                foreach (HttpMethodAttribute attribute in attributes)
                {
                    if (attribute.IsValid(this.requestMethod))
                    {
                        return methodInfo;
                    }
                }
            }

            return null;
        }

        private IEnumerable<MethodInfo> GetSuitableMethods()
        {
            var controller = this.GetController();

            if (controller == null)
            {
                return new MethodInfo[0];
            }

            return
                this.GetController()
                    .GetType()
                    .GetMethods()
                    .Where(m => m.Name == this.actionName);
        }

        private Controller GetController()
        {
            var controllerFullQualifiedName = string.Format(
                "{0}.{1}.{2}, {0}",
                MvcContext.Get.AssemblyName,
                MvcContext.Get.ControllersFolder,
                this.controllerName);

            var type = Type.GetType(controllerFullQualifiedName);

            if (type == null)
            {
                return null;
            }

            var controller = (Controller)Activator.CreateInstance(type);

            return controller;
        }
    }
}