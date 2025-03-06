using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using school.Entity;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace school.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        static List<Client> ClientList = new List<Client>() {


        new Client("1","Rivka","Beit Shemesh", "0987654", new DateTime(07/03/2025),"hjkl@gmail.com"),
        new Client("2","Elisheva","Beitar", "257468",new DateTime(07/03/2025),"shf@gmail.com"),
        new Client("3","Hadassa","Beit Habracha", "3876", new DateTime(07/03/2025),"jhg@gmail.com"),
        new Client("4","Michal","Neve Shemesh", "345677", new DateTime(03/03/2005),"rfv@gmail.com"),
        new Client("5","Chava","Neve Asher", "24668", new DateTime(06/03/2007),"rfzfgv@gmail.com"),
        new Client("6","Hodaya","Neve Michael", "2624", new DateTime(03/03/1919),"rzfgzfv@gmail.com"),
        new Client("7","Chana","America", "25436", new DateTime(03/03/2020),"rffdv@gmail.com"),
        new Client("8","Shayna","Jerusalem", "33452677", new DateTime(05/03/2023),"afagfh@gmail.com")

        };
        // GET: api/<Client>
        [HttpGet]
        public List<Client> GetClients()
        {
            return ClientList;
        }

        // GET api/<Client>/5
        [HttpGet("{id}")]
        public IActionResult ClientAccordingToId(string id)
        {
            try
            {
                Client c = ClientList.FirstOrDefault(u => u.Id.Equals(id));
                return Ok(c);
            }
            catch (Exception ex)
            {
                return NotFound("the Id is not valid");//returns 404
            }
        }
        // GET api/<Client>/find

        [HttpGet("find")]
        public List<Client> Find(string query)
        {
            Console.WriteLine(query);
            return null;
        }

        // POST api/<Client>
        [HttpPost]
        public List<Client> Post([FromBody] Client value)
        {
            ClientList.Add(new Client(value.Id, value.Name, value.Address, value.Phone, value.DateOfBirth, value.Email));
            return ClientList;

        }

        [HttpPost("createDataSave/{path}")]

        public IActionResult Post(string path)
        {
           
            if (!path.Contains(".txt"))
                return BadRequest("You should provide a txt file");

            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (Client c in ClientList)
                {
                    writer.WriteLine("Client " + c.Id);
                    writer.WriteLine("  " + c.Name);
                    writer.WriteLine("  " + c.Address);
                    writer.WriteLine("  " + c.DateOfBirth);
                    writer.WriteLine("  " + c.Email);

                }

            }
            return Ok("succeeded");

            //catch (Exception ex)
            //{
            //    return NotFound(ex);
            //    //return BadRequest(ex);//this sends a status of 500
            //}
        }

        // PUT api/<Client>/5
        [HttpPut("{id}")]
        public List<Client> EditClientDetails(int id, [FromBody] Client value)
        {
            int g = ClientList.FindIndex(p => p.Id.Equals(id + ""));
            if (!(g >= 0 && g < ClientList.Count()))
                return null;
            ClientList[g].Name = value.Name;
            ClientList[g].Address = value.Address;
            ClientList[g].Email = value.Email;
            ClientList[g].DateOfBirth = value.DateOfBirth;
            ClientList[g].Phone = value.Phone;
            return ClientList;

        }

        // DELETE api/<Client>/5
        [HttpDelete("{id}")]
        public List<Client> Delete(int id)
        {
            int g = ClientList.FindIndex(p => p.Id.Equals(id + ""));
            ClientList.Remove(ClientList[g]);
            return ClientList;
        }
    }
}
