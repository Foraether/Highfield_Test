using System.Drawing;

namespace HighfieldTest.Server.Classes
{
    public class UserAges : User
    {
        public UserAges(User user)
        {
            id = user.id;
            firstName = user.firstName;
            lastName = user.lastName;
            email = user.email;
            dob = user.dob;
            favouriteColour = user.favouriteColour;
        }
        public int age { get; set; }
        public int ageInTwenty { get; set; }
    }


}
