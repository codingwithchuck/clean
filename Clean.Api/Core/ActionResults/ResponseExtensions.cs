using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using Clean.Common.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace Clean.Api.Core.ActionResults
{
    public static class ResponseExtensions
    {
        private static readonly string AssemblyVersion = GetVersion();

        private static JsonSerializerOptions SerializerSettings => new JsonSerializerOptions
        {
            IgnoreNullValues = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public static async Task<IActionResult> Response<T>(this Task<T> response) where T : class
        {
            var handlerResponse = await response;
            return Response(handlerResponse);
        }

        public static IActionResult Response<T>(this T handlerResponse) where T : class
        {
            var payload = CreateResponsePayload(handlerResponse);
            return payload.HasErrors() ? new ErrorActionResult(payload, SerializerSettings) : GetJsonActionResult(payload);
        }

        private static ResponseResult CreateResponsePayload<T>(T model) where T : class
        {
            var vm = new ResponseResult {Model = model, Version = AssemblyVersion};

            //Merge the notifications on the Model and the passed in notifications
            if (model is INotificationCollection notifications)
            {
                vm.Dispatches = notifications.Notifications;
            }

            return vm;
        }

        private static string GetVersion()
        {
            var assembly = Assembly.GetExecutingAssembly().GetName();
            var version = assembly.Version;

            return version is null ? string.Empty : version.ToString();
        }

        private static IActionResult GetJsonActionResult(ResponseResult payload)
        {
            var response = new JsonResult(payload, SerializerSettings);
            return response;
        }
    }
}