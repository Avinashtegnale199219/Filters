using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FilterProject.NewFolder
{
    public class CustomAuthorizationFilterAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // Your custom authorization logic here
            if (!IsAuthorized(context.HttpContext.User))
            {
                // If not authenticated, redirect to the login page
                context.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    { "controller", "Home" },   // Change "Home" to your login controller name
                    { "action", "Login" }       // Change "Login" to your login action method name
                });
            }
            //else
            //{
            //    // If authenticated, redirect to the controller method
            //    context.Result = new RedirectToRouteResult(new RouteValueDictionary
            //    {
            //        { "controller", "Home" },   // Change "Home" to your login controller name
            //        { "action", "SecureMethod" }       // Change "Login" to your login action method name
            //    });
            //}
        }
        private bool IsAuthorized(ClaimsPrincipal user)
        {
            // Check if the user is authenticated
            // Implement your custom authorization logic here
            // Check roles, claims, policies, or any other criteria
            // Return true i9f authorized, false if not
            return false; // For demonstration purposes
        }
    }

    public class CustomAsyncAuthorizationFilter : IAsyncAuthorizationFilter
    {
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            // Your asynchronous custom authorization logic here
            bool isAuthorized = await CheckUserAuthorizationAsync(context);
            if (!isAuthorized)
            {
                // If not authenticated, redirect to the login page
                context.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    { "controller", "Home" },   // Change "Account" to your login controller name
                    { "action", "Login1" }       // Change "Login" to your login action method name
                });
            }
        }
        private async Task<bool> CheckUserAuthorizationAsync(AuthorizationFilterContext context)
        {
            // Implement your asynchronous authorization logic here
            // For example, you can check user permissions, roles, etc., using async calls
            await Task.Delay(1000); // Simulate async work, like a database call
            // Return true if authorized, false otherwise
            return false;
        }
    }
}
