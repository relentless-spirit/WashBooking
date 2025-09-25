using System;
using System.Collections.Generic;

namespace WashBooking.Domain.Entities;

public partial class BookingService
{
    public Guid Id { get; set; }

    public Guid BookingId { get; set; }

    public Guid ServiceId { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Booking Booking { get; set; } = null!;

    public virtual Service Service { get; set; } = null!;
}
