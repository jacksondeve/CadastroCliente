using CadastroCliente.Models;
using Npgsql;

namespace CadastroClientes.Models.Repository
{
    public class ClientesRepository
    {
        private AppConnection _appConfig;

        public ClientesRepository(AppConnection appConfig)
        {
            _appConfig = appConfig;
        }

        // INSERT
        public void SalvarCliente(Cliente cliente)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_appConfig.ConnectionString))
                {
                    Console.WriteLine(_appConfig.ConnectionString);
                    connection.Open();


                    using (SqlCommand cmd = new SqlCommand("PROC_INSERT_CLIENTES", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@IdCliente", cliente.IdCliente);
                        cmd.Parameters.AddWithValue("@Documento", cliente.Documento);
                        cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
                        cmd.Parameters.AddWithValue("@Sexo", cliente.Sexo);
                        cmd.Parameters.AddWithValue("@Email", cliente.Email);
                        cmd.Parameters.AddWithValue("@Telefone", cliente.Telefone);
                        cmd.Parameters.AddWithValue("@UF", cliente.UF);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        // SELECT
        public List<Cliente> Listar()
        {
            List<Cliente> retorno = new List<Cliente>();

            using (SqlConnection connection = new SqlConnection(_appConfig.ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("PROC_SELECT_CLIENTE", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cliente cliente = new Cliente();

                            cliente.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                            cliente.Documento = reader["Documento"].ToString();
                            cliente.Nome = reader["Nome"].ToString();
                            cliente.Email = reader["Email"].ToString();
                            cliente.Sexo = reader["Sexo"].ToString();
                            cliente.Telefone = reader["Telefone"].ToString();
                            cliente.UF = reader["UF"].ToString();

                            retorno.Add(cliente);
                        }
                    }
                }
            }
            Console.WriteLine("salvo com sucesso");

            return retorno;
        }

        // DELETE
        public bool Delete(int IdCliente)
        {
            bool retorno = false;

            using (SqlConnection connection = new SqlConnection(_appConfig.ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("PROC_DELETE_CLIENTES", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdCliente", IdCliente);

                    int linhas = cmd.ExecuteNonQuery();

                    if (linhas > 0)
                    {
                        retorno = true;
                    }
                }
            }

            return retorno;
        }

        public bool Atualizar(Cliente cliente)
        {
            bool atualizado = false;

            using (SqlConnection connection = new SqlConnection(_appConfig.ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("PROC_UPDATE_CLIENTES", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdCliente", cliente.IdCliente);
                    cmd.Parameters.AddWithValue("@Documento", cliente.Documento);
                    cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
                    cmd.Parameters.AddWithValue("@Sexo", cliente.Sexo);
                    cmd.Parameters.AddWithValue("@Email", cliente.Email);
                    cmd.Parameters.AddWithValue("@Telefone", cliente.Telefone);
                    cmd.Parameters.AddWithValue("@UF", cliente.UF);

                    int linhas = cmd.ExecuteNonQuery();

                    if (linhas > 0)
                    {
                        atualizado = true;
                    }
                }
            }

            return atualizado;
        }

        public Cliente GetById(int id)
        {
            Cliente cliente = null;

            using (SqlConnection connection = new SqlConnection(_appConfig.ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("PROC_GET_CLIENTE", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdCliente", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cliente = new Cliente();

                            cliente.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                            cliente.Documento = reader["Documento"].ToString();
                            cliente.Nome = reader["Nome"].ToString();
                            cliente.Email = reader["Email"].ToString();
                            cliente.Sexo = reader["Sexo"].ToString();
                            cliente.Telefone = reader["Telefone"].ToString();
                            cliente.UF = reader["UF"].ToString();
                        }
                    }
                }
            }

            return cliente;
        }
    }
}