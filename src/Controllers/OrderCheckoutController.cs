using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CodeCrafters_backend_teamwork.src.Abstractions;
using CodeCrafters_backend_teamwork.src.Controllers;
using CodeCrafters_backend_teamwork.src.DTO;
using CodeCrafters_backend_teamwork.src.DTOs;
using CodeCrafters_backend_teamwork.src.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CodeCrafters_backend_teamwork.src.Controller
{
    public class OrderCheckoutController : CustomizedController
    {
        private IOrderCheckoutService _orderCheckoutService;


        public OrderCheckoutController(IOrderCheckoutService orderCheckoutService)

        {
            _orderCheckoutService = orderCheckoutService;

        }

        [HttpGet]
        public ActionResult<IEnumerable<OrderCheckoutReadDto>> FindMany()
        {

            return Ok(_orderCheckoutService.FindMany());

        }

        [HttpGet("{orderCheckoutId}")]
        public ActionResult<OrderCheckoutReadDto?> FindOne([FromRoute] Guid orderCheckoutId)
        {

            return Ok(_orderCheckoutService.FindOne(orderCheckoutId));

        }


        [HttpPost]
        public ActionResult<IEnumerable<OrderCheckoutReadDto>> CreateOne([FromBody] OrderCheckoutCreateDto orderCheckout)

        {

            return CreatedAtAction(nameof(CreateOne), _orderCheckoutService.CreateOne(orderCheckout));

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

        [Authorize(Roles = "Admin,Customer")]
        [HttpPost("checkout")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<OrderCheckout> Checkout([FromBody] List<CheckoutCreateDto> orderItemCreate)
        {

            var authenticatedClaims = HttpContext.User;
            var userId = authenticatedClaims.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
            Console.WriteLine($"user id when login in checkout controller {userId}");
            var userGuid = new Guid(userId);

            if (orderItemCreate is null) return BadRequest();
            return CreatedAtAction(nameof(Checkout), _orderCheckoutService.Checkout(orderItemCreate, userGuid!));

        }
    }
}