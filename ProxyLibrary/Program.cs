using ProxyLibrary.Publishers;
using ProxyLibrary.Publishers.Book;
using ProxyLibrary.Publishers.Hall;
using ProxyLibrary.Publishers.Issue;
using ProxyLibrary.Publishers.Librarian;
using ProxyLibrary.Publishers.Library;
using ProxyLibrary.Publishers.Reader;
using ServiceModels.Requests.Book;
using ServiceModels.Requests.Hall;
using ServiceModels.Requests.Issue;
using ServiceModels.Requests.Librarian;
using ServiceModels.Requests.Library;
using ServiceModels.Requests.Reader;
using ServiceModels.Responses.Book;
using ServiceModels.Responses.Hall;
using ServiceModels.Responses.Issue;
using ServiceModels.Responses.Librarian;
using ServiceModels.Responses.Library;
using ServiceModels.Responses.Reader;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

//builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Book
builder.Services.AddScoped<
  IMessagePublisher<CreateBookRequest, CreateBookResponse>,
  CreateBookMessagePublisher>();

builder.Services.AddScoped<
  IMessagePublisher<GetBookRequest, GetBookResponse>,
  GetBookMessagePublisher>();

builder.Services.AddScoped<
  IMessagePublisher<GetBooksRequest, GetBooksResponse>,
  GetBooksMessagePublisher>();


builder.Services.AddScoped<
  IMessagePublisher<UpdateBookRequest, UpdateBookResponse>,
  UpdateBookMessagePublisher>();

builder.Services.AddScoped<
  IMessagePublisher<DeleteBookRequest, DeleteBookResponse>,
  DeleteBookMessagePublisher>();

//Reader
builder.Services.AddScoped<
  IMessagePublisher<CreateReaderRequest, CreateReaderResponse>,
  CreateReaderMessagePublisher>();

builder.Services.AddScoped<
  IMessagePublisher<GetReaderRequest, GetReaderResponse>,
  GetReaderMessagePublisher>();

builder.Services.AddScoped<
  IMessagePublisher<GetReadersRequest, GetReadersResponse>,
  GetReadersMessagePublisher>();

builder.Services.AddScoped<
  IMessagePublisher<UpdateReaderRequest, UpdateReaderResponse>,
  UpdateReaderMessagePublisher>();

builder.Services.AddScoped<
  IMessagePublisher<DeleteReaderRequest, DeleteReaderResponse>,
  DeleteReaderMessagePublisher>();

//Issue
builder.Services.AddScoped<
  IMessagePublisher<CreateIssueRequest, CreateIssueResponse>,
  CreateIssueMessagePublisher>();

builder.Services.AddScoped<
  IMessagePublisher<GetIssueRequest, GetIssueResponse>,
  GetIssueMessagePublisher>();

builder.Services.AddScoped<
  IMessagePublisher<GetIssuesRequest, GetIssuesResponse>,
  GetIssuesMessagePublisher>();

builder.Services.AddScoped<
  IMessagePublisher<UpdateIssueRequest, UpdateIssueResponse>,
  UpdateIssueMessagePublisher>();

builder.Services.AddScoped<
  IMessagePublisher<DeleteIssueRequest, DeleteIssueResponse>,
  DeleteIssueMessagePublisher>();

//Hall
builder.Services.AddScoped<
  IMessagePublisher<CreateHallRequest, CreateHallResponse>,
  CreateHallMessagePublisher>();

builder.Services.AddScoped<
  IMessagePublisher<GetHallRequest, GetHallResponse>,
  GetHallMessagePublisher>();

builder.Services.AddScoped<
  IMessagePublisher<GetHallsRequest, GetHallsResponse>,
  GetHallsMessagePublisher>();

builder.Services.AddScoped<
  IMessagePublisher<UpdateHallRequest, UpdateHallResponse>,
  UpdateHallMessagePublisher>();

builder.Services.AddScoped<
  IMessagePublisher<DeleteHallRequest, DeleteHallResponse>,
  DeleteHallMessagePublisher>();

//Library
builder.Services.AddScoped<
  IMessagePublisher<CreateLibraryRequest, CreateLibraryResponse>,
  CreateLibraryMessagePublisher>();

builder.Services.AddScoped<
  IMessagePublisher<GetLibraryRequest, GetLibraryResponse>,
  GetLibraryMessagePublisher>();

builder.Services.AddScoped<
  IMessagePublisher<GetLibrariesRequest, GetLibrariesResponse>,
  GetLibrariesMessagePublisher>();

builder.Services.AddScoped<
  IMessagePublisher<UpdateLibraryRequest, UpdateLibraryResponse>,
  UpdateLibraryMessagePublisher>();

builder.Services.AddScoped<
  IMessagePublisher<DeleteLibraryRequest, DeleteLibraryResponse>,
  DeleteLibraryMessagePublisher>();

//Librarian
builder.Services.AddScoped<
  IMessagePublisher<CreateLibrarianRequest, CreateLibrarianResponse>,
  CreateLibrarianMessagePublisher>();

builder.Services.AddScoped<
  IMessagePublisher<GetLibrarianRequest, GetLibrarianResponse>,
  GetLibrarianMessagePublisher>();

builder.Services.AddScoped<
  IMessagePublisher<GetLibrariansRequest, GetLibrariansResponse>,
  GetLibrariansMessagePublisher>();

builder.Services.AddScoped<
  IMessagePublisher<UpdateLibrarianRequest, UpdateLibrarianResponse>,
  UpdateLibrarianMessagePublisher>();

builder.Services.AddScoped<
  IMessagePublisher<DeleteLibrarianRequest, DeleteLibrarianResponse>,
  DeleteLibrarianMessagePublisher>();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();