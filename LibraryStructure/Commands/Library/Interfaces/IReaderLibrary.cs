using ServiceModels.Requests.Library;
using ServiceModels.Responses.Library;
using WebLibrary.Commands.Common_interfaces;

namespace LibraryStructure.Commands.Library.Interfaces;

public interface IReaderLibrary : IReadCommand<GetLibraryRequest, GetLibraryResponse, GetLibrariesResponse>
{
}