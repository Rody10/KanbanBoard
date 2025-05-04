using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KanbanBoard.Models
{
    public class Project
    {
        [Key]
        [Display (Name = "ID")]
        public int ProjectId { get; set; }
        [Display(Name = "Name")]
        public string? ProjectName { get; set; }
        [Display(Name = "Description")]
        public string? ProjectDescription { get; set; }
        [Display(Name = "Creation Date")]
        public DateOnly ProjectCreationDate { get; set; }

        
        [ForeignKey("KanbanBoardUser")]
        public required string ProjectOwnerId { get; set; }
        public KanbanBoardUser? KanbanBoardUser { get; set; } // this is nullable because i need to be able to create a Project object without this Field and send it to the view
        

        public ICollection<KanbanBoardTask> KanbanBoardTasks { get; set; } = new List<KanbanBoardTask>();

    }
}
