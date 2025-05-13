using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace poe.Models
{
    public class Booking
    {
        [Key]
        [Display(Name = "Booking ID")]
        public int BookingId { get; set; }

        [Required(ErrorMessage = "Please select an event")]
        [Display(Name = "Event")]
        [ForeignKey("Event")]
        public int EventId { get; set; }
        public Event? Event { get; set; }

        [Required(ErrorMessage = "Please select a venue")]
        [Display(Name = "Venue")]
        [ForeignKey("Venue")]
        public int VenueId { get; set; }
        public Venue? Venue { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Booking Created Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime BookingDate { get; set; } = DateTime.Now;

        // Additional properties that might be useful
        [StringLength(500)]
        [Display(Name = "Special Requirements")]
        public string? SpecialRequirements { get; set; }

        [Display(Name = "Booking Status")]
        public BookingStatus Status { get; set; } = BookingStatus.Confirmed;
    }

    public enum BookingStatus
    {
        Pending,
        Confirmed,
        Cancelled,
        Completed
    }
}