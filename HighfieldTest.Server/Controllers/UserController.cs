using HighfieldTest.Server.Classes;
using Microsoft.AspNetCore.Mvc;

using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace HighfieldTest.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<User> Get()
        {

            IEnumerable<User> users = new List<User>();

            var client = new WebClient();
            var content = client.DownloadString("https://recruitment.highfieldqualifications.com/api/test");
            var serializer = new DataContractJsonSerializer(typeof(List<User>));
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(content)))
            {
                users = (List<User>)serializer.ReadObject(ms);
            }
            return users;
        }
        
    }
}