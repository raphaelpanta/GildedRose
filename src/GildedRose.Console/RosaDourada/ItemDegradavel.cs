using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console.RosaDourada
{
    public class ItemDegradavel : IItemEstocavel
    {

        private Item Item;

        public ItemDegradavel(Item item)
        {
            if(item == null)
            {
                throw new ArgumentException("Item não pode ser nulo.", "item");
            }

            if(item.Qualidade > 50)
            {
                throw new ArgumentException("Item degradável não pode ter mais que 50 de qualidade.","item");
            }
          
            Item = item;
        }

        public void AtualizarPrazo()
        {
            Item.PrazoDeVenda = Item.PrazoDeVenda - 1;

            if(Item.Qualidade > 0)
                Item.Qualidade =  Item.PrazoDeVenda >= 0 ? Item.Qualidade - 1 : Item.Qualidade - 2;
        }

        public Item GetItem()
        {
            return Item;
        }
    }
}
