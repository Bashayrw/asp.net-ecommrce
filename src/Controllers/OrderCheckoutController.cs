using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeCrafters_backend_teamwork.src.Abstractions;
using CodeCrafters_backend_teamwork.src.Controllers;
using CodeCrafters_backend_teamwork.src.DTO;
using CodeCrafters_backend_teamwork.src.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CodeCrafters_backend_teamwork.src.Controller
{
    public class OrderCheckoutController : CustomizedController
    {
        private IOrderCheckoutService _orderCheckoutService;


        public OrderCheckoutController (IOrderCheckoutService orderCheckoutService)

        { 
            _orderCheckoutService = orderCheckoutService;

        }

        [HttpGet]
        public ActionResult<IEnumerable<OrderCheckout>> FindMany()
        {

            return Ok( _orderCheckoutService.FindMany());

        }

        [HttpGet("{orderCheckoutId}")]
        public OrderCheckout? FindOne(Guid orderCheckoutId)
        {

            return _orderCheckoutService.FindOne(orderCheckoutId);

        }


        [HttpPost]
        public ActionResult<IEnumerable<OrderCheckout>> CreateOne([FromBody] OrderCheckout orderCheckout)

        {

            return Ok(_orderCheckoutService.CreateOne(orderCheckout));

        }



        [HttpDelete("{orderCheckoutId}")]
        public IEnumerable<OrderCheckout>? DeleteOne([FromRoute] Guid orderCheckoutId)
        {
            return _orderCheckoutService.DeleteOne(orderCheckoutId);
        }

        [HttpPatch("{orderCheckoutId}")]
        public OrderCheckout UpdateOne(Guid orderCheckoutId, OrderCheckout updatedCheckout)
        {
            return _orderCheckoutService.UpdateOne(orderCheckoutId, updatedCheckout);
        }
        [HttpPost("/checkout")]
        public OrderCheckout Checkout(List<OrderItemCreateDto> orderItemCreateDtos)
        {
            return _orderCheckoutService.Checkout(orderItemCreateDtos); 
        }
}}