using Microsoft.AspNetCore.Mvc;

namespace AsyncStreamWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // defaults to sending data as JSON
        // Response header: Content-Type: application/json; 
        [HttpGet]
        public IAsyncEnumerable<int> Get()
        {
            IAsyncEnumerable<int> value = GetData();
            return value;

        }
        private static async IAsyncEnumerable<int> GetData()
        {
            for (int counter = 0; counter < 10; counter++)
            {
                await Task.Delay(700);
                yield return counter;
            }

        }
    }
}