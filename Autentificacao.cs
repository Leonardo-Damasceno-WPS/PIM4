using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIM
{
    internal class Autentificacao
    {
        static string usuario;
        static string senha;

        public static void login(string leonardo, string leonardoD)
        {
            usuario = leonardo;
            senha = leonardoD;
        }
        public static void logout()
        {
            usuario = null;
            senha = null;
        }

        public static string getusuario()
        {
            return "Usuario: " + usuario + "\nSenha: " + senha;

        }
    }
}
