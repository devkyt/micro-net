using AutoMapper;
using Contracts;
using MassTransit;
using MongoDB.Entities;
using SearchService.Models;

namespace SearchService.Consumers;

public class AuctioUpdatedConsumer : IConsumer<AuctionUpdated>
{
    private readonly IMapper _mapper;

    public AuctioUpdatedConsumer(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task Consume(ConsumeContext<AuctionUpdated> context)
    {
        Console.WriteLine($"----> Consuming auction updated: {context.Message.Id}");

        var item = _mapper.Map<Item>(context.Message); 

        var result = await DB.Update<Item>()
                             .Match(a => a.ID == context.Message.Id)
                             .ModifyOnly(x => new 
                             {
                                x.Type,
                                x.Model,
                                x.Color,
                                x.Year,
                                x.Condition
                             }, item)
                             .ExecuteAsync();

        if (!result.IsAcknowledged)
        {
            throw new MessageException(typeof(AuctionUpdated), "Could not update MongoDb");
        }
    }

    

}