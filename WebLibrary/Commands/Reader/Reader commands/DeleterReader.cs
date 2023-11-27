using DbModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Provider.Repositories.Reader;
using WebLibrary.Commands.Book.Book_commands;
using WebLibrary.Commands.Book.Interfaces;
using WebLibrary.Commands.Reader.Interfaces;
using WebLibrary.Mappers.Book;
using WebLibrary.Mappers.Reader;
using WebLibrary.Validators;

namespace WebLibrary.Commands.Reader.Reader_commands;

public class DeleterReader : ReaderActions, IDeleterReader
{
    public DeleterReader(IReaderRepository readerRepository, ICreateReaderRequestValidator validator, IReaderMapper mapper)
    : base(readerRepository, validator, mapper)
    {
    }

    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        DbReader? reader = await _readerRepository.GetAsync(id);

        if (reader is null)
        {
            return new NotFoundObjectResult(NOT_FOUND);
        }

        await _readerRepository.DeleteAsync(reader);

        return new OkObjectResult(DELETE);
    }
}
