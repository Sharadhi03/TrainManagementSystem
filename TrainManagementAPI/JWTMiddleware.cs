using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace TrainManagementAPI
{
    public class JWTMiddleware
    {
        private readonly RequestDelegate _next;
        public JWTMiddleware(RequestDelegate requestDelegate)
        {
            _next = requestDelegate;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path == "/api/login" && context.Request.Method == "POST")
            {
                await _next(context);
                return;
            }
            var authHeader = context.Request.Headers.Authorization;
            if (authHeader.Count() > 0 && authHeader.FirstOrDefault().StartsWith("Bearer "))
            {
                var token = authHeader.FirstOrDefault().Substring("Bearer ".Length);
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("!@#$%^&*()!@#$%^&*()");
                try
                {
                    var tokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ClockSkew = TimeSpan.Zero
                    };
                    var claims = tokenHandler.ValidateToken(token, tokenValidationParameters, out var validatedToken);
                    context.User = claims;
                }
                catch
                {
                    context.Response.StatusCode = 401;
                    return;
                }
                _next(context);
            }
        }
    }
}
