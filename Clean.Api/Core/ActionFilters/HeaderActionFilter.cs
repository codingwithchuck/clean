using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Clean.Api.Core.ActionFilters
{
    public class HeaderSecretAttribute: ActionFilterAttribute
    {
        private readonly string _key;
        private readonly string _secret;

        public HeaderSecretAttribute(string key, string secret)
        {
            _key = key;
            _secret = secret;
        }
        
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var hasKey = context.HttpContext.Request.Headers.Any(s => s.Key == _key);

            if (hasKey)
            {
               var header = context.HttpContext.Request.Headers.Single(s => s.Key == _key);

               if (header.Value.First() != _secret)
               {
                   throw new Exception("Unauthorized Access");
               }
            }
            else
            {
                throw new Exception("Unauthorized Access");
            }
        }
    }
    

}