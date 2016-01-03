using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console.RosaDourada
{
    public class ItemNaoDegradavel : IItemEstocavel

    {
        private Item Item;

        public ItemNaoDegradavel(Item item)
        {
            if (item == null)
            {
                throw new ArgumentException("Item não degradável não deve ser nulo!");
            }

            if (item.Qualidade > 50)
            {
                throw new ArgumentException("Item não pode ter qualidade que exceda 50!");
            }

            if (item.Qualidade < 0)
            {
                throw new ArgumentException("Item não pode ter qualidade menor que 0!");
            }

            this.Item = item;
        }

        public void AtualizarPrazo()
        {
            Item.PrazoDeVenda = Item.PrazoDeVenda - 1;
            if (Item.Qualidade < 50)
                Item.Qualidade = (Item.PrazoDeVenda < 0) ? Item.Qualidade + 2 : Item.Qualidade + 1;
        }

        public Item GetItem()
        {
            return Item;
        }
    }
}
