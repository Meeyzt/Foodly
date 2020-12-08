using Foodly.Areas.Identity.Data;
using Microsoft.AspNetCore.Http;
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
        public string RestaurantName { get; set; }
        [Required]
        public double Star { get; set; }
        [Required]
        public DateTime PublishDate { get; set; }
        [Required]
        public string BannerImage { get; set; }
        [Required]
        public Byte[] ImageData{ get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public bool Publish { get; set; }
        [Required]
        public UserIdentity Id { get; set; }
    }
}
