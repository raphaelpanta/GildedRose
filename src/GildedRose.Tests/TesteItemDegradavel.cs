using GildedRose.Console.RosaDourada;
using System;
using Xunit;
using FluentAssertions;

namespace GildedRose.Tests
{
    public class TesteItemDegradavel
    {
        private Item Item =
            new Item
            {
                Nome = "Item degradável",
                Qualidade = 10,
                PrazoDeVenda = 2
            };

        [Fact]
        public void ItemDeveDegradar2PontosAposOPrazo()
        {
            var ItemDegradavel = new ItemDegradavel(Item);
            ItemDegradavel.AtualizarPrazo();
            ItemDegradavel.AtualizarPrazo();
            ItemDegradavel.AtualizarPrazo();

            Item.Qualidade.Should().Be(6);
        }

        [Fact]
        public void ItemDegradavelNaoPodeTerItemComQualidadeAcimaDe50()
        {
            var ItemDegradavel = new ItemDegradavel(Item);
            var excecaoLancada = Assert.Throws<ArgumentException>("item", () => new ItemDegradavel(new Item { Nome = "item com mais de 50 de qualidade", PrazoDeVenda = 0, Qualidade = 51 }));
            Assert.Contains("Item degradável não pode ter mais que 50 de qualidade.", excecaoLancada.Message);
        }

        [Fact]
        public void ItemDegradavelNaoPodeTerItemNulo()
        {
            var ItemDegradavel = new ItemDegradavel(Item);
            var excecaoLancada = Assert.Throws<ArgumentException>("item", () => new ItemDegradavel(null));
            Assert.Contains("Item não pode ser nulo.", excecaoLancada.Message);
        }

        [Fact]
        public void QualidadeNuncaDeveSerMenorQueZero()
        {
            var ItemDegradavel = new ItemDegradavel(Item);
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
