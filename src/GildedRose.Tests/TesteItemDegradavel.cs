using GildedRose.Console.RosaDourada;
using System;
using Xunit;

namespace GildedRose.Tests
{
    public class TesteItemDegradavel
    {
        private static readonly Item Item = 
            new Item
            {
                Nome = "Item degradável",
                Qualidade = 10,
                PrazoDeVenda = 2
            };

        private IItemEstocavel ItemDegradavel = new ItemDegradavel(Item);


        [Fact]
        public void ItemDeveDegradar2PontosAposOPrazo()
        {
            ItemDegradavel.AtualizarPrazo();
            ItemDegradavel.AtualizarPrazo();
            ItemDegradavel.AtualizarPrazo();

            Assert.Equal(6, Item.Qualidade);
        }

        [Fact]
        public void ItemDegradavelNaoPodeTerItemComQualidadeAcimaDe50()
        {
          var excecaoLancada =  Assert.Throws<ArgumentException>("item", () => new ItemDegradavel(new Item { Nome = "item com mais de 50 de qualidade", PrazoDeVenda = 0, Qualidade = 51 }));
          Assert.Contains("Item degradável não pode ter mais que 50 de qualidade.", excecaoLancada.Message);
        }

        [Fact]
        public void ItemDegradavelNaoPodeTerItemNulo()
        {
            var excecaoLancada = Assert.Throws<ArgumentException>("item", () => new ItemDegradavel(null));
            Assert.Contains("Item não pode ser nulo.", excecaoLancada.Message);
        }

        [Fact]
        public void QualidadeNuncaDeveSerMenorQueZero()
        {
            ItemDegradavel.AtualizarPrazo();
            ItemDegradavel.AtualizarPrazo();
            ItemDegradavel.AtualizarPrazo();
            ItemDegradavel.AtualizarPrazo();
            ItemDegradavel.AtualizarPrazo();
            ItemDegradavel.AtualizarPrazo();
            ItemDegradavel.AtualizarPrazo();

            Assert.Equal(0, Item.Qualidade);
        }
    }
}
