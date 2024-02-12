using HighfieldTest.Server.Classes;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;

namespace HighfieldTest.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FavouriteColourController : ControllerBase
    {
        private List<FavouriteColours> Sort(FavouriteColours[] colours)
        {
            
            int i, j;
            FavouriteColours temp = new FavouriteColours("",0);
            bool swapped;
            int length = colours.ToArray().Length;
            for (i = 0; i < length - 1; i++)
            {
                swapped = false;
                for (j = 0; j < length - i - 1; j++)
                {
                    if (colours[j].Quantity < colours[j + 1].Quantity || (colours[j].Quantity == colours[j + 1].Quantity && String.Compare(colours[j].Colour, colours[j + 1].Colour) > 0))
                    {
                        temp = colours[j];
                        colours[j] = colours[j + 1];
                        colours[j + 1] = temp;
                        swapped = true;
                    }
                }
                if (swapped == false)
                    break;
            }

            return colours.ToList<FavouriteColours>();
        }
        public List<FavouriteColours> CreateColoursList() 
        {
            UserController userController = new UserController();
            Array users = userController.Get().ToArray();

            List<FavouriteColours> favouriteColours = new List<FavouriteColours>();
      
            foreach (User user in users) 
            {
                bool colourInArray = false;
                var compColour = user.favouriteColour;
                if (favouriteColours.ToArray().Length == 0)
                {
                    favouriteColours.Add(new FavouriteColours(compColour, 1));
                    
                }
                else
                { 
                    foreach (FavouriteColours favouriteColour in favouriteColours)
                    {
                        if (favouriteColour.Colour == compColour)
                        {
                            favouriteColour.Quantity++;
                            colourInArray = true;
                        }
                    }

                    if (!colourInArray)
                    {
                        favouriteColours.Add(new FavouriteColours(compColour, 1)); ;
                      
                    }
                }
            }

           favouriteColours = Sort(favouriteColours.ToArray());
            return favouriteColours;
        }

        [HttpGet(Name = "GetFavouriteColours")]
        public IEnumerable<FavouriteColours> Get()
        {
            IEnumerable<FavouriteColours> colours = CreateColoursList();
            return colours;
        }
    }
}