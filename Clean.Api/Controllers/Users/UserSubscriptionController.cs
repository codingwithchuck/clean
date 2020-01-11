using Microsoft.AspNetCore.Mvc;

namespace Clean.Api.Controllers.Users
{
    public class UserSubscriptionController : ControllerBase
    {
        /// <summary>
        /// Add new Subscription
        /// </summary>
        /// <returns></returns>
        [HttpPost("/api/subscription")]
        public IActionResult Post()
        {
            return null;
        }

        /// <summary>
        /// Unsubscribe
        /// </summary>
        /// <returns></returns>
        [HttpDelete("/api/subscription")]
        public IActionResult Delete()
        {
            return null;
        }
    }
}