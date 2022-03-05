using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SpatialAnchors.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnchorsController : ControllerBase
    {
        public IAnchorDataStore Store { get; }

        public AnchorsController(IAnchorDataStore store)
        {
            Store = store;
        }

        // GET: api/<AnchorsController>
        [HttpGet]
        public IEnumerable<AnchorData> Get(string userId)
        {
            return Store.GetAnchors(userId);
        }


        // GET api/<AnchorsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AnchorsController>
        [HttpPost]
        public void Post([FromBody] AnchorData value, string userId)
        {
            Store.AddAnchorForUser(userId, value);
        }

        // PUT api/<AnchorsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AnchorsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
