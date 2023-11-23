using ConsoleApp60_2.Context;
using ConsoleApp60_2.Model;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ConsoleApp60_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            for (int i = 0; i < 4; i++)
            {
                Executar(i);
            }


            Console.WriteLine("Concluido");


        }

        //static Cliente Obter(string linha)
        //{
        //    var dados = linha.Split(";");
        //    var nome = dados[0];
        //    var cpf = dados[1];
        //    var rg = dados[2];
        //    var dataNascimento = dados[3];
        //    var email = dados[4];

        //    if (nome == "nome") return null;

        //    return new Cliente(nome, email, dataNascimento, rg, cpf);
        //}

        static void Executar(int numero)
        {
            List<Cliente> list = new List<Cliente>();

            var stream = File.OpenRead(@"c:/Testes/data.json");

            using (var reader = new StreamReader(stream))
            {
                string json = reader.ReadToEnd();
                list = JsonConvert.DeserializeObject<List<Cliente>>(json);

                //while (!reader.EndOfStream)
                //{
                //    var linha = reader.ReadLine();
                //    var cli = Obter(linha);
                //    if (cli != null)
                //    {
                //        list.Add(cli);
                //    }
                //}
            }

            UnitOfWork unitOfWork = new UnitOfWork();

            foreach (var cli in list)
            {
                var c = unitOfWork.Clientes.ObterPorCpf(cli.Cpf);
                if (c != null)
                {
                    c.DataNascimento = c.DataNascimento.AddDays(1);
                }

                var cl = unitOfWork.Clientes.ObterPorRg(cli.Rg);
                if (cl != null)
                {
                    cl.Alterado = true;
                }

               
                unitOfWork.Clientes.Incluir(cli);
                unitOfWork.Save();
            }

            Console.WriteLine($"Execução: {numero}");
        }
    }
}