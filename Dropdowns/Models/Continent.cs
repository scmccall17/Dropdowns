using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dropdowns.Models
{
    public class Continent
    {
        public int ContinentID { get; set; }
        
        [Display(Name = "Name")]
        public string ContinentName { get; set; }
        public ICollection<Country> Countries { get; set; }
    }
}