using AutoMapper;
using BusinessLogicLayer.IInterfaces;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using DTOs.OrderDtos;

namespace BusinessLogicLayer.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderService(IUnitOfWork unitOfWork, 
                            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Order> AddOrderAsync(AddOrderDto addOrderDto)
        {
            var mapped = _mapper.Map<Order>(addOrderDto);
            await _unitOfWork.OrderInterface.AddEntityAsync(mapped);
            await _unitOfWork.SaveChangesAsync();
            return mapped;
        }

        public async Task DeleteOrderAsync(int id)
        {
            if(id <= 0)
                throw new ArgumentNullException(nameof(id));

            var order = await _unitOfWork.OrderInterface.GetEntityByIdAsync(id);
            if(order == null)
                throw new KeyNotFoundException(nameof(id));

            await _unitOfWork.OrderInterface.DeleteEntityAsyanc(order.Id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
        {
            var orders = await _unitOfWork.OrderInterface.GetAllEntitiesAsync();
            return orders.Select(c => _mapper.Map<OrderDto>(c));
        }

        public async Task<OrderDto> GetOrderByIdAsync(int id)
        {
            if(id <= 0)
                throw new ArgumentNullException(nameof(id));

            var order = await _unitOfWork.OrderInterface.GetEntityByIdAsync(id);
            if(order == null)
                throw new KeyNotFoundException(nameof(order));

            return _mapper.Map<OrderDto>(order);
        }

        public async Task UpdateOrderAync(UpdateOrderDto updateOrderDto)
        {
            var order = await _unitOfWork.OrderInterface.GetEntityByIdAsync(updateOrderDto.Id);
            if (order == null)
                throw new KeyNotFoundException(nameof(order));

            _mapper.Map(updateOrderDto, order);
            await _unitOfWork.OrderInterface.UpdateEntityAsyanc(order);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
