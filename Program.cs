//see https://aka.ns/new-console-template for moreinformation
using Microsoft.AspNetCore.Hosting;
using CBTSWE2.Aula01.Negocio;
using CBTSWE2.Aula01.Repositorio;
using CBTSWE2.Aula01;
using CBTSWE2.Aula01.Testes;

//Laryssa Barbosa e Isabela Salgueiro

var _repo = new LivroRepositorioCSV();

ImprimeLista(_repo.ParaLer);
ImprimeLista(_repo.Lendo);
ImprimeLista(_repo.Lidos);

TesteBook.Executar();

static void ImprimeLista(ListaDeLeitura lista)
{
    Console.WriteLine(lista);
}

IWebHost host = new WebHostBuilder()
    .UseKestrel()
    .UseStartup<Startup>()
    .Build();

host.Run();