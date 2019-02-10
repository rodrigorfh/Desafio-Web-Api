using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesafioWebApi.Models
{

    public class Pessoa
    {
        public Pessoa(int cod, string nome, string cpf, string uf)
        {
            this.cod = cod;
            this.nome = nome;
            this.cpf = cpf;
            this.uf = uf.ToUpper(); 
            data = DateTime.Now;
        }
        
        public int cod { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public string uf { get; set; }
        public DateTime data { get; set; }
    }
}


