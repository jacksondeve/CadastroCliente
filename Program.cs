using CadastroClientes.Models.Repository;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(options =>
{
    options.AddPolicy("corsapp", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// 🔥 ADICIONE ISSO AQUI
builder.Services.AddSingleton<AppConnection>();
builder.Services.AddScoped<ClientesRepository>();

var app = builder.Build();


    app.UseSwagger();
    app.UseSwaggerUI();


//app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseCors("corsapp");

app.UseAuthorization();

app.MapControllers();

app.Run();