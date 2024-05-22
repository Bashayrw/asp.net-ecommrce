using AutoMapper;
using CodeCrafters_backend_teamwork.src.Abstractions;
using CodeCrafters_backend_teamwork.src.DTO;
using CodeCrafters_backend_teamwork.src.DTOs;
using CodeCrafters_backend_teamwork.src.Entities;

namespace CodeCrafters_backend_teamwork.src.Services
{
    public class OrderCheckoutService : IOrderCheckoutService
    {
        private IOrderCheckoutRepository _orderCheckoutRepo;
        private IOrderItemRepository _orderItemRepo;
        private readonly IMapper _mapper;

        public OrderCheckoutService(IOrderCheckoutRepository orderCheckoutRepository,
        IMapper mapper, IOrderItemRepository orderItemRepo)
        {
            _orderCheckoutRepo = orderCheckoutRepository;
            _orderItemRepo = orderItemRepo;
            _mapper = mapper;
        }

        public OrderCheckoutReadDto CreateOne(OrderCheckoutCreateDto newOrderCheckout)
        {
            OrderCheckout orderCheckout = _mapper.Map<OrderCheckout>(newOrderCheckout);
            _orderCheckoutRepo.CreateOne(orderCheckout);
            return _mapper.Map<OrderCheckoutReadDto>(orderCheckout);
        }

        //  public OrderCheckoutReadDto CreateOne(OrderCheckoutCreateDto order) //new
        // {
        //     var newProduct = _mapper.Map<OrderCheckout>(order);
        //     var createdOrder = _orderCheckoutRepo.CreateOne(newProduct);
        //     var orderRead = _mapper.Map<OrderCheckoutReadDto>(createdOrder);
        //     return orderRead;
        // }

        public IEnumerable<OrderCheckoutReadDto> FindMany()
        {
            IEnumerable<OrderCheckout> orderCheckouts = _orderCheckoutRepo.FindMany();
            return orderCheckouts.Select(_mapper.Map<OrderCheckoutReadDto>);
        }


        public OrderCheckout? FindOne(Guid orderCheckoutId)
        {
            return _orderCheckoutRepo.FindOne(orderCheckoutId);
        }


        public OrderCheckout UpdateOne(Guid orderCheckoutId, OrderCheckout updatedCheckout)
        {
            return _orderCheckoutRepo.UpdateOne(orderCheckoutId, updatedCheckout);
        }

        public IEnumerable<OrderCheckout>? DeleteOne(Guid orderCheckoutId)
        {
            return _orderCheckoutRepo.DeleteOne(orderCheckoutId);
        }

        IEnumerable<OrderCheckout> IOrderCheckoutService.FindMany()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderCheckout> CreateOne(OrderCheckout newOrderCheckout)
        {
            throw new NotImplementedException();
        }

        public OrderCheckout Checkout(List<CheckoutCreateDto> orderItemCreateDtos, Guid userId)
        {
            // create an Order object 
            var orderCheckout = new OrderCheckout();

            orderCheckout.UserId = Guid.NewGuid();
            orderCheckout.Status = "pending";
            orderCheckout.TotalPrice = 0;
            orderCheckout.Address = "Ida albergintie";

            _orderCheckoutRepo.CreateOne(orderCheckout);
            Console.WriteLine($"order checkout {orderCheckout.Id}");
            Console.WriteLine($"order userid  {orderCheckout.UserId}");

            // run for loop for list of orderItemCreateDtos
            foreach (var item in orderItemCreateDtos)
            {
                // when you run for loop, it will return a single item 
                var orderItem = new OrderItem(); ;

                orderItem.OrderCheckoutId = orderCheckout.Id;
                orderItem.StockId = item.StockId;
                orderItem.Quantity = item.Quantity;
                orderItem.Price = item.TotalPrice;
                // inside for loop, remember to inject _orderItemRepo and then _orderItemRepo.Create(orderItem)
                _orderItemRepo.CreateOne(orderItem);

            }
            // mock data for userId, paymentId, ShippingId
            //orderCheckout.Address = Guid.NewGuid();
            // orderCheckout.Shipping = Guid.NewGuid();

            // outside for loop, save order inside order table 
            _orderCheckoutRepo.CreateOne(orderCheckout);
            return orderCheckout;
        }
    }
}