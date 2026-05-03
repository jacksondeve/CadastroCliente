using CadastroCliente.Models;
using Microsoft.AspNetCore.Mvc;
using CadastroClientes.Models.Repository;

namespace CadastroCliente.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        IConfiguration configuration;

        public ClienteController()
        {
            configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
         }

        [HttpPost("Salvar")]
        public object Salvar([FromBody] Cliente cliente)
        {
            try
            {
                var appConfig = new AppConnection(configuration);
                var repo = new ClientesRepository(appConfig);

                repo.SalvarCliente(cliente);

                return cliente;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
                return ex.Message;
            }
        }

        [HttpDelete("Deletar/{id}")]
        public object Deletar(int id)
        {
            try
            {
                var appConfig = new AppConnection(configuration);
                var repo = new ClientesRepository(appConfig);

                return repo.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPut("Atualizar")]
        public object Atualizar([FromBody] Cliente cliente)
        {
            try
            {
                var appConfig = new AppConnection(configuration);
                var repo = new ClientesRepository(appConfig);

                return repo.Atualizar(cliente);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpGet("Listar")]
        public object Listar()
        {
            try
            {
                var appConfig = new AppConnection(configuration);
                var repo = new ClientesRepository(appConfig);

                return repo.Listar();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpGet("{id}")]
        public object Get(int id)
        {
            try
            {
                var appConfig = new AppConnection(configuration);
                var repo = new ClientesRepository(appConfig);

                return repo.GetById(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}