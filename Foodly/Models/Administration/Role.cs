using System.ComponentModel.DataAnnotations;

namespace Foodly.Models.Administration
{
    public class Role
    {
        [Required]
        public string RoleName { get; set; }
    }
}
