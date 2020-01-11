using Microsoft.AspNetCore.Mvc;

namespace Clean.Api.Controllers.Users
{
    public class UsersSuspendedController : ControllerBase
    {
        /// <summary>
        /// Get all the suspended Users
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/users/status/suspended")]
        public IActionResult Get()
        {
            return null;
        }
    }
}