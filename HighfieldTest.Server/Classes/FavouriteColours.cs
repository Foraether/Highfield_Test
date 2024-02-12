namespace HighfieldTest.Server.Classes
{
    public class FavouriteColours
    {
        public FavouriteColours(string? colour, int quantity)
        {
            Colour = colour;
            Quantity = quantity;
        }

        public string? Colour { get; set; }

        public int Quantity { get; set; }
    }
}
