using System;
using System.Collections.Generic;

namespace WashBooking.Domain.Entities;

public partial class Booking
{
    public Guid Id { get; set; }

    public Guid? UserProfileId { get; set; }
    
    public Guid? AssigneeId { get; set; }

    public string BookingCode { get; set; } = null!;

    public string CustomerName { get; set; } = null!;

    public string CustomerPhone { get; set; } = null!;

    public DateOnly BookingDate { get; set; }

    public TimeOnly BookingTime { get; set; }

    public string Status { get; set; } = null!;

    public decimal TotalAmount { get; set; }

    public string PaymentStatus { get; set; } = null!;

    public string? PaymentMethod { get; set; }

    public string? Note { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual UserProfile? Assignee { get; set; }

    public virtual ICollection<BookingProgress> BookingProgresses { get; set; } = new List<BookingProgress>();

    public virtual ICollection<BookingService> BookingServices { get; set; } = new List<BookingService>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual UserProfile? UserProfile { get; set; }
}
