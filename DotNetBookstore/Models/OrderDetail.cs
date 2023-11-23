using System.ComponentModel.DataAnnotations;

namespace DotNetBookstore.Models
{
    public class OrderDetail
    {
        //PK

        public int OrderDetailId { get; set; }



        [Required]

        public int Quantity { get; set; }



        [Required]

        public decimal Price { get; set; }



        //FK

        [Required]

        public int OrderId { get; set; }



        //FK

        [Required]

        public int BookId { get; set; }



        // parent refs

        public Book? Books { get; set; }

        public Order? Order { get; set; }
    }
}
