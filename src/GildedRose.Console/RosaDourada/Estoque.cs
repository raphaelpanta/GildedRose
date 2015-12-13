using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console.RosaDourada
{

    public class Estoque
    {
        public IList<Item> Itens { get; private set; }


        public Estoque(IList<Item> itens)
        {
            Itens = itens;
        }

        public Estoque()
        {
            Itens = new List<Item>
                                          {
                                              new Item {Nome = "+5 Vestimenta da Destreza", PrazoDeVenda = 10, Qualidade = 20},
                                              new Item {Nome = "Queijo Brie Envelhecido", PrazoDeVenda = 2, Qualidade = 0},
                                              new Item {Nome = "Elixir do Mangusto", PrazoDeVenda = 5, Qualidade = 7},
                                              new Item {Nome = "Sulfuras, Mão de Ragnaros", PrazoDeVenda = 0, Qualidade = 80},
                                              new Item
                                                  {
                                                      Nome = "Passes para os bastidores do show TAFKAL80ETC ",
                                                      PrazoDeVenda = 15,
                                                      Qualidade = 20
                                                  },
                                              new Item {Nome = "Torta de Mana para Invocações", PrazoDeVenda = 3, Qualidade = 6}
                                          };
        }

        public void AtualizarQualidade()
        {
            for (var i = 0; i < Itens.Count; i++)
            {
                if (Itens[i].Nome != "Queijo Brie Envelhecido" && Itens[i].Nome != "Passes para os bastidores do show TAFKAL80ETC ")
                {
                    if (Itens[i].Qualidade > 0)
                    {
                        if (Itens[i].Nome != "Sulfuras, Mão de Ragnaros")
                        {
                            Itens[i].Qualidade = Itens[i].Qualidade - 1;
                        }
                    }
                }
                else
                {
                    if (Itens[i].Qualidade < 50)
                    {
                        Itens[i].Qualidade = Itens[i].Qualidade + 1;

                        if (Itens[i].Nome == "Passes para os bastidores do show TAFKAL80ETC ")
                        {
                            if (Itens[i].PrazoDeVenda < 11)
                            {
                                if (Itens[i].Qualidade < 50)
                                {
                                    Itens[i].Qualidade = Itens[i].Qualidade + 1;
                                }
                            }

                            if (Itens[i].PrazoDeVenda < 6)
                            {
                                if (Itens[i].Qualidade < 50)
                                {
                                    Itens[i].Qualidade = Itens[i].Qualidade + 1;
                                }
                            }
                        }
                    }
                }

                if (Itens[i].Nome != "Sulfuras, Mão de Ragnaros")
                {
                    Itens[i].PrazoDeVenda = Itens[i].PrazoDeVenda - 1;
                }

                if (Itens[i].PrazoDeVenda < 0)
                {
                    if (Itens[i].Nome != "Queijo Brie Envelhecido")
                    {
                        if (Itens[i].Nome != "Passes para os bastidores do show TAFKAL80ETC ")
                        {
                            if (Itens[i].Qualidade > 0)
                            {
                                if (Itens[i].Nome != "Sulfuras, Mão de Ragnaros")
                                {
                                    Itens[i].Qualidade = Itens[i].Qualidade - 1;
                                }
                            }
                        }
                        else
                        {
                            Itens[i].Qualidade = Itens[i].Qualidade - Itens[i].Qualidade;
                        }
                    }
                    else
                    {
                        if (Itens[i].Qualidade < 50)
                        {
                            Itens[i].Qualidade = Itens[i].Qualidade + 1;
                        }
                    }
                }
            }
        }
    }
}
