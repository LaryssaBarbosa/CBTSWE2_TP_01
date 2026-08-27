using CBTSWE2.Aula01.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

\\ Laryssa Barbosa Soares e Isabela Salgueiro
namespace CBTSWE2.Aula01.Testes
{
    public class TesteBook
    {
        public static void Executar()
        {
            Author autor1 = new Author(
                "Machado de Assis",
                "machado@email.com",
                'M'
            );

            Author autor2 = new Author(
                "José de Alencar",
                "jose@email.com",
                'M'
            );

            Author[] autores = { autor1, autor2 };

            Book livro = new Book(
                "Livro de Teste",
                autores,
                49.90,
                10
            );

            Console.WriteLine(livro.GetName());
            Console.WriteLine(livro.GetAuthors());
            Console.WriteLine(livro.GetPrice());

            livro.SetPrice(59.90);
            Console.WriteLine(livro.GetPrice());

            Console.WriteLine(livro.GetQty());

            livro.SetQty(20);
            Console.WriteLine(livro.GetQty());

            Console.WriteLine(livro.ToString());

            Console.WriteLine(livro.GetAuthorNames());
        }
    }
}
