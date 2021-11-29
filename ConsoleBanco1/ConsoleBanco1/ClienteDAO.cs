using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBanco1
{
    class ClienteDAO
    {
        private Banco db;

        public void Insert(Cliente cliente)
        {
            var strQuery = "";
            strQuery += "insert into tbl_Cliente(nm_Cliente, ds_Email)";
            strQuery += string.Format("values('{0}','{1}')", cliente.nm_Cliente, cliente.ds_Email) ;

            using (db = new Banco())
            {
                db.ExecutaComando(strQuery);
            }
        }
        public void Atualizar(Cliente cliente)
        {
            var strQuery = "";
            strQuery += "UPDATE tbl_Cliente SET ";       
            strQuery += string.Format(" nm_Cliente = '{0}', ", cliente.nm_Cliente);
            strQuery += string.Format(" ds_Email = '{0}' ", cliente.ds_Email);
            strQuery += string.Format(" WHERE cd_Cliente = {0}", cliente.cd_Cliente);


            using (db = new Banco())
            {
                db.ExecutaComando(strQuery);
            }
        }
        public void Excluir (Cliente cliente)
        {
            using (db = new Banco())
            {
                var strQuery = string.Format("DELETE FROM tbl_Cliente WHERE cd_Cliente = {0}", cliente.cd_Cliente);
                db.ExecutaComando(strQuery);
            }
        }
        public List<Cliente> Listar()
        {
            using (db = new Banco())
            {
                var strQuery = "SELECT * FROM tbl_Cliente;";
                var retorno = db.RetornaComando(strQuery);
                return ListaDeCliente(retorno);
            }
        }
        public List<Cliente> ListaDeCliente(MySqlDataReader retorno)
        {
            var clientes = new List<Cliente>();
            while (retorno.Read())
            {
                var TempCliente = new Cliente()
                {
                    cd_Cliente = int.Parse(retorno["cd_Cliente"].ToString()),
                    nm_Cliente = retorno["nm_Cliente"].ToString(),
                    ds_Email = retorno["ds_Email"].ToString(),
                };
                    clientes.Add(TempCliente);
            }
                    retorno.Close();
                    return clientes;
        }
        public void Salvar(Cliente cliente)
        {
            if (cliente.cd_Cliente > 0)
            {
                Atualizar(cliente);
            }
            else
            {
                Insert(cliente);
            }
        }
    }
}
