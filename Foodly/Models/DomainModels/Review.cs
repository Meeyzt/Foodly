using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foodly.Models
{
    public class Review
    {
        [Key,Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReviewID { get; set; }
        [Required]
        public string Header { get; set; }
        [Required]
        public string Blog { get; set; }
        [Required]
        public string PictureURL { get; set; }
        [Required]
        public string RestaurantName { get; set; }
        [Required]
        public double Star { get; set; }
        [Required]
        public DateTime PublishDate { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public string Adress { get; set; }
        [Required]
        public bool Publish { get; set; }
        public User User { get; set; }
    }
}
