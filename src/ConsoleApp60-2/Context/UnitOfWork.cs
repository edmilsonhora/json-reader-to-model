using ConsoleApp60_2.Model;
using ConsoleApp60_2.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp60_2.Context
{
    internal class UnitOfWork
    {
        MyContext _context;
        public UnitOfWork()
        {
            _context = new MyContext();
        }

        public int Save()
        {
            var contextLocal = _context;
            foreach (var entry in contextLocal.ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                {
                    var entity = entry.Entity as Cliente;
                    if (entity != null) entity.AtualizaDataAlteracao("Usuario");
                }
            }

            return contextLocal.SaveChanges();

        }

        private IClienteRepository _clientes;
        public IClienteRepository Clientes
        {
            get
            {

                //if(_context == null)
                //{
                //    _context = new MyContext();
                //}

                if (_clientes == null) _clientes = new ClienteRepository(_context);
                return _clientes;
            }
        }
    }
}
