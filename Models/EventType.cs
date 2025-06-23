using System.ComponentModel.DataAnnotations;

namespace poe.Models
{
    public class EventTypes
    {
        public int EventTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } // e.g., "Conference", "Wedding"

        public ICollection<Event> Events { get; set; }
    }
}
