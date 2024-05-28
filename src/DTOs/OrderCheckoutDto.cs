using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeCrafters_backend_teamwork.src.DTOs
{
    public class OrderCheckoutReadDto
    {
         public Guid Id {get ; set;}
        public DateTime CreatedAt {get ; set;}
        public required string Status {get ; set;}
        public double TotalPrice {get ; set;}
        public string Address {get; set;}
    }


     public class OrderCheckoutCreateDto
     {
        public Guid ProductId {get; set;}
        public Guid UsersId {get ; set;}
         public string Address {get; set;}
        public required string Status {get ; set;}
        public double TotalPrice {get ; set;}
    }

    public class CheckoutCreateDto
     {
        public Guid StockId {get ; set;}
    
        public int Quantity {get ; set;}
    }
    
     public class OrderCheckoutUpdateDto
     {
        public Guid Id {get ; set;}
        public int Payment {get ; set;}
        public Guid UsersId {get ; set;}
        public int Shipping {get ; set;}
        public required string Status {get ; set;}
        public double TotalPrice {get ; set;}
    }


}