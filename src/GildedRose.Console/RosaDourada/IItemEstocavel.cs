using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console.RosaDourada
{
    public interface IItemEstocavel
    {
         void AtualizarPrazo();

        Item GetItem();
    }
}
