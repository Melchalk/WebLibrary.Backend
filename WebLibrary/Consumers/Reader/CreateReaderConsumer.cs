﻿using MassTransit;
using ServiceModels.Requests.Reader;
using ServiceModels.Responses.Reader;
using WebLibrary.Commands.Reader.Interfaces;

namespace WebLibrary.Consumers.Reader;

public class CreateReaderConsumer : IConsumer<CreateReaderRequest>
{
    private readonly ICreaterReader _command;

    public CreateReaderConsumer(ICreaterReader command)
    {
        _command = command;
    }

    public async Task Consume(ConsumeContext<CreateReaderRequest> context)
    {
        CreateReaderResponse actionResult = await _command.CreateAsync(context.Message);

        await context.RespondAsync(actionResult);
    }
}