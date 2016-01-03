using GildedRose.Console.RosaDourada;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace GildedRose.Tests
{
    public class TesteItemNaoDegradavel
    {
        private Item Item = new Item
        {
            Nome = "Item não degradável",
            PrazoDeVenda = 10,
            Qualidade = 2
        };

        [Fact]
        public void ItemNaoDegradavelNaoDeveSerNulo()
        {
            Action novoItemNaoDegradavel = () => { new ItemNaoDegradavel(null); };

            novoItemNaoDegradavel.ShouldThrow<ArgumentException>()
                .WithMessage("Item não degradável não deve ser nulo!", "Por que item não pode ser uma referência nula!");
        }

        [Fact]
        public void ItemPassadoNaoDeveTerQualidadeMaiorQue50()
        {
            Action novoItemNaoDegradavel = () => { new ItemNaoDegradavel(new Item { Qualidade = 51 }); };

            novoItemNaoDegradavel.ShouldThrow<ArgumentException>()
                .WithMessage("Item não pode ter qualidade que exceda 50!", "Por que itens não devem tem qualidade que exceda 50!");
        }

        [Fact]
        public void ItemPassadoNaoDeveTerQualidadeMaiorMenorQueZero()
        {
            Action novoItemNaoDegradavel = () => { new ItemNaoDegradavel(new Item { Qualidade = -1 }); };

            novoItemNaoDegradavel.ShouldThrow<ArgumentException>()
                .WithMessage("Item não pode ter qualidade menor que 0!", "Por que itens não devem tem qualidade menor que 0!");
        }

        [Fact]
        public void ItemNaoDegradavelAumentaAQualidadeAoPassarDoTempo()
        {
            var itemNaoDegradavel = new ItemNaoDegradavel(Item);

            itemNaoDegradavel.AtualizarPrazo();
            itemNaoDegradavel.AtualizarPrazo();
            itemNaoDegradavel.AtualizarPrazo();

            itemNaoDegradavel.GetItem()
                .ShouldBeEquivalentTo(
                    new Item {Nome = "Item não degradável", PrazoDeVenda = 7, Qualidade = 5 }, 
                    "O item deve aumentar a qualidade ao passar do tempo");
        }

        [Fact]
        public void ItemNaoDegradavelAumentaDuasVezesAQualidadeAoPassarDoTempo()
        {
            var itemNaoDegradavel = new ItemNaoDegradavel(Item);

           for(var i = 0 ; i < 11; i++)
            {
                itemNaoDegradavel.AtualizarPrazo();
            }

            itemNaoDegradavel.GetItem()
                .ShouldBeEquivalentTo(
                    new Item { Nome = "Item não degradável", PrazoDeVenda = -1, Qualidade = 14},
                    "O item deve aumentar 2 vezes a qualidade ao passar do tempo");
        }

        [Fact]
        public void ItemNaoDegradavelNaoDeveTerQualidadeMaiorQue50()
        {
            var itemNaoDegradavel = new ItemNaoDegradavel(Item);

            for (var i = 0; i < 50; i++)
            {
                itemNaoDegradavel.AtualizarPrazo();
            }

            itemNaoDegradavel.GetItem()
                .ShouldBeEquivalentTo(
                    new Item { Nome = "Item não degradável", PrazoDeVenda = -40, Qualidade = 50 },
                    "O item deve aumentar 2 vezes a qualidade ao passar do tempo");
        }

    }
}
