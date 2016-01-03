using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console.RosaDourada
{
    public class Tiquete : IItemEstocavel
    {
        private Item Item;

        public Tiquete(Item item)
        {
            if (item == null)
                throw new ArgumentException("Item não pode ser nulo!");

            if (item.Qualidade > 50)
                throw new ArgumentException("Item não pode ter qualidade que exceda 50!");

            if (item.PrazoDeVenda < 0 && item.Qualidade != 0)
                throw new ArgumentException("Item deve ter qualidade zero, pois o prazo de venda já passou!");

            if (item.Qualidade < 0)
                throw new ArgumentException("Item deve ter qualidade com valor não negativo!");

            Item = item;
        }


        public void AtualizarPrazo()
        {

            if (Item.PrazoDeVenda <= 0)
            {
                Item.Qualidade = 0;
            }
            else
            {
                if (Item.Qualidade < 50)
                {

                    if (Item.PrazoDeVenda < 11)
                    {
                        Item.Qualidade += 1;
                    }

                    if (Item.PrazoDeVenda < 6)
                    {
                        Item.Qualidade += 1;
                    }
                    Item.Qualidade += 1;
                }
            }

            Item.PrazoDeVenda -= 1;
        }

        public Item GetItem()
        {
            return Item;
        }
    }
}
