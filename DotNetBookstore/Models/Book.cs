using System.ComponentModel.DataAnnotations;

namespace DotNetBookstore.Models
{
    public class Book
    {
        //PK

        public int BookId { get; set; }

        [Required]

        [MaxLength(100)]

        public string Author { get; set; }



        [Required]
        [MaxLength(300)]

        public string Title { get; set; }

        public string? Image { get; set; }



        [Required]

        [Range(0.01, 999999)]
        [DisplayFormat(DataFormatString = "{0:c}")] // c = MS currency format

        public decimal Price { get; set; }

        public bool MatureContent { get; set; }



        //FK
        [Display(Name = "Category")]
        public int CategoryId { get; set; }



        // child references

        public List<CartItem>? CartItems { get; set; }

        public List<OrderDetail>? OrderDetails { get; set; }



        // parent reference

        public Category? Category { get; set; }


    }
}
