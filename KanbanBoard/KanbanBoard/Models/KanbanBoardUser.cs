using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace KanbanBoard.Models
{
   
    public class KanbanBoardUser : IdentityUser
    {
        [Required]
        [MaxLength(100)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        public ICollection<Project> Projects { get; set; } = new List<Project>();

        [Display(Name = "Account Creation Date")]
        public DateOnly? AccountCreationDate { get; set; }

        [Display(Name = "Last Log In Date")]
        public DateOnly? LastLogInDate { get; set; }


    }
}
