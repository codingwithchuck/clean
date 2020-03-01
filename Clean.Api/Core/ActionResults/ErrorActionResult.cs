using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Clean.Api.Core.ActionResults
{
    public class ErrorActionResult : ActionResult
    {
        private readonly ResponseResult _result;
        private readonly JsonSerializerOptions _settings;

        public ErrorActionResult(ResponseResult result, JsonSerializerOptions settings)
        {
            _result = result;
            _settings = settings;
        }

        public override Task ExecuteResultAsync(ActionContext context)
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var services = context.HttpContext.RequestServices;
            var executor = services.GetRequiredService<IActionResultExecutor<JsonResult>>();
            return executor.ExecuteAsync(context, new JsonResult(_result, _settings));
        }
    }
}