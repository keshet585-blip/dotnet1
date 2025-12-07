using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace lesson2.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]

    public class EventController : ControllerBase
    {

        public static List<Event> events { get; set; } = new List<Event>();
        public static int count;
        

        public EventController()
        {
           
        }


        // GET: api/<EventController>
        [HttpGet]
        public List<Event> Get()
        {
            return events;
        }


        // POST api/<EventController>
        [HttpPost]
        public void Post([FromBody]Event e)
        {
            //if (e.GetType().Equals( "Event")) 
            e.Id = count++;
            events.Add(e);
        }

        // PUT api/<EventController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Event value)
        {
            Event a = events.Find(e => e.Id == id);
            if (a!=null)
            events.Remove(a);
            events.Add(value);
        }

        // DELETE api/<EventController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            events.Remove(events.Find(e => e.Id == id));
        }
    }
}
