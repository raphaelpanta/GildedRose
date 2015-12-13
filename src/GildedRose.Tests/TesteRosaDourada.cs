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

            var sulfurarAntes = estoque.Itens.First(x => x.Nome == "Sulfuras, Mão de Ragnaros");

            estoque.AtualizarQualidade();

            var sulfurarDepois = estoque.Itens.First(x => x.Nome == "Sulfuras, Mão de Ragnaros");

            Assert.Equal(sulfurarDepois.Qualidade, sulfurarAntes.Qualidade);
            Assert.Equal(sulfurarDepois.Qualidade, 80);
        }

        [Fact]
        public void ItensDevemTerEntreZeroECinquentaDeQualidadeExcetoRagnaros()
        {
            var estoque = ExecutarDiasDeVenda(16);

            Assert.True(estoque.Itens.SkipWhile(x => x.Nome == "Sulfuras, Mão de Ragnaros").All(x => x.Qualidade <= 50 || x.Qualidade >= 0));
        }

        [Fact]
        public void NenhumItemPodeTemQualidadeAbaixoDeZero()
        {
            var estoque = ExecutarDiasDeVenda(9);

            Assert.True(estoque.Itens.All(x => x.Qualidade >= 0));
        }

        [Fact]
        public void AposOPrazoDeVendaAQualidadeDeveDegradarDuasVezes()
        {
            var estoque = ExecutarDiasDeVenda(11);

            var item = estoque.Itens.First(x => x.Nome == "+5 Vestimenta da Destreza");

            Assert.Equal(8, item.Qualidade);
        }

        [Fact]
        public void QueijoBrieEnvelhecidoDeveAumentarAQualidadeAposPrazoDeVenda()
        {
            var estoque = ExecutarDiasDeVenda(3);

            Assert.True(estoque.Itens.Any(x => x.Nome == "Queijo Brie Envelhecido" && x.Qualidade == 4));
        }

        [Fact]
        public void QualidadeDoPasseParaBastidoresAumentaAoFicaMaisPróximoDoDiaDePrazo()
        {
            var estoque = ExecutarDiasDeVenda(5);

            var item = estoque.Itens.First(x => x.Nome == "Passes para os bastidores do show TAFKAL80ETC ");

            Assert.Equal(25, item.Qualidade);
        }

        [Fact]
        public void QualidadeDoPasseParaBastidoresAumentaEm2AoFicaA10DiasDoDiaDePrazo()
        {
            var estoque = ExecutarDiasDeVenda(6);

            var item = estoque.Itens.First(x => x.Nome == "Passes para os bastidores do show TAFKAL80ETC ");

            Assert.Equal(27, item.Qualidade);
        }


        [Fact]
        public void QualidadeDoPasseParaBastidoresAumentaEm3AoFicaA5DiasDoDiaDePrazo()
        {
            var estoque = ExecutarDiasDeVenda(12);

            var item = estoque.Itens.First(x => x.Nome == "Passes para os bastidores do show TAFKAL80ETC ");

            Assert.Equal(41, item.Qualidade);
        }

        [Fact]
        public void AoPassarDoPrazoDeVendaOPasseTemQualidadeZero()
        {
            var estoque = ExecutarDiasDeVenda(16);

            var item = estoque.Itens.First(x => x.Nome == "Passes para os bastidores do show TAFKAL80ETC ");

            Assert.Equal(0, item.Qualidade);
        }
    }
}