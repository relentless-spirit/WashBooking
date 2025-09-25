using System;
using System.Collections.Generic;

namespace WashBooking.Domain.Entities;

public partial class BookingProgress
{
    public Guid Id { get; set; }

    public Guid BookingId { get; set; }

    public string Status { get; set; } = null!;

    public string? Note { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Booking Booking { get; set; } = null!;
}
