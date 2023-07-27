using System.Collections.Generic;

namespace BestRestaurants.Models
{
    public class Restaurant {
      public int RestaurantId {get; set; }
      public string Name {get; set; }
      public string Address {get; set; }
      public string PhoneNumber {get; set; }
      public int CuisineId {get; set; }
      public Cuisine cuisine {get; set;}
      
    }
//     public enum Cuisine1
// {
//     Italian,
//     Mexican,
//     Thai, 
//     French,
//     American    
// }
}