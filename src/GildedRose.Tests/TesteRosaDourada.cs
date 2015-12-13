using RosaDourada.Console;
using Xunit;
using System.Linq;

namespace RosaDourada.Testes
{
    public class TesteRosaDourada
    {
        private Programa ExecutarDiasDeVenda(int dias)
        {
            Programa.Main(new[] { "" });

            var app = Programa.App;
            int diasPassados = dias - 1;

            for (int i = 0; i < diasPassados; i++)
            {
                app.AtualizarQualidade();
            }

            return app;
        }

        [Fact]
        public void SulfurasNuncaDecrementaEmQualidade()
        {
            var app = ExecutarDiasDeVenda(2);

            var sulfurarAntes = app.Itens.First(x => x.Nome == "Sulfuras, Mão de Ragnaros");

            app.AtualizarQualidade();

            var sulfurarDepois = app.Itens.First(x => x.Nome == "Sulfuras, Mão de Ragnaros");

            Assert.Equal(sulfurarDepois.Qualidade, sulfurarAntes.Qualidade);
            Assert.Equal(sulfurarDepois.Qualidade, 80);
        }

        [Fact]
        public void ItensDevemTerEntreZeroECinquentaDeQualidadeExcetoRagnaros()
        {
            var app = ExecutarDiasDeVenda(16);

            Assert.True(app.Itens.SkipWhile(x => x.Nome == "Sulfuras, Mão de Ragnaros").All(x => x.Qualidade <= 50 || x.Qualidade >= 0));
        }

        [Fact]
        public void NenhumItemPodeTemQualidadeAbaixoDeZero()
        {
            var app = ExecutarDiasDeVenda(9);

            Assert.True(app.Itens.All(x => x.Qualidade >= 0));
        }

        [Fact]
        public void AposOPrazoDeVendaAQualidadeDeveDegradarDuasVezes()
        {
            var app = ExecutarDiasDeVenda(11);

            var item = app.Itens.First(x => x.Nome == "+5 Vestimenta da Destreza");

            Assert.Equal(8, item.Qualidade);
        }

        [Fact]
        public void QueijoBrieEnvelhecidoDeveAumentarAQualidadeAposPrazoDeVenda()
        {
            var app = ExecutarDiasDeVenda(3);

            Assert.True(app.Itens.Any(x => x.Nome == "Queijo Brie Envelhecido" && x.Qualidade == 4));
        }

        [Fact]
        public void QualidadeDoPasseParaBastidoresAumentaAoFicaMaisPróximoDoDiaDePrazo()
        {
            var app = ExecutarDiasDeVenda(5);

            var item = app.Itens.First(x => x.Nome == "Passes para os bastidores do show TAFKAL80ETC ");

            Assert.Equal(25, item.Qualidade);
        }

        [Fact]
        public void QualidadeDoPasseParaBastidoresAumentaEm2AoFicaA10DiasDoDiaDePrazo()
        {
            var app = ExecutarDiasDeVenda(6);

            var item = app.Itens.First(x => x.Nome == "Passes para os bastidores do show TAFKAL80ETC ");

            Assert.Equal(27, item.Qualidade);
        }


        [Fact]
        public void QualidadeDoPasseParaBastidoresAumentaEm3AoFicaA5DiasDoDiaDePrazo()
        {
            var app = ExecutarDiasDeVenda(12);

            var item = app.Itens.First(x => x.Nome == "Passes para os bastidores do show TAFKAL80ETC ");

            Assert.Equal(41, item.Qualidade);
        }

        [Fact]
        public void AoPassarDoPrazoDeVendaOPasseTemQualidadeZero()
        {
            var app = ExecutarDiasDeVenda(16);

            var item = app.Itens.First(x => x.Nome == "Passes para os bastidores do show TAFKAL80ETC ");

            Assert.Equal(0, item.Qualidade);
        }
    }
}