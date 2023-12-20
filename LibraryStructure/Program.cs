using LibraryStructure.Commands.Hall.Commands;
using LibraryStructure.Commands.Hall.Interfaces;
using LibraryStructure.Commands.Librarian.Commands;
using LibraryStructure.Commands.Librarian.Interfaces;
using LibraryStructure.Commands.Library.Commands;
using LibraryStructure.Commands.Library.Interfaces;
using LibraryStructure.Validators.Hall;
using LibraryStructure.Validators.Librarian;
using LibraryStructure.Validators.Library;
using MassTransit;
using Provider.Repositories.Hall;
using Provider.Repositories.Librarian;
using Provider.Repositories.Library;
using WebLibrary.Mappers.Hall;
using WebLibrary.Mappers.Librarian;
using WebLibrary.Mappers.Library;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

/*
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
*/

builder.Services.AddScoped<IHallRepository, hallRepository>();
builder.Services.AddScoped<ILibrarianRepository, LibrarianRepository>();
builder.Services.AddScoped<ILibraryRepository, LibraryRepository>();

builder.Services.AddTransient<ICreateHallRequestValidator, CreateHallRequestValidator>();
builder.Services.AddTransient<IHallMapper, HallMapper>();

builder.Services.AddTransient<ICreateHallCommand, CreateHallCommand>();
builder.Services.AddTransient<IReadHallCommand, ReadHallCommand>();
builder.Services.AddTransient<IUpdateHallCommand, UpdateHallCommand>();
builder.Services.AddTransient<IDeleteHallCommand, DeleteHallCommand>();

builder.Services.AddTransient<ICreateLibraryRequestValidator, CreateLibraryRequestValidator>();
builder.Services.AddTransient<ILibraryMapper, LibraryMapper>();

builder.Services.AddTransient<ICreaterLibrary, CreaterLibrary>();
builder.Services.AddTransient<IReaderLibrary, ReaderLibrary>();
builder.Services.AddTransient<IUpdaterLibrary, UpdaterLibrary>();
builder.Services.AddTransient<IDeleterLibrary, DeleterLibrary>();

builder.Services.AddTransient<ICreateLibrarianRequestValidator, CreateLibrarianRequestValidator>();
builder.Services.AddTransient<ILibrarianMapper, LibrarianMapper>();

builder.Services.AddTransient<ICreaterLibrarian, CreateLibrarianCommand>();
builder.Services.AddTransient<IReaderLibrarian, ReadLibrarianCommand>();
builder.Services.AddTransient<IUpdaterLibrarian, UpdateLibrarianCommand>();
builder.Services.AddTransient<IDeleterLibrarian, DeleteLibrarianCommand>();

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

app.UseHttpsRedirection();
*/

app.UseAuthorization();

app.MapControllers();

app.Run();
