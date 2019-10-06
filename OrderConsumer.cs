using System;
using System.Threading.Tasks;

namespace MassTransit.BlogTutorial
{
    public class OrderConsumer : IConsumer<IAddOrder>
    {
        public Task Consume(ConsumeContext<IAddOrder> context)
        {
            Console.WriteLine($"Receive message value: {context.Message.OrderDescription}");
            return Task.CompletedTask;
        }
    }
}