using DbModels;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Provider.Repositories.Reader;
using WebLibrary.Commands.Reader.Interfaces;
using WebLibrary.Mappers.Reader;
using WebLibrary.Requests;
using WebLibrary.Validators;

namespace WebLibrary.Commands.Reader.Reader_commands;

public class CreaterReader : ReaderActions, ICreaterReader
{
    public CreaterReader(IReaderRepository readerRepository, ICreateReaderRequestValidator validator, IReaderMapper mapper)
    : base(readerRepository, validator, mapper)
    {
    }


    public async Task<IActionResult> CreateAsync(CreateReaderRequest request)
    {
        ValidationResult result = _validator.Validate(request);

        if (!result.IsValid)
        {
            List<string> errors = result.Errors.Select(e => e.ErrorMessage).ToList();

            return new BadRequestObjectResult(errors);
        }

        DbReader reader = _mapper.Map(request);

        await _readerRepository.AddAsync(reader);

        return new CreatedResult("Library.Readers", reader.Id);
    }
}
