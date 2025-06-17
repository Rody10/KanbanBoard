using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KanbanBoard.Models
{
    public class KanbanBoardTask
    {
        public enum Status
        {
            ToDo,
            DoToday,
            InProgress,
            Done
        }

        [Key]
        [Display(Name = "ID")]
        public int TaskId { get; set; }

        [Display(Name = "Task Status")]
        public Status TaskStatus { get; set; } = Status.ToDo;

        [Display(Name = "Name")]
        public string? TaskName { get; set; }
        [Display(Name = "Description")]
        public string? TaskDescription {get; set;}
        [ForeignKey("KanbanBoardUser")]
        [Display(Name = "Assigned User ID")]
        public required string TaskAssignedUserId { get; set; } 
        [Display(Name = "Assigned To")]
        public KanbanBoardUser? KanbanBoardUser { get; set; }

        [ForeignKey("Project")]
        public int ProjectID { get; set; }
    }
}
