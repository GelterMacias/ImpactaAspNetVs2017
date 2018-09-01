using Pessoal.Dominio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pessoal.Repositorios.SqlServer
{
    public class TarefaRepositorio
    {
        private string stringConexao;

        public TarefaRepositorio()
        {
            stringConexao = ConfigurationManager.ConnectionStrings["pessoalConnectionString"].ConnectionString;
        }

        public TarefaRepositorio(string stringConexao)
        {
            this.stringConexao = stringConexao;
        }

        public int Inserir(Tarefa tarefa)
        {
            using (var conexao = new SqlConnection(stringConexao))
            {
                conexao.Open();

                using (var comando = new SqlCommand("TarefaInserir",conexao)) //"TarefaInserir" - Nome da Store Procedure no SQL
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    //Mapeamento dos campos - Pega a Propert do objeto e tranforma em um parâmetro da SP
                    comando.Parameters.AddRange(Mapear(tarefa).ToArray()); //Está esperando vetor, não list - Usar ToArray par converter

                    return (int)comando.ExecuteScalar(); //(int) para converter de objeto para inteiro, nosso tipo de dado
                    //ExecuteScalar traz um único campo | ExecuteReader traz a tabela | ExecuteNonQuery
                }
            }
        }

        public void Atualizar(Tarefa tarefa)
        {
            using (var conexao = new SqlConnection(stringConexao))
            {
                conexao.Open();

                using (var comando = new SqlCommand("TarefaAtualizar", conexao)) 
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddRange(Mapear(tarefa).ToArray());

                    comando.ExecuteNonQuery();
                                        
                }
            }
        }

        public List<Tarefa> Selecionar()
        {
            var tarefas = new List<Tarefa>();

            using (var conexao = new SqlConnection(stringConexao))
            {
                conexao.Open();

                using (var comando = new SqlCommand("TarefaSelecionar", conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    using (var registro = comando.ExecuteReader())
                    {
                        while (registro.Read())
                        {
                            tarefas.Add(Mapear(registro)); //Mapeamento reverso - Campo do BD com Property do objeto
                        }
                    }

                }
            }


            return tarefas;
        }

        public Tarefa Selecionar(int id)
        {
            Tarefa tarefa = null; //Precaução para o caso em que o Select não trouxer registro (Ex: Id excluido)

            using (var conexao = new SqlConnection(stringConexao))
            {
                conexao.Open();

                using (var comando = new SqlCommand("TarefaSelecionar", conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Id",id);

                    using (var registro = comando.ExecuteReader())
                    {
                        if (registro.Read())
                        {
                            tarefa = Mapear(registro); //Mapeamento reverso - Campo do BD com Property do objeto
                        }
                    }

                }
            }


            return tarefa;
        }


        public void Excluir(int id)
        {
            using (var conexao = new SqlConnection(stringConexao))
            {
                conexao.Open();

                using (var comando = new SqlCommand("TarefaExcluir", conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@Id",id);

                    comando.ExecuteNonQuery();

                }
            }
        }


        private Tarefa Mapear(SqlDataReader registro)
        {
            var tarefa = new Tarefa();

            tarefa.Concluida = Convert.ToBoolean(registro["Concluida"]);
            tarefa.Id = Convert.ToInt32(registro["Id"]);
            tarefa.Nome = registro["Nome"].ToString();
            //tarefa.Observacoes = registro["Observacoes"].ToString(); //Não pode usar cast pq pode retornar null, então gera erro
            //tarefa.Observacoes = registro["Observacoes"]?.ToString(); //Novidade C#4.7 - o ? interrompe a conversão se for null e devolve o null
            tarefa.Observacoes = Convert.ToString(registro["Observacoes"]);
            tarefa.Prioridade = (Prioridade)registro["Prioridade"];

            return tarefa;
        }

        //private SqlParameter[] Mapear(Tarefa tarefa) //[] simbolo de vetor - tem que especificar a quantidade de columas
        private List<SqlParameter> Mapear(Tarefa tarefa) //List<> tem o tamanho automático 
        {
            var parametros = new List<SqlParameter>();

            if (tarefa.Id > 0)
            {
                parametros.Add(new SqlParameter("@Id", tarefa.Id));
            }

            parametros.Add(new SqlParameter("@Nome",tarefa.Nome));
            parametros.Add(new SqlParameter("@Prioridade", tarefa.Prioridade));
            parametros.Add(new SqlParameter("@Concluida", tarefa.Concluida));
            parametros.Add(new SqlParameter("@Observacoes", tarefa.Observacoes));

            return parametros;
        }
    }
}
