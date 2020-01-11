using Microsoft.AspNetCore.Mvc;

namespace Clean.Api.Controllers
{
    public class AdminUserStatusController : ControllerBase
    {
        [HttpPut("/api/admin/user/{userId:int}/status/{status:int}")]
        public IActionResult Put(int userId, int status)
        {
            return null;
        }
    }
}