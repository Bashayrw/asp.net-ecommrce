using System.ComponentModel.DataAnnotations;
using CodeCrafters_backend_teamwork.src.Enums;
using Microsoft.EntityFrameworkCore;

namespace CodeCrafters_backend_teamwork.src.Entities;


[Index(nameof(Email), IsUnique = true)]
public class User
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }
    public Role Role { get; set; } = Role.Customer;

    public List<OrderCheckout> OrderCheckouts { get; set; }
}
