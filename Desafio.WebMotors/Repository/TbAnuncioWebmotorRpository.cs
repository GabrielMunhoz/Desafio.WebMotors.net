using Dapper;
using Desafio.WebMotors.Data;
using System.Data.SqlClient;

namespace Desafio.WebMotors.Repository
{
    public class TbAnuncioWebmotorRpository : ITbAnuncioWebmotor
    {
        IConfiguration _configuration;
        public TbAnuncioWebmotorRpository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").
                GetSection("testeWebMotors").Value;
            return connection;
        }
        public int Add(Data.TbAnuncioWebmotor tbAnuncioWebmotor)
        {
            var connectionString = this.GetConnection();
            int count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "INSERT INTO [tb_AnuncioWebmotors]([marca],[modelo],[versao],[ano],[quilometragem],[observacao]) VALUES(@Marca, @Modelo, @Versao, @Ano, @Quilometragem, @Observacao) SELECT CAST(SCOPE_IDENTITY() as INT); ";
                    count = con.Execute(query, tbAnuncioWebmotor);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return count;
            }
        }

        public int Delete(int Id)
        {
            var connectionString = this.GetConnection();
            var count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "DELETE FROM tb_AnuncioWebmotors WHERE id =" + Id;
                    count = con.Execute(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return count;
            }
        }

        public int Edit(Data.TbAnuncioWebmotor tbAnuncioWebmotor)
        {
            var connectionString = this.GetConnection();
            var count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "UPDATE tb_AnuncioWebmotors SET Marca=@Marca, Modelo=@Modelo, Versao=@Versao,Ano= @Ano, Quilometragem=@Quilometragem, Observacao=@Observacao WHERE ID = " + tbAnuncioWebmotor.Id;
                    count = con.Execute(query, tbAnuncioWebmotor);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return count;
            }
        }

        public List<Data.TbAnuncioWebmotor> GetAll()
        {
            var connectionString = this.GetConnection();
            List<Data.TbAnuncioWebmotor> anuncios = new List<Data.TbAnuncioWebmotor>();
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM tb_AnuncioWebmotors";
                    anuncios = con.Query<Data.TbAnuncioWebmotor>(query).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return anuncios;
            }
        }

        public Data.TbAnuncioWebmotor GetTbAnuncioWebmotor(int id)
        {
            var connectionString = this.GetConnection();
            Data.TbAnuncioWebmotor anuncios = new Data.TbAnuncioWebmotor();
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM tb_AnuncioWebmotors where id = "+id;
                    anuncios = con.Query<Data.TbAnuncioWebmotor>(query).First();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return anuncios;
            }
        }
    }
}
