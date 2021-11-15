using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Services.Basket.Services;
using ECommerce.Shared.Messages;
using MassTransit;

namespace ECommerce.Services.Basket.Consumers
{
    public class CourseNameChangedEventConsumer : IConsumer<CourseNameChangedEvent>
    {
        private readonly IBasketService _basketService;

        public CourseNameChangedEventConsumer(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public Task Consume(ConsumeContext<CourseNameChangedEvent> context)
        {
            throw new NotImplementedException();
        }
    }
}
