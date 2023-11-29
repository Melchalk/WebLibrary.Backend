using Provider.Repositories.Book;
using Provider.Repositories.Reader;
using WebLibrary.Commands.Book.Commands;
using WebLibrary.Commands.Book.Interfaces;
using WebLibrary.Commands.Reader.Interfaces;
using WebLibrary.Commands.Reader.Commands;
using WebLibrary.Mappers.Book;
using WebLibrary.Mappers.Issue;
using WebLibrary.Mappers.Reader;
using WebLibrary.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IReaderRepository, ReaderRepository>();

builder.Services.AddTransient<ICreaterReader, CreaterReader>();
builder.Services.AddTransient<IReaderReader, ReaderReader>();
builder.Services.AddTransient<IUpdaterReader, UpdaterReader>();
builder.Services.AddTransient<IDeleterReader, DeleterReader>();

builder.Services.AddTransient<ICreateBookRequestValidator, CreateBookRequestValidator>();
builder.Services.AddTransient<IBookMapper, BookMapper>();

builder.Services.AddTransient<ICreaterBook, CreaterBook>();
builder.Services.AddTransient<IReaderBook, ReaderBook>();
builder.Services.AddTransient<IUpdaterBook, UpdaterBook>();
builder.Services.AddTransient<IDeleterBook, DeleterBook>();

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
