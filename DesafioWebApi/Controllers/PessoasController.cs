using DesafioWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DesafioWebApi.Controllers
{
    public class PessoasController : ApiController
    {
        private static DAOpessoa res = new DAOpessoa();

        // GET: api/Pessoa
        public List<Pessoa> Get() => res.retornaLista();
        
        // GET: api/Pessoa/{id}
        public Pessoa Get(int id) => res.retornaID(id);
        
        //  GET: api/Pessoas?uf={uf}
        public IEnumerable<Pessoa> Get(string uf) => res.retornaPessoasUF(uf);

        // POST: api/Pessoa
        public string Post(Pessoa dados) => res.adicionarPessoa(dados);

        // PUT: api/Pessoa/{id}
        public string Put(int id, Pessoa dados) => res.atualizarPessoa(id, dados);

        // Delete: api/Pessoa/{id}
        public string Delete(int id) => res.removerPessoa(id);
    }
}
