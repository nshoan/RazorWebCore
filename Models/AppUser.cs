using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable
namespace RazorWeb6.Models
{
    public class AppUser : IdentityUser
    {
        [StringLength(400)]
        [Column(TypeName ="nvarchar")]
        public string HomeAddress { get; set; }
    }
}
