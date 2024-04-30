﻿using MassTransit;
using ServiceModels.Requests.Book;
using ServiceModels.Responses.Book;
using WebLibrary.Commands.Book.Interfaces;

namespace WebLibrary.Consumers.Book;

public class CreateBookConsumer : IConsumer<CreateBookRequest>
{
    private readonly ICreateBookCommand _command;

    public CreateBookConsumer(ICreateBookCommand command)
    {
        _command = command;
    }

    public async Task Consume(ConsumeContext<CreateBookRequest> context)
    {
        CreateBookResponse actionResult = await _command.CreateAsync(context.Message);

        await context.RespondAsync(actionResult);
    }
}