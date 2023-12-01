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

builder.Services.AddScoped<IHallRepository, HallRepository>();
builder.Services.AddScoped<ILibrarianRepository, LibrarianRepository>();
builder.Services.AddScoped<ILibraryRepository, LibraryRepository>();

builder.Services.AddTransient<ICreateHallRequestValidator, CreateHallRequestValidator>();
builder.Services.AddTransient<IHallMapper, HallMapper>();

builder.Services.AddTransient<ICreaterHall, CreaterHall>();
builder.Services.AddTransient<IReaderHall, ReaderHall>();
builder.Services.AddTransient<IUpdaterHall, UpdaterHall>();
builder.Services.AddTransient<IDeleterHall, DeleterHall>();

builder.Services.AddTransient<ICreateLibraryRequestValidator, CreateLibraryRequestValidator>();
builder.Services.AddTransient<ILibraryMapper, LibraryMapper>();

builder.Services.AddTransient<ICreaterLibrary, CreaterLibrary>();
builder.Services.AddTransient<IReaderLibrary, ReaderLibrary>();
builder.Services.AddTransient<IUpdaterLibrary, UpdaterLibrary>();
builder.Services.AddTransient<IDeleterLibrary, DeleterLibrary>();

builder.Services.AddTransient<ICreateLibrarianRequestValidator, CreateLibrarianRequestValidator>();
builder.Services.AddTransient<ILibrarianMapper, LibrarianMapper>();

builder.Services.AddTransient<ICreaterLibrarian, CreaterLibrarian>();
builder.Services.AddTransient<IReaderLibrarian, ReaderLibrarian>();
builder.Services.AddTransient<IUpdaterLibrarian, UpdaterLibrarian>();
builder.Services.AddTransient<IDeleterLibrarian, DeleterLibrarian>();

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
