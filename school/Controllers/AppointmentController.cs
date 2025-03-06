using Microsoft.AspNetCore.Mvc;

using school.Entity;


namespace school.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        public static List<Appointment> AppList = new List<Appointment>() { 
        new Appointment(1,new DateOnly(2023,5,8),new TimeOnly(5,45),5),
        new Appointment(2,new DateOnly(2024,5,9),new TimeOnly(5,55),6),
        new Appointment(3,new DateOnly(2023,12,8),new TimeOnly(6,35),3),
        new Appointment(4,new DateOnly(2020,5,30),new TimeOnly(7,00),4)

        };

       


        // GET: api/<Appointment>
        [HttpGet]
        public List<Appointment> GetAppointmentList()
        {
            return AppList;
        }

        // GET api/<Appointment>/5
        [HttpGet("{id}")]
        public Appointment GetAccordingToId(int id)
        {
            return AppList.FirstOrDefault(p=>p.ClientId==id);
        }

        // POST api/<Appointment>
        [HttpPost]
        public List<Appointment> AddAnAppointment([FromBody] Appointment v)
        {
            Appointment k = new Appointment(AppList[AppList.Count-1].Code+1,v.Date, v.Time, v.ClientId);
            AppList.Add(k);
            return AppList;
        }

        // PUT api/<Appointment>/5
        [HttpPut("{id}")]
        public List<Appointment> UpdateAnAppointment(int id, [FromBody] Appointment v)
        {
            int g = AppList.FindIndex(p => p.ClientId == id);
            AppList[g].Time = v.Time;
            AppList[g].Date = v.Date;
            AppList[g].ClientId = v.ClientId;
            return AppList;
        }

        // DELETE api/<Appointment>/5
        [HttpDelete("{id}")]
        public List<Appointment> Delete(int id)
        {
            AppList.Remove(AppList.FirstOrDefault(k => k.ClientId == id));
            return AppList;
        }
    }
}
