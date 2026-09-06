using Azure.Identity;
using Azure.ResourceManager;
using Microsoft.AspNetCore.Mvc;

namespace BuildAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AzureRbacTestController : ControllerBase
    {
       [HttpGet]
       public async Task<IActionResult> Test()
        {
             var credential = new DefaultAzureCredential();
             
            var client = new ArmClient(credential);

            var subscription = await client.GetDefaultSubscriptionAsync();

            var resourceGroups = subscription.GetResourceGroups();

            var groups = new List<string>();

            await foreach (var group in resourceGroups.GetAllAsync())
            {
                groups.Add(group.Data.Name);
            }

            return Ok(groups);
        } 
    }
}