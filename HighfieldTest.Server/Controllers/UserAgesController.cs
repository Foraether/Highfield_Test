using HighfieldTest.Server.Classes;
using Microsoft.AspNetCore.Mvc;

namespace HighfieldTest.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserAgesController
    {
        private List<UserAges> CreateUserAgesList()
        {
            UserController userController = new UserController();
            Array users = userController.Get().ToArray();

            List<UserAges> userAges = new List<UserAges>();

           foreach (User user in users) 
           {
                userAges.Add(new UserAges(user));
           }

            DateTime currentDate = DateTime.Parse(DateTime.Now.ToString("yyyy/MM/dd"));

            foreach (UserAges user in userAges) 
           {
                DateTime userDOB = DateTime.Parse(user.dob);
                var dateDiff = currentDate.Subtract(userDOB);
                user.age = Convert.ToInt32(Math.Ceiling((double) dateDiff.TotalDays/365));
                user.ageInTwenty = user.age + 20;
            }
            return userAges;
        }
            
        [HttpGet]
        public IEnumerable<UserAges> Get()
        {
            IEnumerable<UserAges> userAges = CreateUserAgesList();
            return userAges;
        }
    }
}
