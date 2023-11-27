using DbModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Provider.Repositories;
using WebLibrary.Commands.Reader.Interfaces;
using WebLibrary.Mappers.Reader;
using WebLibrary.Responses;
using WebLibrary.Validators;

namespace WebLibrary.Commands.Reader.Reader_commands;

public class ReaderReader : ReaderActions, IReaderReader
{
    public ReaderReader(IReaderRepository readerRepository, ICreateReaderRequestValidator validator, IReaderMapper mapper)
    : base(readerRepository, validator, mapper)
    {
    }

    public IActionResult Get()
    {
        List<DbReader> dbReaders = _readerRepository.Get().ToList();

        List<GetReaderResponse> readerResponse = dbReaders.Select(u => _mapper.Map(u)).ToList();

        return new OkObjectResult(readerResponse);
    }

    public async Task<IActionResult> GetAsync(Guid id)
    {
        DbReader? reader = await _readerRepository.GetAsync(id);

        if (reader is null)
        {
            return new NotFoundObjectResult(NOT_FOUND);
        }

        return new OkObjectResult(_mapper.Map(reader));
    }
}
