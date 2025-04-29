using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KanbanBoard.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public string? ProjectName { get; set; }
        public string? ProjectDescription { get; set; }
        public DateOnly ProjectCreationDate { get; set; }

        
        [ForeignKey("KanbanBoardUser")]
        public required string ProjectOwnerId { get; set; }
        public required KanbanBoardUser KanbanBoardUser { get; set; }
        

        public ICollection<KanbanBoardTask> KanbanBoardTasks { get; set; } = new List<KanbanBoardTask>();

    }
}
