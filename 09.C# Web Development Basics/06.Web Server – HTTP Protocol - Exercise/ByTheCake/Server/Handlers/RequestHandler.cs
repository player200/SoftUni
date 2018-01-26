namespace ByTheCake.Server.Handlers
{
    using ByTheCake.Server.Handlers.Contracts;
    using ByTheCake.Server.Http;
    using ByTheCake.Server.Http.Contracts;
    using System;

    public class RequestHandler : IRequestHandler
    {
        private readonly Func<IHttpRequest, IHttpResponse> handlingFunc;

        public RequestHandler(Func<IHttpRequest, IHttpResponse> handlingFunc)
        {
            this.handlingFunc = handlingFunc;
        }

        public IHttpResponse Handle(IHttpContext context)
        {
            var response = this.handlingFunc(context.Request);
            
            if (!response.Headers.ContainsKey(HttpHeader.ContentType))
            {
                response.Headers.Add(HttpHeader.ContentType, "text/plain");
            }
            
            return response;
        }
    }
}