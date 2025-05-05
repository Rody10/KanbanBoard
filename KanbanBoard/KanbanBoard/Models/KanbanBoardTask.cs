using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KanbanBoard.Models
{
    public class KanbanBoardTask
    {
        [Key]
        [Display(Name = "ID")]
        public int TaskId { get; set; }
        [Display(Name = "Name")]
        public string? TaskName { get; set; }
        [Display(Name = "Description")]
        public string? TaskDescription {get; set;}
        [ForeignKey("KanbanBoardUser")]
        [Display(Name = "Assigned User ID")]
        public required string TaskAssignedUserId { get; set; }
        [Display(Name = "Assigned To")]
        public KanbanBoardUser? KanbanBoardUser { get; set; }
    }
}
