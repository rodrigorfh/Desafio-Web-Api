using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesafioWebApi.Models
{
    public class DAOpessoa
    {
        List<Pessoa> pessoas = new List<Pessoa>();
        static int i=1;
        public DAOpessoa()
        {
            pessoas.Add(new Pessoa(gerarCod(), "Joao", "22830123093", "BH"));
            pessoas.Add(new Pessoa(gerarCod(), "Maria", "22830123093", "GO"));
            pessoas.Add(new Pessoa(gerarCod(), "Jose", "22830123093", "GO"));
        }

        public static int gerarCod()
        {
            return i++;
        }

        // Retorna todas as pessoas
        public List<Pessoa> retornaLista() => pessoas;

        // Retorna pessoa de ID específico 
        public Pessoa retornaID(int id) => pessoas.Where(x => x.cod == id).FirstOrDefault();

        // Retorna todas as pessoas filtrado por UF
        public IEnumerable<Pessoa> retornaPessoasUF(string uf) => pessoas.Where(x => x.uf.Contains(uf.ToUpper()));

        // Remove Pessoa com ID 
        public string removerPessoa(int cod)
        {

            var item = pessoas.Single(x => x.cod == cod);
            if (item == null)
            {
                return "Nao achei porra!";
            }
            pessoas.Remove(item);
            return "COD: " + cod + " removido";
        }

        public string adicionarPessoa(Pessoa dados)
        {
            mensagem msg = confereDados(dados);

            if (!msg.erro)        
                pessoas.Add(new Pessoa(gerarCod(), dados.nome, dados.cpf, dados.uf));

            return msg.msg;
        }



        // Atualiza dados de um usuário filtrando pelo ID
        public string atualizarPessoa(int cod, Pessoa dados)
        {
            mensagem msg = confereDados(dados);

            if (!msg.erro)
            {
                Pessoa pessoa;
                try
                {
                    pessoa = pessoas.Single(x => x.cod == cod);
                }
                catch
                {
                    return "Pessoa não encontrada";
                }
               
                pessoa.nome = dados.nome;
                pessoa.cpf = dados.cpf;
                pessoa.uf = dados.uf;

            }

            return msg.msg;
        }


        // Valida os dados e envia
        public mensagem confereDados(Pessoa dados)
        {
            string uf = dados.uf.ToString();
            string cpf = dados.cpf.ToString();

            if (!isUF(uf))
            {
                return new mensagem(true, "Falha UF");
            }

            if (!IsCpf(cpf))
            {
                return new mensagem(true, "Falha CPF");
            }
        
            return new mensagem(false, "Salvo"); ;
        }

        //Confere se a UF existe
        private bool isUF(string value)
        {
            string[] ufBrasil = {
                                    "AC", "AL", "AM", "AP", "BA", "CE", "DF", "ES", "GO",
                                    "MA", "MG", "MS", "MT", "PA", "PB", "PE", "PI", "PR",
                                    "RJ", "RN", "RO", "RR", "RS", "SC", "SE", "SP", "TO"
                                };

            return ufBrasil.Any(value.ToUpper().Contains) ? true : false;
        }

        // Valida CPF
        private static bool IsCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }

    }
}
