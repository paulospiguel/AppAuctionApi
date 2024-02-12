using System.Buffers.Text;
using AppAuction.API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AppAuction.API.Filters
{
    public class AuthenticationUserAttribuite : AuthorizeAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                var token = GetTokenFromHeader(context.HttpContext);

                var repository = new AppAuctionDbContext();

                var email = GetEmailFromRToken(token);

                var exist = repository.Users.Any(user => user.Email.Equals(email));

                if (!exist)
                {
                    context.Result = new UnauthorizedObjectResult("User not found");
                }
            }
            catch (Exception e)
            {
                context.Result = new UnauthorizedObjectResult(e.Message);
            }

        }

        private string GetTokenFromHeader(HttpContext context)
        {
            var authentication = context.Request.Headers.Authorization.ToString();

            if (string.IsNullOrEmpty(authentication))
            {
                throw new Exception("Token not found");
            }

            return authentication.Replace("Bearer ", "");
        }

        private string GetEmailFromRToken(string base64)
        {
            var data = Convert.FromBase64String(base64);

            return System.Text.Encoding.UTF8.GetString(data);
        }
    }
}