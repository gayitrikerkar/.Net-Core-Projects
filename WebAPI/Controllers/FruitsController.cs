using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FruitsController : ControllerBase
    {
        public List<string> fruits = new List<string>()
        {
            "Apple",
            "Orange",
            "Guava",
            "Mango",
            "Banana"
        };

        [HttpGet]
        public List<string> GetFruits()
        {
            return fruits;
        }

        [HttpGet("{id}")]
        public string GetFruits(int id)
        {
            return fruits.ElementAt(id);
        }

    }
}
