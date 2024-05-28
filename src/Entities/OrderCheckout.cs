using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace CodeCrafters_backend_teamwork.src.Entities;

public class OrderCheckout
{
    [Key, Required]
    public Guid Id { get; set; }

    [Required]
    public Guid UserId { get; set; }

    [MaxLength(50), Required]

    public string Status { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    [Required]
    public double TotalPrice { get; set; }

    public string Address { get; set; }

    public List<OrderItem> OrderItems { get; set; }

}

