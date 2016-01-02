using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console.RosaDourada
{
    public class ItemLegendario : IItemEstocavel
    {
        private Item Item;

        public ItemLegendario(Item item)
        {
            if (item == null)
            {
                throw new ArgumentException("Item não pode ser nulo!");
            }

            if (item.Qualidade != 80)
            {
                throw new ArgumentException("Item deve ter exatamente 80 de Qualidade!");
            }

            Item = item;
        }

        public void AtualizarPrazo()
        {
            
        }

        public Item GetItem()
        {
            return Item;
        }
    }
}
