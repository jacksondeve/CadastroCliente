using CadastroCliente.Models;
using Npgsql;
using System.Data;
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
            using (var conn = _appConfig.GetConnection())
            {
                conn.Open();

                string sql = @"INSERT INTO public.clientes 
                (documento, nome, sexo, email, telefone, uf)
                VALUES (@Documento, @Nome, @Sexo, @Email, @Telefone, @UF)";

                using (var cmd = new NpgsqlCommand(sql, conn))
                {
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

        // SELECT
        public List<Cliente> Listar()
        {
            List<Cliente> lista = new List<Cliente>();

            using (var conn = _appConfig.GetConnection())
            {
                conn.Open();

                string sql = "SELECT * FROM public.clientes";

                using (var cmd = new NpgsqlCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Cliente
                        {
                            IdCliente = Convert.ToInt32(reader["idcliente"]),
                            Documento = reader["documento"].ToString(),
                            Nome = reader["nome"].ToString(),
                            Email = reader["email"].ToString(),
                            Sexo = reader["sexo"].ToString(),
                            Telefone = reader["telefone"].ToString(),
                            UF = reader["uf"].ToString()
                        });
                    }
                }
            }

            return lista;
        }


        // DELETE
        public bool Delete(int id)
        {
            using (var conn = _appConfig.GetConnection())
            {
                conn.Open();

                string sql = "DELETE FROM public.clientes WHERE idcliente = @Id";

                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Atualizar(Cliente cliente)
        {
            using (var conn = _appConfig.GetConnection())
            {
                conn.Open();

                string sql = @"UPDATE public.clientes SET
                             documento=@Documento,
                             nome=@Nome,
                             sexo=@Sexo,
                             email=@Email,
                             telefone=@Telefone,
                             uf=@UF
                             WHERE idcliente=@Id";

                

                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", cliente.IdCliente);
                    cmd.Parameters.AddWithValue("@Documento", cliente.Documento);
                    cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
                    cmd.Parameters.AddWithValue("@Sexo", cliente.Sexo);
                    cmd.Parameters.AddWithValue("@Email", cliente.Email);
                    cmd.Parameters.AddWithValue("@Telefone", cliente.Telefone);
                    cmd.Parameters.AddWithValue("@UF", cliente.UF);

                    return cmd.ExecuteNonQuery() > 0;

                }
            }
            return false;
        }

        public Cliente GetById(int id)
        {
            using (var conn = _appConfig.GetConnection())
            {
                conn.Open();

                string sql = "SELECT * FROM public.clientes WHERE idcliente = @Id";

                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Cliente
                            {
                                IdCliente = Convert.ToInt32(reader["idcliente"]),
                                Documento = reader["documento"].ToString(),
                                Nome = reader["nome"].ToString(),
                                Email = reader["email"].ToString(),
                                Sexo = reader["sexo"].ToString(),
                                Telefone = reader["telefone"].ToString(),
                                UF = reader["uf"].ToString()
                            };
                        }
                    }
                }
            }

            return null;
        }
    }
}