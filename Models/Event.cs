using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace poe.Models
{
    public class Event
    {
        [Key]
        [Display(Name = "Event ID")]
        public int EventId { get; set; }

        [Required(ErrorMessage = "Event name is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Event name must be between 3-100 characters")]
        [Display(Name = "Event Name")]
        public string EventName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Event date is required")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Event Date & Time")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        [FutureDate(ErrorMessage = "Event date must be in the future")]
        public DateTime EventDate { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        [Display(Name = "Description")]
        public string? Description { get; set; }

        [Display(Name = "Venue")]
        [ForeignKey("Venue")]
        public int? VenueId { get; set; }
        public Venue? Venue { get; set; }

        [Display(Name = "Event Type")]
        public EventType? Type { get; set; }

        [Display(Name = "Expected Attendees")]
        [Range(1, 10000, ErrorMessage = "Attendees must be between 1-10,000")]
        public int? ExpectedAttendees { get; set; }

        public ICollection<Booking>? Bookings { get; set; }
    }

    public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is DateTime date)
            {
                return date > DateTime.Now;
            }
            return false;
        }
    }

    public enum EventType
    {
        Conference,
        Wedding,
        Concert,
        Exhibition,
        Corporate,
        Private
    }
}
