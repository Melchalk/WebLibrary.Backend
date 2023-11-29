using ServiceModels.Responses.Reader;
using WebLibrary.Commands.Common_interfaces;
using ServiceModels.Requests.Reader;

namespace WebLibrary.Commands.Reader.Interfaces;

public interface ICreaterReader : ICreater<CreateReaderRequest, CreateReaderResponse>
{
}
