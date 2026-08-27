using CBTSWE2.Aula01.Entidades;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection
//Laryssa Barbosa e Isabela Salgueiro
namespace CBTSWE2.Aula01
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }

        public void Configure(IApplicationBuilder app)
        {
            var builder = new RouteBuilder(app);

            builder.MapRoute("livro/nome", LivroNome);
            builder.MapRoute("livro/tostring", LivroToString);
            builder.MapRoute("livro/autores", LivroAutores);
            builder.MapRoute("livro/ApresentarLivro", ApresentarLivro);

            var rotas = builder.Build();

            app.UseRouter(rotas);
        }

        public Task LivroNome(HttpContext context)
        {
            var livro = CriarLivro();

            return context.Response.WriteAsync(
                livro.GetName()
            );
        }

        public Task LivroToString(HttpContext context)
        {
            var livro = CriarLivro();

            return context.Response.WriteAsync(
                livro.ToString()
            );
        }

        public Task LivroAutores(HttpContext context)
        {
            var livro = CriarLivro();

            return context.Response.WriteAsync(
                livro.GetAuthorNames()
            );
        }

        public Task ApresentarLivro(HttpContext context)
        {
            var livro = CriarLivro();

            string html = $@"
                <!DOCTYPE html>
                <html lang=""pt-br"">
                <head>
                    <meta charset=""UTF-8"">
                    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">

                    <title>Biblioteca - Livro</title>

                    <style>
                        * {{
                            box-sizing: border-box;
                            margin: 0;
                            padding: 0;
                        }}

                        body {{
                            font-family: Arial, Helvetica, sans-serif;
                            background: #f2f4f7;
                            color: #333;
                            min-height: 100vh;
                        }}

                        header {{
                            background: #243447;
                            color: white;
                            padding: 25px;
                            text-align: center;
                            box-shadow: 0 3px 10px rgba(0,0,0,0.15);
                        }}

                        header h1 {{
                            font-size: 28px;
                            margin-bottom: 5px;
                        }}

                        header p {{
                            color: #d9e2ec;
                            font-size: 15px;
                        }}

                        .container {{
                            width: 90%;
                            max-width: 800px;
                            margin: 40px auto;
                        }}

                        .card {{
                            background: white;
                            border-radius: 15px;
                            padding: 35px;
                            box-shadow: 0 5px 20px rgba(0,0,0,0.10);
                        }}

                        .livro-titulo {{
                            font-size: 32px;
                            color: #243447;
                            margin-bottom: 25px;
                        }}

                        .informacoes {{
                            display: grid;
                            grid-template-columns: 1fr 1fr;
                            gap: 15px;
                            margin-bottom: 30px;
                        }}

                        .info {{
                            background: #f7f9fb;
                            padding: 18px;
                            border-radius: 10px;
                            border-left: 4px solid #243447;
                        }}

                        .info strong {{
                            display: block;
                            color: #66788a;
                            font-size: 13px;
                            text-transform: uppercase;
                            margin-bottom: 6px;
                        }}

                        .info span {{
                            font-size: 19px;
                            font-weight: bold;
                            color: #243447;
                        }}

                        .autores-titulo {{
                            font-size: 22px;
                            color: #243447;
                            margin-bottom: 15px;
                        }}

                        ul {{
                            list-style: none;
                        }}

                        li {{
                            background: #f7f9fb;
                            margin-bottom: 10px;
                            padding: 14px 18px;
                            border-radius: 8px;
                            font-size: 16px;
                        }}

                        li::before {{
                            content: ""👤"";
                            margin-right: 10px;
                        }}

                        .rotas {{
                            margin-top: 30px;
                            padding-top: 25px;
                            border-top: 1px solid #ddd;
                        }}

                        .rotas h3 {{
                            color: #243447;
                            margin-bottom: 12px;
                        }}

                        .rotas a {{
                            color: #315b7d;
                            text-decoration: none;
                            margin-right: 15px;
                            font-size: 14px;
                        }}

                        .rotas a:hover {{
                            text-decoration: underline;
                        }}

                        footer {{
                            text-align: center;
                            color: #7b8794;
                            font-size: 13px;
                            margin: 30px 0;
                        }}

                        @media (max-width: 600px) {{
                            .informacoes {{
                                grid-template-columns: 1fr;
                            }}

                            .card {{
                                padding: 25px;
                            }}

                            .livro-titulo {{
                                font-size: 26px;
                            }}
                        }}
                    </style>
                </head>

                <body>

                    <header>
                        <h1>📚 Minha Biblioteca</h1>
                        <p>Informações do livro</p>
                    </header>

                    <div class=""container"">

                        <div class=""card"">

                            <h2 class=""livro-titulo"">
                                {livro.GetName()}
                            </h2>

                            <div class=""informacoes"">

                                <div class=""info"">
                                    <strong>Preço</strong>
                                    <span>R$ {livro.GetPrice():F2}</span>
                                </div>

                                <div class=""info"">
                                    <strong>Quantidade</strong>
                                    <span>{livro.GetQty()}</span>
                                </div>

                            </div>

                            <h3 class=""autores-titulo"">
                                Autores
                            </h3>

                            <ul>
                                <li>{livro.GetAuthors()[0].GetName()}</li>
                                <li>{livro.GetAuthors()[1].GetName()}</li>
                            </ul>

                            <div class=""rotas"">
                                <h3>Outras informações</h3>

                                <a href=""/livro/nome"">Nome</a>
                                <a href=""/livro/autores"">Autores</a>
                                <a href=""/livro/tostring"">Dados completos</a>
                            </div>

                        </div>

                        <footer>
                            Aplicação desenvolvida em ASP.NET Core
                        </footer>

                    </div>

                </body>
                </html>";

            context.Response.ContentType = "text/html; charset=utf-8";

            return context.Response.WriteAsync(html);
        }

        private Book CriarLivro()
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

            return new Book(
                "Livro de Teste",
                autores,
                49.90,
                10
            );
        }
    }
}