using Microsoft.AspNetCore.Mvc;

namespace Clean.Api.Controllers.Users
{
    public class UsersDisabledController : ControllerBase
    {
        [HttpGet("/api/users/status/disabled")]
        public IActionResult Get()
        {
            return null;
        }
    }
}