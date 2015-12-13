using GildedRose.Console.RosaDourada;
using System.Collections.Generic;

namespace RosaDourada.Console
{
    public class Programa
    {
        public IList<Item> Itens { get; private set; }
        public static Estoque App { get; private set;}

        public static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Estoque();

            app.AtualizarQualidade();

           System.Console.ReadKey();

        }

       

    }

}
