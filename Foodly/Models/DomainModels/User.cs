using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foodly.Models
{
    public class User
    {
        [Key,Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }
        [Required]
        public string Username { get; set; }
        [Required,DataType(DataType.Password)]
        public int Password { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string DisplayName { get; set; }
        [Required]
        public Byte[] ProfilePhotoData { get; set; }
        [Required]
        public string ProfilePhoto { get; set; }
        [Required]
        public DateTime RegisterDate { get; set; }
        [Required]
        public string SecretKey { get; set; }
        [Required]
        public string Auth { get; set; }
    }
}
