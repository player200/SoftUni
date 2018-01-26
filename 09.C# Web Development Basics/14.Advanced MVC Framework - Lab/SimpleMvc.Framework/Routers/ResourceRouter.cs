﻿namespace SimpleMvc.Framework.Routers
{
    using System;
    using System.IO;
    using System.Linq;
    using WebServer.Contracts;
    using WebServer.Enums;
    using WebServer.Http.Contracts;
    using WebServer.Http.Response;

    public class ResourceRouter : IHandleable
    {
        public IHttpResponse Handle(IHttpRequest request)
        {
            string fileFullName = request.Path.Split(new[] { '/' }).Last();
            string fileExtension = request.Path.Split(new[] { '.' }).Last();

            IHttpResponse fileReponse = null;

            try
            {
                var fileContent = this.ReadFileContent(fileFullName, fileExtension);
                fileReponse = new FileResponse(HttpStatusCode.Found, fileContent);
            }
            catch (Exception)
            {
                return new NotFoundResponse();
            }

            return fileReponse;
        }

        private byte[] ReadFileContent(string fileFullName, string fileExtension)
        {
            var byteContent = File.ReadAllBytes(string.Format(
                "{0}\\{1}\\{2}",
                MvcContext.Get.ResourcesFolder,
                fileExtension,
                fileFullName));

            return byteContent;
        }
    }
}