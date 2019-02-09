using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesafioWebApi.Models
{
    public class mensagem
    {
        public mensagem(bool erro, string msg)
        {
            this.erro = erro;
            this.msg = msg;
        }
        public bool erro { get; set; }
        public string msg { get; set; }
    }
}