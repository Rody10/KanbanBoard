using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KanbanBoard.Models
{
    public class KanbanBoardTask
    {
        [Key]
        public int TaskId { get; set; }
        public string? TaskName { get; set; }
        public string? TaskDescription {get; set;}
        [ForeignKey("KanbanBoardUser")]
        public required string TaskAssignedUserId { get; set; }
        public required KanbanBoardUser KanbanBoardUser { get; set; }
    }
}
