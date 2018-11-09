using System.ComponentModel.DataAnnotations;
namespace Dropdowns.Models
{
    public class Country 
    {
        public int CountryID { get; set; }

        [Display(Name = "Name")]
        public string CountryName { get; set; }
        public int ContinentID { get; set; }
        public Continent Continent { get; set; }
    }
}