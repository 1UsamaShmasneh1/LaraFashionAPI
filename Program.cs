using LaraFashionAPI.Google;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors
    (
        options => options.AddPolicy("AllowAll", builder =>
        {
            builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();

        })
    );

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<GoogleConnection>();
builder.Services.AddSingleton<GoogleSheetManagement>();
builder.Services.AddSingleton<GoogleDriveManagament>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.Run();
