using DbModels;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Provider.Repositories.Reader;
using WebLibrary.Commands.Reader.Interfaces;
using WebLibrary.Mappers.Reader;
using WebLibrary.Requests;
using WebLibrary.Validators;

namespace WebLibrary.Commands.Reader.Reader_commands;

public class UpdaterReader : ReaderActions, IUpdaterReader
{
    public UpdaterReader(IReaderRepository readerRepository, ICreateReaderRequestValidator validator, IReaderMapper mapper)
    : base(readerRepository, validator, mapper)
    {
    }

    public async Task<IActionResult> UpdateAsync(Guid id, CreateReaderRequest request)
    {
        if (await _readerRepository.GetAsync(id) is null)
        {
            return new NotFoundObjectResult(NOT_FOUND);
        }

        ValidationResult result = _validator.Validate(request);

        if (!result.IsValid)
        {
            List<string> errors = result.Errors.Select(e => e.ErrorMessage).ToList();

            return new BadRequestObjectResult(errors);
        }

        DbReader reader = _mapper.Map(request);
        reader.Id = id;

        await _readerRepository.UpdateAsync(reader);

        return new OkResult();
    }
}
