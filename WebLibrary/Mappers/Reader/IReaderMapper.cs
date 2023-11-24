﻿using DbModels;
using WebLibrary.ModelResponse;
using WebLibrary.Requests;

namespace WebLibrary.Mappers.Reader;

public interface IReaderMapper
{
    DbReader Map(CreateReaderRequest readerRequest);

    GetReaderResponse Map(DbReader dbReader);
}
