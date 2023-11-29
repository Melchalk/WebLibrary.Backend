using MassTransit;
using Provider.Repositories.Book;
using Provider.Repositories.Issue;
using Provider.Repositories.Reader;
using WebLibrary.Commands.Book.Commands;
using WebLibrary.Commands.Book.Interfaces;
using WebLibrary.Commands.Issue.Commands;
using WebLibrary.Commands.Issue.Interfaces;
using WebLibrary.Commands.Reader.Commands;
using WebLibrary.Commands.Reader.Interfaces;
using WebLibrary.Mappers.Book;
using WebLibrary.Mappers.Issue;
using WebLibrary.Mappers.Reader;
using WebLibrary.Validators.Book;
using WebLibrary.Validators.Issue;
using WebLibrary.Validators.Reader;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IReaderRepository, ReaderRepository>();
builder.Services.AddScoped<IIssueRepository, IssueRepository>();

builder.Services.AddTransient<ICreateReaderRequestValidator, CreateReaderRequestValidator>();
builder.Services.AddTransient<IReaderMapper, ReaderMapper>();

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

builder.Services.AddTransient<ICreateIssueRequestValidator, CreateIssueRequestValidator>();
builder.Services.AddTransient<IIssueMapper, IssueMapper>();

builder.Services.AddTransient<ICreaterIssue, CreaterIssue>();
builder.Services.AddTransient<IReaderIssue, ReaderIssue>();
builder.Services.AddTransient<IUpdaterIssue, UpdaterIssue>();
builder.Services.AddTransient<IDeleterIssue, DeleterIssue>();

/*
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
*/

try
{
    builder.Services.AddMassTransit(x =>
    {
        x.AddConsumers(typeof(Program).Assembly);
        x.UsingRabbitMq((context, cfg) =>
        {
            cfg.Host("localhost");
            cfg.ConfigureEndpoints(context);
        });
    });
}
catch (Exception)
{
    throw new Exception("Failed to connect to rabbitmq");
}

var app = builder.Build();
/*
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
*/

app.UseAuthorization();

app.MapControllers();

app.Run();
