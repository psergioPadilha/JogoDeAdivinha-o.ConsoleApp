using System.ComponentModel.Design;

namespace JogoDeAdivinhação.ConsoleApp
{
    internal class Program
    {
        static string nivelDeDificuldade;
        static double pontuacao;

        static void Main(string[] args)
        {
            while (true)
            {
                int numeroAleatorio = GerarAleatorio();
                
                ApresentarMenu();

                nivelDeDificuldade = ApresentarSubMenu();

                switch (nivelDeDificuldade)
                {
                    case "1":
                        Jogar(15);
                        break;
                    case "2":
                        Jogar(10);
                        break;
                    case "3":
                        Jogar(5);
                        break;
                }

                Console.ReadLine();
            }
        }

        #region Cabeçalho do menu
        static void ApresentarCabecalho()
        {
            Console.Clear();
            string cabecalho = "Bem-vindo(a) ao Jogo de Advinhação!";

            for (int i = 1; i <= 45; i++)
                Console.Write("*");

            Console.WriteLine();

            Console.Write("*");
            for (int i = 1; i <= ((45 - cabecalho.Length) / 2) - 1; i++)
            {
                Console.Write(" ");
            }

            Console.Write(cabecalho);

            for (int i = 1; i <= ((45 - cabecalho.Length) / 2) - 1; i++)
            {
                Console.Write(" ");
            }

            Console.WriteLine("*");

            for (int i = 1; i <= 45; i++)
                Console.Write("*");

            Console.WriteLine();
        }
        #endregion

        #region Menu
        static void ApresentarMenu()
        {
            string opcao = "";
            ApresentarCabecalho();
            Console.WriteLine();
            Console.WriteLine("Digite 'C' para continuar e 'S' para sair...");
            Console.Write("Opção: ");
            VerificarOpcaoMenu(Console.ReadLine());
        }
        #endregion

        #region Verifica se o valor escolhido é mesmo um caracter válido
        static void VerificarOpcaoMenu(string opcao)
        {
            while ((opcao != "S") && (opcao != "s") && (opcao != "C") && (opcao != "c"))
            {
                Console.Clear();
                ApresentarCabecalho();
                Console.WriteLine();
                Console.WriteLine("Opção inválida...");
                Console.WriteLine();
                Console.WriteLine("Digite 'C' para continuar e 'S' para sair...");
                Console.Write("Opção: ");
                opcao = Console.ReadLine();
            }
            if ((opcao == "S") || (opcao == "s"))
            {
                Console.Clear();
                ApresentarCabecalho();
                Console.WriteLine();
                Console.WriteLine("Tem certeza que quer sair do sistema?");
                Console.WriteLine("Digite 'C' para continuar e 'S' para sair!");
                Console.Write("Opção: ");
                opcao = Console.ReadLine();
                while ((opcao != "C") && (opcao != "c") && (opcao != "S") && (opcao != "s"))
                {
                    Console.Clear();
                    ApresentarCabecalho();
                    Console.WriteLine();
                    Console.WriteLine("Opção inválida...");
                    Console.WriteLine();
                    Console.WriteLine("Digite 'C' para continuar e 'S' para sair...");
                    Console.Write("Opção: ");
                    opcao = Console.ReadLine();
                }
                if ((opcao == "S") || (opcao == "s"))
                    Environment.Exit(0);
            }
        }
        #endregion

        #region Gerar número aleatório
        static int GerarAleatorio()
        {
            Random numeroAleatorio = new Random();

            return numeroAleatorio.Next(1, 21);
        }
        #endregion

        #region Submenu
        static string ApresentarSubMenu()
        {
            Console.Clear();
            ApresentarCabecalho();
            for (int i = 1; i <= 45; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
            Console.WriteLine("Escolha o nível de dificuldade:");
            Console.WriteLine("(1)Fácil  (2)Médio  (3)Difícil");
            Console.Write("Opção: ");
            string opcao = VerificarSubMenu(Console.ReadLine());

            return opcao;
        }
        #endregion

        #region Verifica se a opção digitada pelo usuário é válida e retorna falso ou verdadeiro
        static string VerificarSubMenu(string opcao)
        {
            while ((opcao != "1") && (opcao != "2") && (opcao != "3"))
            {
                Console.WriteLine();
                Console.WriteLine("Opção inválida, por favor digite novamente...");
                Console.WriteLine();
                Console.WriteLine("Escolha o nível de dificuldade:");
                Console.WriteLine("(1)Fácil  (2)Médio  (3)Difícil");
                Console.Write("Opção: ");
                opcao = Console.ReadLine();
            }
            return opcao;
        }
        #endregion

        #region Jogar
        static void Jogar(int chances)
        {
            int numeroAleatoriio = GerarAleatorio();
            pontuacao = 1000;
            double descontoDePontuacao = 0;
            Console.Clear();
            ApresentarCabecalho();
            Console.WriteLine();
            Console.WriteLine("Sua pontuação inicial é: " + pontuacao + ".");
            Console.WriteLine("Escolha um número de 1 a 20!");

            for (int i = 1; i <= chances; i++)
            {
                int numero = ValidarPalpite(i);

                if ((numero < numeroAleatoriio))
                {
                    Console.WriteLine("Seu palpite foi menor que o número secreto...");
                    descontoDePontuacao = Math.Abs((numero - numeroAleatoriio) / 2);
                    pontuacao -= descontoDePontuacao;
                    Console.WriteLine("Sua pontuação atual é: " + pontuacao + ".");
                    if (chances == i)
                        Console.Write("Infelizmente você não teve sorte, tente novamente...");
                }

                else if ((numero > numeroAleatoriio))
                {
                    Console.WriteLine("Seu palpite foi maior que o número secreto...");
                    descontoDePontuacao = Math.Abs((numero - numeroAleatoriio) / 2);
                    pontuacao -= descontoDePontuacao;
                    Console.WriteLine("Sua pontuação atual é: " + pontuacao + ".");
                    if (chances == i)
                        Console.Write("Infelizmente você não teve sorte, tente novamente...");
                }
                else
                {
                    Console.WriteLine("Parabéns, você acertou o número secreto");
                    Console.WriteLine("Sua pontuação atual é: " + pontuacao + ".");
                    i = chances;
                }
            }
        }
        #endregion

        #region Verifica se o palpite feito é um número e se é maio que '0' e menor que '20'
        private static int ValidarPalpite(int i)
        {
            Console.WriteLine();
            Console.WriteLine("Qual o seu " + i + "º palpite?");
            Console.Write(i + "º Palpite: ");
            string palpite = Console.ReadLine();

            while ((!Int32.TryParse(palpite, out var n)))
            {
                Console.WriteLine();
                Console.WriteLine("Valor inválido, por favor digite novamnete...");
                Console.WriteLine();
                Console.WriteLine("Qual o seu " + i + "º palpite?");
                Console.Write(i + "º Palpite: ");
                palpite = Console.ReadLine();
            }

            int numero = int.Parse(palpite);

            while ((numero < 1) || (numero > 20))
            {
                Console.WriteLine();
                Console.WriteLine("Valor inválido, por favor digite novamnete...");
                Console.WriteLine();
                Console.WriteLine("Qual o seu " + i + "º palpite?");
                Console.Write(i + "º Palpite: ");
                palpite = Console.ReadLine();

                while ((!Int32.TryParse(palpite, out var n)))
                {
                    Console.WriteLine();
                    Console.WriteLine("Valor inválido, por favor digite novamnete...");
                    Console.WriteLine();
                    Console.WriteLine("Qual o seu " + i + "º palpite?");
                    Console.Write(i + "º Palpite: ");
                    palpite = Console.ReadLine();
                }

                numero = int.Parse(palpite);
            }

            return numero;
        }
        #endregion
    }
}
