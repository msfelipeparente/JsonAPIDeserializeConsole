using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace JsonApiClientConsole
{
    class Vagas
    {
        public static async void VagasJson(String url, String dir)
        {

            //Cria o Cliente
            var client = new RestClient(url);

            //Cria a Requisição Web
            var request = new RestRequest(dir, Method.GET);

            // Executa a requisição
            IRestResponse response = client.Execute(request);

            // Defini a variável content como conteúdo da resposta da requisição
            var content = response.Content;

            // Chamei o método MostrarVagas utilizando a variavel content como o parâmetro 
            MostrarVagas(content);

        }

        public static async void MostrarVagas(String content)
        {

            //Deserializei o DataSet
            DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(content);

            // Instência um novo objeto
            VagaClasse vaga = new VagaClasse();

            // Define um novo DataTable que será == a tabela pessoa do DataSet Deserializado
            DataTable dataTable = dataSet.Tables["pessoa"];

            // Mostra a quantidade de Linhas na tabela
            //Console.WriteLine(dataTable.Rows.Count);



            // Defino o valor inicial
            int quant = 0;
            int max = 294;

            int max2 = max + 1;

            Console.WriteLine("\n ");

            // Para cada Linha da tabela ele executa as ações
            foreach (DataRow row in dataTable.Rows)
            {
                // Defino o máximo de respostas a serem buscadas
                // Para mostrar todos, retire os ifs

                // Seta os atributos do meu objeto(SET)
                vaga.name = row["name"].ToString();
                vaga.age = Convert.ToInt32(row["age"].ToString());
                vaga.email = row["email"].ToString();

                // Substitui os netbook.com para felipe.com.br no email
                vaga.email = vaga.email.Replace("netbook.com", "felipe.com.br");

                // Quantidade menor ou igual a 2 e que comecem com A
                if (quant <= max && vaga.name.StartsWith("A") && vaga.email.Contains("@"))
                {

                    // Verifica se é jovem, adulto ou idoso
                    if (vaga.age < 30)
                    {
                        vaga.status = "Jovem";
                    }
                    else
                    {
                        if (vaga.age >= 35)
                        {
                            vaga.status = "Idoso";
                        }
                        else
                        {
                            vaga.status = "Adulto";
                        }
                    }

                    // Seta os atributos do meu objeto(SET)

                    vaga.age = int.Parse(row["age"].ToString());

                    // Mostra os atributos do meu objeto (GET)
                    Console.WriteLine(vaga.name.ToUpper() + "  -   " + vaga.email + "  -   " + vaga.age + "  -   " + vaga.status);

                    /*                   
                     *                     PODEMOS FAZER TUDO SEM INSTÂNCIAR NENHUM OBJETO
                     *
                     *      Console.WriteLine(row["name"] + " - " + row["age"] +" - " + row["email"]);
                    */


                    // Incrementa a variavel quant

                    quant++;
                }

            }
            Console.WriteLine("\n Mostrando   " + quant + "   de " + max2);
        }

    }
}