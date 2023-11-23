using ConsoleApp60_2.Context;
using ConsoleApp60_2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp60_2.Repository
{
    internal class ClienteRepository : IClienteRepository
    {
        private readonly MyContext _context;
        public ClienteRepository(MyContext context)
        {
            this._context = context;
        }

        public List<Cliente> ObterPorNome(string nome)
        {
            return _context.Set<Cliente>().Where(p => p.Nome.StartsWith(nome)).ToList();
        }

        public Cliente ObterPorCpf(string cpf)
        {
            return _context.Set<Cliente>().Where(p => p.Cpf == cpf).FirstOrDefault();
        }

        public Cliente ObterPorRg(string rg)
        {
            return _context.Set<Cliente>().Where(p => p.Rg == rg).FirstOrDefault();
        }

        public void Incluir(Cliente cliente)
        {
           _context.Set<Cliente>().Add(cliente);
        }
    }

    internal interface IClienteRepository
    {
        List<Cliente> ObterPorNome(string nome);
        Cliente ObterPorCpf(string cpf);
        Cliente ObterPorRg(string rg);
        void Incluir(Cliente cliente);
    }
}
