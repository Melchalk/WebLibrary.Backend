﻿using ServiceModels.Requests.Reader;
using ServiceModels.Responses.Reader;
using WebLibrary.Commands.Common_interfaces;

namespace WebLibrary.Commands.Reader.Interfaces;

public interface IDeleterReader : IDeleter<DeleteReaderRequest, DeleteReaderResponse>
{
}
