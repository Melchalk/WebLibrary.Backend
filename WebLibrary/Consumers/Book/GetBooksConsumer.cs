﻿using MassTransit;
using ServiceModels.Requests.Book;
using ServiceModels.Responses.Book;
using WebLibrary.Commands.Book.Interfaces;

namespace WebLibrary.Consumers.Book;

public class GetBooksConsumer : IConsumer<GetBooksRequest>
{
    private readonly IReaderBook _command;

    public GetBooksConsumer(IReaderBook command)
    {
        _command = command;
    }

    public async Task Consume(ConsumeContext<GetBooksRequest> context)
    {
        GetBooksResponse actionResult =  _command.Get();

        await context.RespondAsync(actionResult);
    }
}