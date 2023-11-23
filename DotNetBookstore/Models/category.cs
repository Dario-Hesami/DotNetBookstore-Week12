using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace DotNetBookstore.Models
{
    public class Category
    {
        // pk fields should always be called either {Model}Id or Id
        //[Display(Name = "Category ID")]
        //[Range(1, 999999)]

        public int CategoryId { get; set; }
        [Required(ErrorMessage = "A customized error message... ")]

        
        public string Name { get; set; }

    }
}
