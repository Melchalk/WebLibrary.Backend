﻿using Provider.Repositories;
using WebLibrary.Mappers.Reader;
using WebLibrary.Validators;

namespace WebLibrary.Commands.Reader.Reader_commands;

public abstract class ReaderActions
{
    protected const string NOT_FOUND = "ID is not found";
    protected const string DELETE = "The deletion was successful";

    protected readonly IReaderRepository _readerRepository;

    protected readonly ICreateReaderRequestValidator _validator;
    protected readonly IReaderMapper _mapper;

    public ReaderActions(
        IReaderRepository readerRepository,
        ICreateReaderRequestValidator validator,
        IReaderMapper mapper)
    {
        _readerRepository = readerRepository;
        _validator = validator;
        _mapper = mapper;
    }
}