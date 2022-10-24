using System.ComponentModel.DataAnnotations;

namespace Timely.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public string? ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? StopDate { get; set; }
        public TimeSpan? Duration { get; set; }
    }
}
