using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISTA_DUPLAMENTE_ENCADEADA_ORDENADA
{
    // CLASSE QUE CONTERA CADA VALOR DE ITEM DA LISTA
    // EM CADA ITEM CONTERA O REGISTRO DA PROXIMA LISTA E DA ANTERIOR
    // DENTREO DESTE PROXIMO E ANTERIOR TERA NOVAMENTE UM VALOR E OUTRAS LISTAS E ASSIM VAI
    class LISTA
    {
        public int numero;
        public LISTA proximo;
        public LISTA anterior;
    }

    class Program
    {
        static void Main(string[] args)
        {
            // CABECA NESTE CASO RECEBE O MENOR ITEM INSERIDO NA LISTA (PRIMEIRO)
            LISTA cabeca = null;
            // RECEBE O ULTIMO ITEM QUE CORRESPONDE AO MAIOR DA LISTA
            LISTA calda = null;
            LISTA auxiliar;

            int opcao = 0, numero, achou;
            do
            {
                Console.Clear();
                Console.WriteLine("MENU DE OPÇÕES:");
                Console.WriteLine("1 - INSERIR NA LISTA");
                Console.WriteLine("2 - CONSULTAR A LISTA DO INICIO AO FIM");
                Console.WriteLine("3 - CONSULTAR A LISTA DO FIM AO INICIO");
                Console.WriteLine("4 - REMOVER DA LISTA");
                Console.WriteLine("5 - ESVAZIAR A LISTA");
                Console.WriteLine("6 - SAIR");

                Console.WriteLine("DIGITE A OPÇÃO DESEJADA:");

                opcao = Convert.ToInt32(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("DIGITE O NUMERO A SER INSERIDO NA LISTA:");
                        LISTA novoItem = new LISTA();
                        novoItem.numero = Convert.ToInt32(Console.ReadLine());
                        
                        if (cabeca == null)
                        {
                            // PRIMEIRO ITEM DA LISTA
                            cabeca = novoItem;
                            calda = novoItem;
                            novoItem.proximo = null;
                            novoItem.anterior = null;
                        }
                        else
                        {
                            // PEGO O VALOR DA LISTA CADASTRADA ANTERIORMENTE
                            auxiliar = cabeca;
                            while (auxiliar != null && novoItem.numero > auxiliar.numero)
                            {
                                // VERIFICAR O NUMERO MENOR QUE O DIGITADO
                                // O NUMERO DIGITADO SEMPRE FICA LOGO APOS O MENOR QUE ELE
                                // CASO O NUMERO DIGITADO SEJA MAIOR QUE TODOS ITENS ADICIONADO O PROXIMO SERA NULO
                                auxiliar = auxiliar.proximo;
                            }
                            if (auxiliar == cabeca)
                            {
                                // O ITEM ANTERIOR E IGUAL AO INFORMADO NA CABECA 
                                novoItem.proximo = cabeca;
                                novoItem.anterior = null;
                                cabeca.anterior = novoItem;
                                cabeca = novoItem;
                            }
                            else if (auxiliar == null)
                            {
                                // O NUMERO INFORMADO É O MAIOR NUMERO DA LISTA ENTÃO É INSERIDO NO FINAL
                                calda.proximo = novoItem;
                                novoItem.anterior = calda;
                                calda = novoItem;
                                calda.proximo = null;
                            }
                            else
                            {
                                // O NUMERO FOI INSERIDO NO MEIO POIS NAO É O MAIOR QUE O ULTIMO E MENOR QUE O PRIMEIRO
                                // OU NO INICIO CASO SEJA MENOR QUE O PRIMEIRO ITEM DA LISTA
                                // O AUXILIAR POSSUI O VALOR DO NUMERO MAIOR QUE O DIGITADO
                                // NOVO ITEM RECEBE O PROXIMO QUE ERA DO AUXILIAR OU SEJA O MAIOR
                                novoItem.proximo = auxiliar;
                                // ISSO INDICA QUE EU QUERO PEGAR O PROPRIO DO NUMERO MENOR QUE O DIGITADO
                                auxiliar.anterior.proximo = novoItem;
                                // PEGO O ITEM QUE VEM ANTES DO MENOR ITEM QUE O DIGITADO
                                novoItem.anterior = auxiliar.anterior;

                                auxiliar.anterior = novoItem;
                            }
                        }
                        Console.WriteLine("NUMERO INSERIDO NA LISTA!");
                        break;
                    case 2:
                        if (cabeca != null)
                        {
                            Console.WriteLine("CONSULTADO A LISTA DA CABECA A CALDA...");
                            //PEGA O PRIMEIRO ITEM DA LISTA
                            auxiliar = cabeca;
                            while (auxiliar != null)
                            {
                                Console.Write(auxiliar.numero + "   ");
                                // PEGA O PROXIMO ITEM DA LISTA O MAIOR 
                                auxiliar = auxiliar.proximo;
                            }
                        }else
                        {
                            Console.WriteLine("LISTA VAZIA!");
                        }
                        break;
                    case 3:
                        if (cabeca != null)
                        {
                            Console.WriteLine("CONSULTADO A LISTA DA CALDA A CABECA...");
                            // PEGA O PRIMEIRO ITEM DA LISTA
                            auxiliar = calda;
                            while (auxiliar != null)
                            {
                                Console.Write(auxiliar.numero + "   ");
                                // PEGA O ITEM MENOR QUE O ANTERIOR
                                auxiliar = auxiliar.anterior;
                            }
                        }else
                        {
                            Console.WriteLine("LISTA VAZIA!");
                        }
                        break;
                    case 4:
                        if (cabeca != null)
                        {
                            Console.WriteLine("DIGITE O ELEMENTO A SER REMOVIDO:");

                            numero = Convert.ToInt32(Console.ReadLine());

                            //PEGA O PRIMEIRO ITEM DA LISTA
                            auxiliar = cabeca;
                            achou = 0;
                            while (auxiliar != null)
                            {
                                if (auxiliar.numero == numero)
                                {
                                    // NUMERO DIGITADO FOI ENCONTRADO
                                    achou = achou + 1;
                                    if (auxiliar == cabeca)
                                    {
                                        // O NUMERO REMOVIDO É O PRIMEIRO DA LISTA
                                        // ALIMENTAR O PRIMEIRO DA LISTA COM O PROXIMO
                                        cabeca = auxiliar.proximo;
                                        if (cabeca != null)
                                        {
                                            // A LISTA TEM MAIS DE UM ITEM
                                            cabeca.anterior = null;
                                        }
                                        // SE A LISTA POSSUI MAIS DE UM NUMERO 
                                        // ENTAO O PROXIMO NUMERO DEPOIS DO PRIMEIRO ASSUME O LUGAR DE CABECA
                                        // SE NAO TIVER MAIS DE UM A LISTA SERA LIMPADA
                                        auxiliar = cabeca;
                                    }
                                    else if (auxiliar == calda)
                                    {
                                        // NUMERO DIGITADO É O ULTIMO NUMERO
                                        calda = calda.anterior;
                                        calda.proximo = null;
                                        auxiliar = null;
                                    }
                                    else
                                    {
                                        // ITEM DO MEIO
                                        // QUANDO DIGO ISSO auxiliar.anterior.proximo ESTOU FALANDO DO PROPRIO ITEM QUE SERA REMOVIDO
                                        auxiliar.anterior.proximo = auxiliar.proximo;
                                        auxiliar.proximo.anterior = auxiliar.anterior;
                                        auxiliar = auxiliar.proximo;
                                    }
                                }
                                else
                                {
                                    // VOU PARA O PROXIMO NUMERO POIS ESTE NAO E O MESMO QUE EU DIGITEI
                                    auxiliar = auxiliar.proximo;
                                }
                            }

                            // RESULTADO DO ITEM DIGITADO
                            if (achou == 0)
                            {
                                Console.WriteLine("NUMERO NAO ENCONTRADO!");
                            }
                            else if (achou == 1)
                            {
                                Console.WriteLine("NUMERO REMOVIDO UMA VEZ!");
                            }
                            else
                            {
                                Console.WriteLine("NUMERO REMOVIDO " + achou + " VEZES!");
                            }
                        }
                        break;
                    case 5:
                        if (cabeca != null)
                        {
                            // COM O CABECALHO NULO EU PERCO A REFERENCIA DE TODOS OS ITENS DA MINHA LISTA
                            cabeca = null;
                            Console.WriteLine("LISTA ESVAZIADA!");
                        }else
                        {
                            Console.WriteLine("LISTA VAZIA!");
                        }
                        break;
                    case 6:
                        Console.WriteLine("OBRIGADO POR USAR O SISTEMA!");
                        break;
                    default:
                        Console.WriteLine("OPÇÃO INVALIDA!");
                        break;
                }
                Console.ReadLine();
            } while (opcao != 6);
        }
    }
}
