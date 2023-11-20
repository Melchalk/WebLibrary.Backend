using Provider.Repositories;
using WebLibrary.BooksOptions;
using WebLibrary.Mappers;
using WebLibrary.Mappers.Book;
using WebLibrary.Mappers.Issue;
using WebLibrary.Mappers.Reader;
using WebLibrary.ReaderOptions;
using WebLibrary.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IReaderRepository, ReaderRepository>();

builder.Services.AddTransient<IBookActions, BookActions>();
builder.Services.AddTransient<ICreateBookRequestValidator, CreateBookRequestValidator>();
builder.Services.AddTransient<IBookMapper, BookMapper>();

builder.Services.AddTransient<IReaderActions, ReaderActions>();
builder.Services.AddTransient<ICreateReaderRequestValidator, CreateReaderRequestValidator>();
builder.Services.AddTransient<IReaderMapper, ReaderMapper>();

builder.Services.AddTransient<IIssueMapper, IssueMapper>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
