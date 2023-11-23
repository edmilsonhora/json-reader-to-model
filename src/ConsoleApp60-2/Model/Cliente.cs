using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp60_2.Model
{
    internal class Cliente
    {
        public Cliente()
        {
            
        }

        public Cliente(string nome, string email, string dataNascimento, string rg, string cpf)
        {
            Nome = nome;
            Email = email;
            DataNascimento = Convert.ToDateTime(dataNascimento);
            Rg = rg;
            Cpf = cpf;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }        
        public DateTime DataNascimento { get { return Convert.ToDateTime(Data_Nasc); } set { Data_Nasc = value.ToString(); } }
        public string Data_Nasc;
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string UsuarioInclusao { get; set; }
        public string UsuarioAlteracao { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataAlteracao { get; set; }
        public bool Alterado { get; set; }

        public void AtualizaDataAlteracao(string user)
        {
            if(Id == 0)
            {
                DataInclusao = DateTime.Now;
                UsuarioInclusao = user;
            }

            DataAlteracao = DateTime.Now;
            UsuarioAlteracao = user;
        }

       
    }
}
