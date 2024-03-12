using Basic_CRUD_Operations.DataContexts;
using Basic_CRUD_Operations.Helpers.GlobalExceptionHandler;
using Basic_CRUD_Operations.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddScoped<GlobalExceptionHandler, GlobalExceptionHandler>();

builder.Services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod()
            );

});

builder.Services.AddDbContext<AppDbContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    );
builder.Services.AddSwaggerGen(options =>
 {
     options.SwaggerDoc("v1", new OpenApiInfo { Title = "Poducts CRUDs", Version = "v1" });

     options.AddSecurityDefinition(
     "token",
     new OpenApiSecurityScheme
     {
         Type = SecuritySchemeType.Http,
         BearerFormat = "JWT",
         Scheme = "Bearer",
         In = ParameterLocation.Header,
         Name = HeaderNames.Authorization
     }
     );
     options.AddSecurityRequirement(
     new OpenApiSecurityRequirement
     {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "token"
                },
            },
            Array.Empty<string>()
        }
     }
         );
 });

builder.Services.AddControllers();

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        options.Authority = builder.Configuration.GetValue<string>("IdentityUrl");
        options.Audience = "productApi";
    });



var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<GlobalExceptionHandler>();

app.UseCors("AllowAnyOrigin");

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.UseStaticFiles("/wwwroot");
app.Run();
