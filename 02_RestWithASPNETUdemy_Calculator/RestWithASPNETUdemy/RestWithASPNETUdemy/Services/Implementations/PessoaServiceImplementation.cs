using RestWithASPNETUdemy.Model;
using System;
using System.Collections.Generic;
using System.Threading;

namespace RestWithASPNETUdemy.Services.Implementations
{
    public class PessoaServiceImplementation : IPessoaService
    {
        private volatile int count;

        public Pessoa Criar(Pessoa pessoa)
        {
            return pessoa;
        }


        public Pessoa Atualizar(Pessoa pessoa)
        {
            return pessoa;
        }

        public Pessoa BuscaPorId(long id)
        {
            return new Pessoa
            {
                Id = 1,
                PrimeiroNome = "Paulo",
                SobreNome = "Ricardo",
                Endereco = "Sao Paulo - SP - Brasil",
                Genero = "M"
            };
        }

       

        public List<Pessoa> ListaTodos()
        {
           List<Pessoa> pessoas = new List<Pessoa>();
            for(int i = 0; i < 8; i++)
            {
                Pessoa pessoa = MockPessoa(i);
                pessoas.Add(pessoa);
            }

            return pessoas;       
        }

        private Pessoa MockPessoa(int i)
        {
            return new Pessoa
            {
                Id = Incrementa(),
                PrimeiroNome = "Pessoa Nome" + i,
                SobreNome = "Pessoa Sobrenome" + i,
                Endereco = "Endereco " + i,
                Genero = "MM" + i
            };
        }

        private long Incrementa()
        {
            return Interlocked.Increment(ref count);
        }

        public void Remover(long id)
        {
            return ;
        }
    }
}
