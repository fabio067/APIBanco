var builder = WebApplication.CreateBuilder(args);


// Adicione o CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("https://localhost:7000")
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});
// Adicione os serviços ao contêiner.
builder.Services.AddControllers();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure o middleware
app.UseCors("AllowSpecificOrigin"); // Adicione esta linha

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
