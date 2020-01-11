using Microsoft.AspNetCore.Mvc;

namespace Clean.Api.Controllers.Users
{
    public class UsersActiveController : ControllerBase
    {
        [HttpGet("/api/users/status/active")]
        public IActionResult Get()
        {
            return null;
        }
    }
}