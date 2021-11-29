using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBanco1
{
    class Program
    {
        static void Main(string[] args)
        {
            var Banco = new Banco(); //CHAMANDO BANCO 
            var ClienteDAO = new ClienteDAO();
            var cliente = new Cliente();

    /*        Console.WriteLine("Digite o nome do Cliente");
            cliente.nm_Cliente = Console.ReadLine();
            Console.WriteLine("Digite o e-mail do Cliente");
           cliente.ds_Email = Console.ReadLine();

            cliente.cd_Cliente = 9;
            ClienteDAO.Excluir(cliente); */

            var leitor = ClienteDAO.Listar();

            foreach (var clientes in leitor)
            {
                Console.WriteLine("Id: {0}, Nome: {1}, Email: {2}", clientes.cd_Cliente, clientes.nm_Cliente, cliente.ds_Email);
            }
            Console.ReadLine();
        }

        /* public void InsertCli()
         {
             Console.WriteLine("Digite o nome do Cliente");
             string vNome = Console.ReadLine();
             Console.WriteLine("Digite o e-mail do Cliente");
             string vEmail = Console.ReadLine();

             string stringInsereCli = string.Format("insert into tbl_Cliente(nm_Cliente,ds_Email)" + "values('{0}','{1}');", vNome, vEmail);

             MySqlCommand comandoInsert = new MySqlCommand(stringInsereCli, conexao);
             comandoInsert.ExecuteNonQuery();

             MySqlCommand comandoSelect = new MySqlCommand("select * from tbl_Cliente", conexao);
             MySqlDataReader leitor = comandoSelect.ExecuteReader();

             while (leitor.Read())
             {
                 Console.WriteLine("Id: {0}, Nome: {1}, Email: {2}", leitor["cd_Cliente"], leitor["nm_Cliente"], leitor["ds_Email"]);
             }
             Console.ReadLine();
         } */
        /*   public void SelecionaCli()
           {

               string strSelecionaCli = "Select * from tbl_Cliente"; //String para guardar o comando SQL 
               MySqlCommand comando = new MySqlCommand(strSelecionaCli, conexao); //Comando SQL
               MySqlDataReader leitor = comando.ExecuteReader(); // executa um SELECT e retorna um bloco de Registros
               Console.ReadLine();
               while (leitor.Read())
               {
                   Console.WriteLine("Id: {0}, Nome: {1}, Email: {2}", leitor["cd_Cliente"], leitor["nm_Cliente"], leitor["ds_Email"]);
               };
               Console.ReadLine();
           } */

        /*    public void UpdateCli()
            {
                MySqlCommand comando = new MySqlCommand("Update tbl_Cliente set nm_Cliente = 'Roberta' where cd_Cliente = 1", conexao);
                comando.ExecuteNonQuery();

                comando.CommandText = "Select * from tbl_Cliente";
                MySqlDataReader leitor = comando.ExecuteReader();

                while (leitor.Read())
                {
                    Console.WriteLine("Id: {0}, Nome: {1}, Email: {2}", leitor["cd_Cliente"], leitor["nm_Cliente"], leitor["ds_Email"]);
                }
                Console.ReadLine(); //SLIDE 37
            }*/

        /*    public void DeleteCli()
            {
                MySqlCommand comandoApagar = new MySqlCommand("Delete from tbl_Cliente where cd_Cliente=1", conexao);
                comandoApagar.ExecuteNonQuery();

                MySqlCommand comando = new MySqlCommand("Select * from tbl_Cliente", conexao);
                MySqlDataReader leitor = comando.ExecuteReader();

                while (leitor.Read())
                {
                    Console.WriteLine("Id: {0}, Nome: {1}, Email: {2}", leitor["cd_Cliente"], leitor["nm_Cliente"], leitor["ds_Email"]);
                };
                Console.ReadLine();
            }*/
    }
}
