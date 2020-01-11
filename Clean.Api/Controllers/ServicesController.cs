using Microsoft.AspNetCore.Mvc;

namespace Clean.Api.Controllers
{
    public class ServicesController
    {
        [HttpGet("/api/services")]
        public IActionResult Get()
        {
            return null;
        }
    }
}