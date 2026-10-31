using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Models
{
    public class TaskItem
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public string Status { get; set; } = "To Do";   // To Do, In Progress, Done

        [Required]
        public string Priority { get; set; } = "Medium"; // Low, Medium, High

        public DateTime? DueDate { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // Link the task to the logged-in user
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
    }
}