// Bibliotecas usadas pelo projeto
using BibliotecaDeClasses;

// Cria um construtor para a aplicação web
var builder = WebApplication.CreateBuilder(args);

// Adiciona configuração de CORS (Compartilhamento de Recursos de Origem Cruzada)
builder.Services.AddCors(options =>
{
    // Define uma política chamada "AllowSpecificOrigin"
    options.AddPolicy("AllowSpecificOrigin",
      builder => builder
        // Permite acesso de origens específicas (neste caso, localhost:7000)
        .WithOrigins("https://localhost:7000")
        // Permite qualquer cabeçalho de requisição
        .AllowAnyHeader()
        // Permite qualquer método HTTP (GET, POST, PUT, etc.)
        .AllowAnyMethod());
});

// Adiciona os serviços do ASP.NET Core MVC ao contêiner de dependências
builder.Services.AddControllers();

// Adiciona os serviços do ASP.NET Core MVC novamente (parece haver uma linha duplicada)
builder.Services.AddControllers();

// Adiciona documentação Swagger para a API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura a classe FilaBanco como um serviço Singleton (instanciada apenas uma vez)
builder.Services.AddSingleton<FilaBanco>();

// Constrói a aplicação web a partir do construtor
var app = builder.Build();

// Adiciona middleware para CORS (deve ser incluído antes do UseAuthorization)
app.UseCors("AllowSpecificOrigin");

// Define o pipeline de processamento de requisições HTTP
if (app.Environment.IsDevelopment())
{
    // Habilita o Swagger e a interface gráfica do Swagger para ambientes de desenvolvimento
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redireciona automaticamente requisições HTTP para HTTPS (opcional)
app.UseHttpsRedirection();

// Adiciona middleware de autorização (verifique se necessário)
app.UseAuthorization();

// Define o mapeamento de rotas para os controladores MVC
app.MapControllers();

// Inicia a escuta da aplicação web
app.Run();