namespace TrainManagementAPI
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _nextMiddleware;
        public CustomMiddleware(RequestDelegate nextMiddleware)
        {
            _nextMiddleware = nextMiddleware;
        }
        public async  Task InvokeAsync(HttpContext context)
        {
            if(context.Request.Path=="ap/Train")
            {
                context.Response.StatusCode = 500;
                return;
            }
            await _nextMiddleware(context);
        }

    };
}
