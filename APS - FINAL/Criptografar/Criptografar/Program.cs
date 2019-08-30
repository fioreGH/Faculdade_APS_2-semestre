using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Criptografar
{
    class Program
    {
        /*Desenvolvido por:
          Raphael Alves Fiore            - R.A: T5241A9  - CC2941  
          Mattheus Rodrigues Alonso      - R.A: D3134D-3 - CC2P41
          Isael Gomes de Oliveira Junior - R.A: N319445 - SI2P41
          Jhonatas Ferreira Paschalis    - R.A: D757GC9 - CC2P41
        */
        static string VerificaNome(string name)
        {
            int countSenha = 0;
            while ((name != "raphael") && (name != "isael") && (name != "mattheus") && (name != "jhonatas") && countSenha < 3)
            {
                Console.WriteLine("USUÁRIO NÃO AUTORIZADO!");
                Console.Write("ENTRE COM SEU NOME: ");
                countSenha++;
                name = Console.ReadLine().ToLower();
            }
            if (countSenha == 3)
            {
                Console.WriteLine();
                Console.WriteLine("EXCEDEU O MÁXIMO DE TENTATIVAS, VOCÊ NÃO ESTÁ AUTORIZADO E O PROGRAMA SERÁ ENCERRADO, APERTE QUALQUER TECLA..");
                Console.ReadKey();
                Environment.Exit(1);
            }
            return name;
        }

        static string VerificaSenha(string pass)
        {
            int countSenha = 0;
            while ((pass != "t5241a9") && (pass != "n319445") && (pass != "d3134d3") && (pass != "d757gc9")
                && countSenha < 3)
            {
                Console.WriteLine("SENHA NÃO AUTORIZADA!");
                Console.Write("ENTRE COM A SUA SENHA: ");
                countSenha++;
                pass = Console.ReadLine();
            }
            if (countSenha == 3)
            {
                Console.WriteLine();
                Console.WriteLine("EXCEDEU O MÁXIMO DE TENTATIVAS, O PROGRAMA SERÁ ENCERRADO, APERTE QUALQUER TECLA..");
                Console.ReadKey();
                Environment.Exit(1);
            }
            return pass;
        }
    
        static void Main(string[] args)
        {
            //declaração das variáveis
            string palavra, encrypt = "";
            string nome, senha = "";

            //método write escreve na tela do prompt do usuario
            Console.WriteLine("----------------------");
            Console.WriteLine("-- SISTEMA DE LOGIN --");
            Console.WriteLine("----------------------");

            Console.Write("ENTRE COM SEU NOME: ");
            nome = VerificaNome((Console.ReadLine().ToLower()));

            Console.Write("ENTRE COM A SUA SENHA: ");
            senha = VerificaSenha((Console.ReadLine().ToLower()));


            //método write escreve na tela do prompt do usuario
            Console.Write("|----------------------------------|\n");
            Console.Write("| 1 - CRIPTOGRAFAR UMA MENSAGEM    |\n");
            Console.Write("| 0 - SAIR                         |\n");
            Console.Write("|----------------------------------|\n");
            Console.Write(" ESCOLHA A OPÇÃO: ");

            //Aqui é feito uma conversão, pois o opcao é inicialmente uma string
            int opcao = int.Parse(Console.ReadLine());

            //depois da conversão o switch verifica a opcao digitada
            switch (opcao)

            {
                case 0:
                    Console.WriteLine("O PROGRAMA SERÁ ENCERRADO, APERTE QUALQUER TECLA..");
                    Console.ReadKey();
                    Environment.Exit(1);
                    break;

                //caso a opcao seja 1
                case 1:
                    Console.WriteLine();
                    Console.WriteLine("DIGITE ABAIXO A MENSAGEM PARA SER CRIPTOGRAFADA: ");
                    Console.WriteLine();
                    //palavra é a variavel que o usuario vai digitar
                    //O método .ToLower() transforma qualquer letra maiúscula em minúscula
                    palavra = Console.ReadLine().ToLower();

                    //enquanto a palavra for menor que i
                    for (int i = 0; i < palavra.Length; i++)

                    {
                        //Devolve o codigo ASCII da letra
                        int ASCII = (int)palavra[i];

                        //Coloca a chave fixa adicionando 10 posições no numero da tabela ASCII
                        int ASCIIC = ASCII + 10;

                        //Concatena o texto e o coloca na variável
                        encrypt += Char.ConvertFromUtf32(ASCIIC);
                    }
                    Console.WriteLine();
                    
                    //Mostra o resultado final, concatenando a variável em que está o texto cifrado
                    Console.WriteLine("RESULTADO CRIPTOGRAFADO É: ");
                    Console.WriteLine();
                    Console.WriteLine(encrypt);
                    Console.WriteLine();
                    
                    //Gera o arquivo encriptado
                    StreamWriter sw = new StreamWriter(@"C:\Users\rfiore\Desktop\Criptografar\mensagem.txt");
                    sw.WriteLine(encrypt);
                    sw.Close();
                    Console.WriteLine();
                    Console.Write("ARQUIVO GERADO COM SUCESSO!");
                    Console.WriteLine();

                    //Aguarda o usuário pressionar uma tecla para sair
                    Console.Write("Aperte qualquer tecla para sair....");
                    Console.ReadKey();

                    //representa o final do case 1
                    break;

                default:
                    if ((opcao < 0)|| (opcao > 1))
                    {
                        Console.WriteLine("NUMERO INVÁLIDO, O PROGRAMA SERÁ ENCERRADO, APERTE QUALQUER TECLA..");
                        Console.ReadKey();
                        Environment.Exit(1);
                    }

                    break;

            }

        }
    }
}
