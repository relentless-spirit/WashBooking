using WashBooking.Domain.Enums;

namespace WashBooking.Domain.Entities;

public partial class UserProfile
{
    public Guid Id { get; set; }

    public string FullName { get; set; } = null!;

    public string? Phone { get; set; }

    public string Email { get; set; }

    public string? Address { get; set; } = null;

    public Role Role { get; set; } = Role.Customer;

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

    public virtual ICollection<Booking> BookingAssignees { get; set; } = new List<Booking>();

    public virtual ICollection<Booking> BookingUserProfiles { get; set; } = new List<Booking>();
}
