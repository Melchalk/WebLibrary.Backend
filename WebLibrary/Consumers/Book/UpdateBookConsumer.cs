﻿using MassTransit;
using ServiceModels.Requests.Book;
using ServiceModels.Responses.Book;
using WebLibrary.Commands.Book.Interfaces;

namespace WebLibrary.Consumers.Book;

public class UpdateBookConsumer : IConsumer<UpdateBookRequest>
{
    private readonly IUpdaterBook _command;

    public UpdateBookConsumer(IUpdaterBook command)
    {
        _command = command;
    }

    public async Task Consume(ConsumeContext<UpdateBookRequest> context)
    {
        UpdateBookResponse actionResult = await _command.UpdateAsync(context.Message);

        await context.RespondAsync(actionResult);
    }
}