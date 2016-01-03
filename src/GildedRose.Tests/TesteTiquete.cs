using GildedRose.Console.RosaDourada;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace GildedRose.Tests
{
    public class TesteTiquete
    {

        private Item Item = new Item
        {
            Nome = "Tiquete",
            PrazoDeVenda = 15,
            Qualidade = 20
        };

        [Fact]
        public void TiqueteNaoPodeSerNulo()
        {
            Action tiqueteNulo = () => { new Tiquete(null); };

            tiqueteNulo.ShouldThrow<ArgumentException>()
                .WithMessage("Item não pode ser nulo!", "Tiquete não deve ter referência a item nulo.");
        }

        [Fact]
        public void ItemNaoDeveTerQualidadeMaiorQue50()
        {
            Action tiqueteNulo = () => { new Tiquete(new Item { Qualidade = 51}); };

            tiqueteNulo.ShouldThrow<ArgumentException>()
                .WithMessage("Item não pode ter qualidade que exceda 50!", "Tiquete não deve ter qualidade maior que 50.");
        }

        [Fact]
        public void ItemDeveTerQualidadeZeroSePrazoÉMenorQue0()
        {
            Action tiqueteNulo = () => { new Tiquete(new Item { Qualidade = 50, PrazoDeVenda = -1 }); };


            tiqueteNulo.ShouldThrow<ArgumentException>()
                .WithMessage(
                "Item deve ter qualidade zero, pois o prazo de venda já passou!", 
                "Tiquete deve ter qualidade zero pois já passou o dia do show.");
        }

        [Fact] 
        public void ItemNaoDeveTerQualidadeMenorQueZero()
        {
            Action tiqueteNulo = () => { new Tiquete(new Item { Qualidade = -1, PrazoDeVenda = 1 }); };


            tiqueteNulo.ShouldThrow<ArgumentException>()
                .WithMessage(
                "Item deve ter qualidade com valor não negativo!",
                "Tiquete deve ter qualidade maior que zero.");
        }

        [Fact]
        public void TiqueteDeveAumentarEm1EmQualidadeAoFicarAOnzeDiasDoPrazo()
        {
            var tiquete = new Tiquete(Item);
            for(var i = 0; i < 4; i++)
            {
                tiquete.AtualizarPrazo();
            }

            tiquete.GetItem().ShouldBeEquivalentTo(
                new Item {
                    Nome = "Tiquete",
                    PrazoDeVenda = 11,
                    Qualidade = 24
                }, 
                "ao decorrer de 4 dias o valor de qualidade deve aumentar em 4.");
        }

        [Fact]
        public void TiqueteDeveAumentarEm2EmQualidadeAoFicarA6DiasDoPrazo()
        {
            var tiquete = new Tiquete(Item);
            for (var i = 0; i < 5; i++)
            {
                tiquete.AtualizarPrazo();
            }

            tiquete.GetItem().ShouldBeEquivalentTo(
                new Item
                {
                    Nome = "Tiquete",
                    PrazoDeVenda = 10,
                    Qualidade = 25
                },
                "ao decorrer de 5 dias o valor de qualidade deve aumentar em 5.");
        }

        [Fact]
        public void TiqueteDeveAumentarEm2EmQualidadeAoFicarA3DiasDoPrazo()
        {
            var tiquete = new Tiquete(Item);
            for (var i = 0; i < 12; i++)
            {
                tiquete.AtualizarPrazo();
            }

            tiquete.GetItem().ShouldBeEquivalentTo(
                new Item
                {
                    Nome = "Tiquete",
                    PrazoDeVenda = 3,
                    Qualidade = 41
                }, 
                "ao decorrer de 12 dias o valor de qualidade deve aumentar em 21.");
        }

        [Fact]
        public void TiqueteDeveTerQualidadeZeroAoPassarDoPrazo()
        {
            var tiquete = new Tiquete(Item);
            for (var i = 0; i < 16; i++)
            {
                tiquete.AtualizarPrazo();
            }

            tiquete.GetItem().ShouldBeEquivalentTo(
                new Item
                {
                    Nome = "Tiquete",
                    PrazoDeVenda = -1,
                    Qualidade = 0
                },
                "ao decorrer de 16 dias o valor de qualidade deve ser 0.");
        }

        [Fact]
        public void TiqueteTemNoMaximo50DeQualidade()
        {
            var tiquete = new Tiquete(new Item { Nome = "Tiquete", Qualidade = 49, PrazoDeVenda = 15 });
            for (var i = 0; i < 3; i++)
            {
                tiquete.AtualizarPrazo();
            }

            tiquete.GetItem().ShouldBeEquivalentTo(
                new Item
                {
                    Nome = "Tiquete",
                    PrazoDeVenda = 12,
                    Qualidade = 50
                },
                "ao decorrer de 3 dias o valor de qualidade deve ser 50.");
        }
    }
}
