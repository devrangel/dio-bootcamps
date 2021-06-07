using catalogo_jogos_api.Entities;
using catalogo_jogos_api.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace catalogo_jogos_api.Repositories
{
    public class JogoSqlServerRepository : IJogoRepository
    {
        private readonly SqlConnection _sqlConnection;

        public JogoSqlServerRepository(IConfiguration configuration)
        {
            _sqlConnection = new SqlConnection(configuration.GetConnectionString("Database"));
        }

        public async Task<List<Jogo>> Get(int pagina, int quantidade)
        {
            var jogos = new List<Jogo>();

            var comando = $"select * from Jogos order by id offset {((pagina - 1) * quantidade)} rows fetch next {quantidade} rows only";

            await _sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comando, _sqlConnection);
            SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

            while(sqlDataReader.Read())
            {
                jogos.Add(new Jogo
                {
                    Id = Guid.Parse((string)sqlDataReader["Id"]),
                    Nome = (string)sqlDataReader["Nome"],
                    Produtora = (string)sqlDataReader["Produtora"],
                    Preco = Convert.ToDouble(sqlDataReader["Preco"]),
                });
            }

            await _sqlConnection.CloseAsync();

            return jogos;
        }
        
        public async Task<Jogo> GetById(Guid id)
        {
            Jogo jogo = null;

            var comando = $"select * from Jogos where Id = '{id}'";

            await _sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comando, _sqlConnection);
            SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

            while(sqlDataReader.Read())
            {
                jogo = new Jogo
                {
                    Id = Guid.Parse((string)sqlDataReader["Id"]),
                    Nome = (string)sqlDataReader["Nome"],
                    Produtora = (string)sqlDataReader["Produtora"],
                    Preco = Convert.ToDouble(sqlDataReader["Preco"]),
                };
            }

            await _sqlConnection.CloseAsync();

            return jogo;
        }
        
        public async Task<List<Jogo>> GetByName(string nome, string produtora)
        {
            var jogos = new List<Jogo>();

            var comando = $"select * from Jogos where Nome = '{nome}' and Produtora = '{produtora}'";

            await _sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comando, _sqlConnection);
            SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

            while (sqlDataReader.Read())
            {
                jogos.Add(new Jogo
                {
                    Id = Guid.Parse((string)sqlDataReader["Id"]),
                    Nome = (string)sqlDataReader["Nome"],
                    Produtora = (string)sqlDataReader["Produtora"],
                    Preco = Convert.ToDouble(sqlDataReader["Preco"]),
                });
            }

            await _sqlConnection.CloseAsync();

            return jogos;
        }
        
        public async Task Post(Jogo jogo)
        {
            var comando = $"insert Jogos (Id, Nome, Produtora, Preco) values ('{jogo.Id}', '{jogo.Nome}', '{jogo.Produtora}', {jogo.Preco.ToString().Replace(",", ".")})";

            await _sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comando, _sqlConnection);
            sqlCommand.ExecuteNonQuery();

            await _sqlConnection.CloseAsync();
        }
        
        public async Task Put(Jogo jogo)
        {
            var comando = $"update Jogos set Nome = '{jogo.Nome}', Produtora = '{jogo.Produtora}', Preco = {jogo.Preco.ToString().Replace(",", ".")} where Id = '{jogo.Id}'";

            await _sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comando, _sqlConnection);
            sqlCommand.ExecuteNonQuery();

            await _sqlConnection.CloseAsync();
        }
        
        public async Task Delete(Guid id)
        {
            var comando = $"delete from Jogos where Id = '{id}'";

            await _sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comando, _sqlConnection);
            sqlCommand.ExecuteNonQuery();

            await _sqlConnection.CloseAsync();
        }

        public void Dispose()
        {
            _sqlConnection?.Close();
            _sqlConnection?.Dispose();
        }
    }
}
