using GildedRose.Console.RosaDourada;
using System;
using Xunit;
using FluentAssertions;

namespace GildedRose.Tests
{
    public class TesteItemLegendario
    {
        [Fact]
        public void ItemLegendarioNaoPodeSerNulo()
        {
            Action inserirNulo = () => new ItemLegendario(null);
            inserirNulo.ShouldThrow<ArgumentException>()
                .WithMessage(
                    "Item não pode ser nulo!",
                    "por quê foi passado um item nulo!");
        }

        [Fact]
        public void ItemLegendarioDeveTer80DeQualidade()
        {
            Action inserirNulo = () => new ItemLegendario(
                new Item
                {
                    Qualidade = 79
                });

            inserirNulo.ShouldThrow<ArgumentException>()
                .WithMessage(
                    "Item deve ter exatamente 80 de Qualidade!",
                    "Por que item lengendário deve ter qualidade 80!");
        }

        private Item Item =
           new Item
           {
               Nome = "Item legendário",
               Qualidade = 80,
               PrazoDeVenda = 2
           };

        [Fact]
        public void ItemDeveDegradar2PontosAposOPrazo()
        {
            var itemLegendario = new ItemLegendario(Item);
            itemLegendario.AtualizarPrazo();
            itemLegendario.AtualizarPrazo();
            itemLegendario.AtualizarPrazo();

            Item.Qualidade.Should().Be(80, "Por quê a Qualidade é sempre 80.");
        }

    }
}
