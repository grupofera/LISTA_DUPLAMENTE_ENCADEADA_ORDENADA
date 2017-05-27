using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISTA_DUPLAMENTE_ENCADEADA_ORDENADA
{
    class LISTA
    {
        public int num;
        public LISTA prox;
        public LISTA ant;
    }

    class Program
    {
        static void Main(string[] args)
        {
            LISTA inicio = null;
            LISTA fim = null;
            LISTA aux;

            int op = 0, numero, achou;
            do
            {
                Console.Clear();
                Console.WriteLine("MENU DE OPÇÕES");
                Console.WriteLine("1 - INSERIR NA LISTA");
                Console.WriteLine("2 - CONSULTAR A LISTA DO INICIO AO FIM");
                Console.WriteLine("3 - CONSULTAR A LISTA DO FIM AO INICIO");
                Console.WriteLine("4 - REMOVER DA LISTA");
                Console.WriteLine("5 - ESVAZIAR A LISTA");
                Console.WriteLine("6 - SAIR");

                Console.WriteLine("DIGITE A OPÇÃO DESEJADA:");
                
                op = Convert.ToInt32(Console.ReadLine());

                if (op < 1 || op > 6)
                {
                    Console.WriteLine("OPÇÃO INVALIDA");
                }

                if (op == 1)
                {
                    Console.WriteLine("DIGITE O NUMERO A SER INSERIDO NA LISTA");
                    LISTA novo = new LISTA();
                    novo.num = Convert.ToInt32(Console.ReadLine());

                    if (inicio == null)
                    {
                        inicio = novo;
                        fim = novo;
                        novo.prox = null;
                        novo.ant = null;
                    }else
                    {
                        aux = inicio;
                        while (aux != null && novo.num > aux.num)
                        {
                            aux = aux.prox;
                            if (aux == inicio)
                            {
                                novo.prox = inicio;
                                novo.ant = null;
                                inicio.ant = novo;
                                inicio = novo;
                            }else if (aux == null)
                            {
                                fim.prox = novo;
                                novo.ant = fim;
                                fim = novo;
                                fim.prox = null;
                            }else
                            {
                                novo.prox = aux;
                                aux.ant.prox = novo;
                                novo.ant = aux.ant;
                                aux.ant = novo;
                            }
                        }
                        Console.WriteLine("NUMERO INSERIDO NA LISTA");
                    }
                }

                if (op == 2)
                {
                    if (inicio == null)
                    {
                        Console.WriteLine("LISTA VAZIA");
                    }else
                    {
                        Console.WriteLine("consultado a lista do inicio ao fim");
                        aux = inicio;
                        while (aux != null)
                        {   
                            Console.WriteLine(aux.num + "----");
                            aux = aux.prox;
                        }
                    }
                    Console.ReadLine();
                }

                if (op == 3)
                {
                    if (inicio == null)
                    {
                        Console.WriteLine("LISTA VAZIA");
                    }
                    else
                    {
                        Console.WriteLine("consultado a lista do fim ao inicio");
                        aux = fim;
                        while (aux != null)
                        {
                            Console.WriteLine(aux.num + "   ");
                            aux = aux.ant;
                        }
                    }
                    Console.ReadLine();
                }

                if (op == 4)
                {
                    if (inicio == null)
                    {
                        Console.WriteLine("LISTA VAZIA");
                    }else
                    {
                        Console.WriteLine("DIGITE O ELEMENTO A SER REMOVIDO");
                        numero = Convert.ToInt32(Console.ReadLine());

                        aux = inicio;
                        achou = 0;
                        while (aux != null)
                        {
                            if (aux.num == numero)
                            {
                                achou = achou + 1;
                                if (aux == inicio)
                                {
                                    inicio = aux.prox;
                                    if (inicio != null)
                                    {
                                        inicio.ant = null;
                                    }
                                    aux = inicio;
                                }
                                else if (aux == fim)
                                {
                                    fim = fim.ant;
                                    fim.prox = null;
                                    aux = null;
                                }
                                else{
                                    aux.ant.prox = aux.prox;
                                    aux.prox.ant = aux.ant;
                                    aux = aux.prox;
                                }
                            }else
                            {
                                aux = aux.prox;
                            }
                        }
                        if (achou == 0)
                        {
                            Console.WriteLine("NUMERO NAO ENCONTRADO");
                        }else if (achou == 1)
                        {
                            Console.WriteLine("NUMERO REMOVIDO UMA VEZ");
                        }else
                        {
                            Console.WriteLine("NUMERO REMOVIDO "+achou+" VEZES");
                        }
                    }
                    Console.ReadLine();
                }

                if (op == 5)
                {
                    if (inicio == null)
                    {
                        Console.WriteLine("LISTA VAZIA");
                    }else
                    {
                        inicio = null;
                        Console.WriteLine("LISTA ESVAZIADA");
                    }
                    Console.ReadLine();
                }
                
            } while (op != 6);
        }
    }
}
