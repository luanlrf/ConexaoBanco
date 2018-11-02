using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
//provedores do OleDb
/* Microsoft.Jet.OLEDB 4.0 = OLE DB Provider for Microsoft Jet
 * MSDAORA = Microsoft OLE DB Provider para Oracle
 * SQLOLEDB= Microsoft Ole DB para SQL Server
 * 
 */
namespace BancoDadosExemplo01
{
    class Program
    {
        static void Main(string[] args)
        {

            {
                // criar conexao com banco de dados
                OleDbConnection conexao = new OleDbConnection(@"Provider=SQLOLEDB;Server=.\SQLEXPRESS;Database=mercado; User id =sa; pwd=123456;");

                //instrucao sql
                OleDbCommand sql = new OleDbCommand("select*from dbo.TBL_mercado", conexao);
                



                try
                {
                    conexao.Open();// abre a conexao
                    Console.WriteLine("conectado nessa porra");
                    //criando obj para ler dados
                    OleDbDataReader lendoDados = sql.ExecuteReader();
                    Console.WriteLine("Listando os dados na tabela : ");
                    Console.ReadKey();

                    while (lendoDados.Read())
                    {
                        Console.WriteLine(lendoDados.GetString(1)+ lendoDados.GetString(2));
                        Console.ReadKey();
                    }
                }
                catch (OleDbException erro)
                {
                    Console.WriteLine("erro aconteceu" + erro);
                    Console.ReadKey();
                }



            }
        }
    }
}

