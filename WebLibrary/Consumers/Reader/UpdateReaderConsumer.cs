﻿using MassTransit;
using ServiceModels.Requests.Reader;
using ServiceModels.Responses.Reader;
using WebLibrary.Commands.Reader.Interfaces;

namespace WebLibrary.Consumers.Reader;

public class UpdateReaderConsumer : IConsumer<UpdateReaderRequest>
{
    private readonly IUpdaterReader _command;

    public UpdateReaderConsumer(IUpdaterReader command)
    {
        _command = command;
    }

    public async Task Consume(ConsumeContext<UpdateReaderRequest> context)
    {
        UpdateReaderResponse actionResult = await _command.UpdateAsync(context.Message);

        await context.RespondAsync(actionResult);
    }
}