using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using WebLibrary.Backend.Auth.Helpers;
using WebLibrary.Backend.Auth.Services;
using WebLibrary.Backend.Auth.Services.Interfaces;
using WebLibrary.Backend.Provider;
using WebLibrary.Backend.Provider.Interfaces;
using WebLibrary.Backend.Repositories;
using WebLibrary.Backend.Repositories.Interfaces;
using WebLibrary.Infrastructure.Mapping;
using WebLibrary.Infrastructure.Middlewares;
using WebLibrary.Infrastructure.Swagger;
using WebLibraryService.Backend.Domain;
using WebLibraryService.Backend.Domain.Interfaces;

namespace WebLibrary;

internal class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<WebLibraryDbContext>(options =>
        {
            options.UseNpgsql(Configuration.GetConnectionString("SQLConnectionString"));
        });

        services.AddSingleton(new MapperConfiguration(mc =>
        {
            mc.AddProfile<MappingProfile>();
        }).CreateMapper());

        services.AddControllers();

        services.AddSingleton<IDataProvider, WebLibraryDbContext>();

        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IHallRepository, HallRepository>();
        services.AddScoped<IIssueRepository, IssueRepository>();
        services.AddScoped<ILibrarianRepository, LibrarianRepository>();
        services.AddScoped<ILibraryRepository, LibraryRepository>();
        services.AddScoped<IReaderRepository, ReaderRepository>();

        services.AddScoped<IBookService, BookService>();
        services.AddScoped<IHallService, HallService>();
        services.AddScoped<IIssueService, IssueService>();
        services.AddScoped<ILibrarianService, LibrarianService>();
        services.AddScoped<ILibraryService, LibraryService>();
        services.AddScoped<IReaderService, ReaderService>();

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthService, AuthService>();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

        ConfigureJwt(services);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseMiddleware<GlobalExceptionMiddleware>();

        UpdateDatabase(app);

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }

    private void ConfigureJwt(IServiceCollection services)
    {
        services.Configure<TokenSettings>(Configuration.GetSection("TokenSettings"));

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = Configuration.GetSection("TokenSettings:TokenIssuer").Value,
                    ValidateAudience = true,
                    ValidAudience = Configuration.GetSection("TokenSettings:TokenAudience").Value,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = SigningSymmetricKey.GetKey()
                };
            });
    }

    private void UpdateDatabase(IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices
            .GetRequiredService<IServiceScopeFactory>()
            .CreateScope();

        using var context = serviceScope.ServiceProvider
            .GetService<WebLibraryDbContext>();

        context!.Database.Migrate();
    }
}