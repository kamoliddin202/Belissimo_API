﻿using DataAccessLayer.Models;

namespace DTOs.OrderItemDtos
{
    public class AddOrderItemDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int OrderId { get; set; }
    }
}
