using System;
using series.classes;

namespace series
{
    class Program
    {
        static AnimeRepositorio repositorio = new AnimeRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcao();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarAnime();
                        break;
                    case "2":
                        InserirAnime();
                        break;
                    case "3":
                        AtualizarAnime();
                        break;
                    case "4":
                        ExcluirAnime();
                        break;
                    case "5":
                        VisualizarAnime();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();

                }
                opcaoUsuario = ObterOpcao();
            }
            Console.WriteLine("Obrigado por utilizar nosso serviço");
            Console.ReadLine();
        }

        private static void ListarAnime()
        {
            Console.WriteLine("Listar Animes");

            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum Anime encontrado");
                return;
            }

            foreach (var anime in lista)
            {
                if (anime.Excluido != true)
                {
                    Console.WriteLine("#ID {0}: - {1}", anime.retornaId(), anime.retornaTitulo());
                }
            }
        }

        private static void InserirAnime()
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o genêro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título do Anime");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de inicio do Anime");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição do anime");
            string entradaDescricao = Console.ReadLine();

            Anime novoAnime = new Anime(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        descricao: entradaDescricao,
                                        ano: entradaAno);
            repositorio.Insere(novoAnime);

        }

        private static void AtualizarAnime()
        {
            Console.WriteLine("Digite o ID do Anime: ");
            int indiceAnime = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
             Console.WriteLine("Digite o genêro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título do Anime");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de inicio do Anime");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição do anime");
            string entradaDescricao = Console.ReadLine();

            Anime atualizaAnime = new Anime(id: indiceAnime,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        descricao: entradaDescricao,
                                        ano: entradaAno);

            repositorio.Atualiza(indiceAnime,atualizaAnime);
        }

        private static void ExcluirAnime()
        {
            Console.WriteLine();
            Console.WriteLine("Digite o id do Anime: ");
            int indiceAnime = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Tem certeza que deseja EXCLUIR esse Anime: digite Y | N ");
            string resposta = Console.ReadLine();

            if(resposta.ToUpper() == "Y" )
            {
                repositorio.Exclui(indiceAnime);
                Console.WriteLine();
                Console.WriteLine("------------- ANIME EXCLUIDO ---------------");
                Console.WriteLine();
            }
        }

        private static void VisualizarAnime()
        {
            Console.WriteLine();
            Console.WriteLine("Digite o id do Anime: ");
            int indiceAnime = int.Parse(Console.ReadLine());

            var Exibir = repositorio.RetornaPorId(indiceAnime);

            if(Exibir.Excluido == true)
            {
                Console.WriteLine();
                Console.WriteLine("Anime Excluido");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine(Exibir);
            }   
        }

        private static string ObterOpcao()
        {
            Console.WriteLine();
            Console.WriteLine("A melhor lista de Animes ");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine();
            Console.WriteLine("1- Listar Animes");
            Console.WriteLine("2- Inserir novo Anime");
            Console.WriteLine("3- Atualizar Anime");
            Console.WriteLine("4- Excluir Anime");
            Console.WriteLine("5- Visualizar Anime");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
