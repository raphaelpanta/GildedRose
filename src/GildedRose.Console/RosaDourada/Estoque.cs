using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console.RosaDourada
{

    public class Estoque
    {
        public IList<IItemEstocavel> Itens { get; private set; }


        public Estoque(IList<IItemEstocavel> itens)
        {
            Itens = itens;
        }

        public Estoque()
        {
            Itens = new List<IItemEstocavel>
                                          {
                                          new ItemDegradavel (new Item {Nome = "+5 Vestimenta da Destreza", PrazoDeVenda = 10, Qualidade = 20}),
                                           new ItemNaoDegradavel (new Item {Nome = "Queijo Brie Envelhecido", PrazoDeVenda = 2, Qualidade = 0}),
                                           new ItemDegradavel (new Item {Nome = "Elixir do Mangusto", PrazoDeVenda = 5, Qualidade = 7}),
                                           new ItemLegendario (  new Item {Nome = "Sulfuras, Mão de Ragnaros", PrazoDeVenda = 0, Qualidade = 80}),
                                            new DummyItemEstocavel  (new Item
                                                  {
                                                      Nome = "Passes para os bastidores do show TAFKAL80ETC ",
                                                      PrazoDeVenda = 15,
                                                      Qualidade = 20
                                                  }),
                                           new DummyItemEstocavel   (new Item {Nome = "Torta de Mana para Invocações", PrazoDeVenda = 3, Qualidade = 6})
                                          };
        }

        public void AtualizarQualidade()
        {
            for (var i = 0; i < Itens.Count; i++)
            {
                if (Itens[i] is ItemDegradavel || Itens[i] is ItemLegendario || Itens[i] is ItemNaoDegradavel)
                {
                    Itens[i].AtualizarPrazo();

                }
                else
                {
                    if (Itens[i].GetItem().Qualidade < 50)
                    {
                        Itens[i].GetItem().Qualidade = Itens[i].GetItem().Qualidade + 1;

                        if (Itens[i].GetItem().Qualidade < 50)
                        {
                            if (Itens[i].GetItem().PrazoDeVenda < 11)
                            {
                                Itens[i].GetItem().Qualidade = Itens[i].GetItem().Qualidade + 1;
                            }

                            if (Itens[i].GetItem().PrazoDeVenda < 6)
                            {
                                Itens[i].GetItem().Qualidade = Itens[i].GetItem().Qualidade + 1;
                            }
                        }
                    }

                    Itens[i].GetItem().PrazoDeVenda = Itens[i].GetItem().PrazoDeVenda - 1;

                    if (Itens[i].GetItem().PrazoDeVenda < 0)
                    {
                        Itens[i].GetItem().Qualidade = 0;
                    }
                }
            }
        }
    }
}
