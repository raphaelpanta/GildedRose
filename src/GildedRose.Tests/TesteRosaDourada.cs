using RosaDourada.Console;
using Xunit;
using System.Linq;
using GildedRose.Console.RosaDourada;

namespace RosaDourada.Testes
{
    public class TesteRosaDourada
    {
        private Estoque ExecutarDiasDeVenda(int dias)
        {

            var estoque = new Estoque();

            for (int i = 0; i < dias; i++)
            {
                estoque.AtualizarQualidade();
            }

            return estoque;
        }

        [Fact]
        public void SulfurasNuncaDecrementaEmQualidade()
        {
            var estoque = ExecutarDiasDeVenda(2);

            var sulfurarAntes = estoque.Itens.First(x =>x.GetItem().Nome == "Sulfuras, Mão de Ragnaros");

            estoque.AtualizarQualidade();

            var sulfurarDepois = estoque.Itens.First(x =>x.GetItem().Nome == "Sulfuras, Mão de Ragnaros");

            Assert.Equal(sulfurarDepois.GetItem().Qualidade, sulfurarAntes.GetItem().Qualidade);
            Assert.Equal(sulfurarDepois.GetItem().Qualidade, 80);
        }

        [Fact]
        public void ItensDevemTerEntreZeroECinquentaDeQualidadeExcetoRagnaros()
        {
            var estoque = ExecutarDiasDeVenda(16);

            Assert.True(estoque.Itens.SkipWhile(x =>x.GetItem().Nome == "Sulfuras, Mão de Ragnaros").All(x =>x.GetItem().Qualidade <= 50 ||x.GetItem().Qualidade >= 0));
        }

        [Fact]
        public void NenhumItemPodeTemQualidadeAbaixoDeZero()
        {
            var estoque = ExecutarDiasDeVenda(9);

            Assert.True(estoque.Itens.All(x =>x.GetItem().Qualidade >= 0));
        }

        [Fact]
        public void AposOPrazoDeVendaAQualidadeDeveDegradarDuasVezes()
        {
            var estoque = ExecutarDiasDeVenda(11);

            var item = estoque.Itens.First(x =>x.GetItem().Nome == "+5 Vestimenta da Destreza");

            Assert.Equal(8, item.GetItem().Qualidade);
        }

        [Fact]
        public void QueijoBrieEnvelhecidoDeveAumentarAQualidadeAposPrazoDeVenda()
        {
            var estoque = ExecutarDiasDeVenda(3);

            Assert.True(estoque.Itens.Any(x =>x.GetItem().Nome == "Queijo Brie Envelhecido" &&x.GetItem().Qualidade == 4));
        }

        [Fact]
        public void QualidadeDoPasseParaBastidoresAumentaAoFicaMaisPróximoDoDiaDePrazo()
        {
            var estoque = ExecutarDiasDeVenda(5);

            var item = estoque.Itens.First(x =>x.GetItem().Nome == "Passes para os bastidores do show TAFKAL80ETC ");

            Assert.Equal(25, item.GetItem().Qualidade);
        }

        [Fact]
        public void QualidadeDoPasseParaBastidoresAumentaEm2AoFicaA10DiasDoDiaDePrazo()
        {
            var estoque = ExecutarDiasDeVenda(6);

            var item = estoque.Itens.First(x =>x.GetItem().Nome == "Passes para os bastidores do show TAFKAL80ETC ");

            Assert.Equal(27, item.GetItem().Qualidade);
        }


        [Fact]
        public void QualidadeDoPasseParaBastidoresAumentaEm3AoFicaA5DiasDoDiaDePrazo()
        {
            var estoque = ExecutarDiasDeVenda(12);

            var item = estoque.Itens.First(x =>x.GetItem().Nome == "Passes para os bastidores do show TAFKAL80ETC ");

            Assert.Equal(41, item.GetItem().Qualidade);
        }

        [Fact]
        public void AoPassarDoPrazoDeVendaOPasseTemQualidadeZero()
        {
            var estoque = ExecutarDiasDeVenda(16);

            var item = estoque.Itens.First(x =>x.GetItem().Nome == "Passes para os bastidores do show TAFKAL80ETC ");

            Assert.Equal(0, item.GetItem().Qualidade);
        }
    }
}