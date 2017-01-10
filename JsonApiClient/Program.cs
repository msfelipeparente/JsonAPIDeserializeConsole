/// Autor:         Felipe Parente
/// Data:          05/01/2017
/// Description:   Consumindo Json Via Console utilizando RestSharp ou JSON.NET
using System;

namespace JsonApiClientConsole
{
    class Program
    {
        static void Main(string[] args)
        {



            var quantidade = 0;
            Console.Title = "DESERIALIZAÇÃO DE JSON DataSet DENTRO DE UM OBJETO";
            Console.CursorVisible = true;
            Console.WriteLine("Você deseja criar quantas requisições? \n");

            // quantidade = int.Parse(Console.ReadLine());
            var teste = Console.ReadLine();
            if (!int.TryParse(teste, out quantidade))
            {
                Console.WriteLine("Digite um número inteiro!");
                teste = Console.ReadLine();
            }
            else
            {
                quantidade = int.Parse(teste);
            }
            for (int i = 0; i < quantidade; i++)
            {
                var url = "";

                Console.WriteLine("\n Digite a URL: \n Exemplo:http://localhost:8080/WebApplication3/teste5.json \n");
                url = Console.ReadLine(); ;

                //Defina a extensão/diretório final
                //Console.WriteLine("Digite o Diretório / Nome do Arquivo : \n");
                var dir = "";
                //dir = Console.ReadLine();

                // Chama o método GetPost da Classe Vagas
                Vagas.VagasJson(url, dir);
            }



            //Mantém o console aberto

            Console.WriteLine("\n Pressione ENTER para finalizar o aplicativo! \n");
            Console.ReadLine();
        }
    }
}
