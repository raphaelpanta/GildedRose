using RosaDourada.Console;
using Xunit;
using System.Linq;

namespace RosaDourada.Testes
{
    public class TesteRosaDourada
    {
        [Fact]
        public void TestarAVeracidade()
        {
            Assert.True(true);
        }

        [Fact]
        public void SulfurasNuncaDecrementaEmQualidade()
        {
            Programa.Main(new[] { "" });

            var app = Programa.App;

            app.AtualizarQualidade();

            var sulfurarAntes = app.Itens.First(x => x.Nome == "Sulfuras, Mão de Ragnaros");

            app.AtualizarQualidade();

            var sulfurarDepois = app.Itens.First(x => x.Nome == "Sulfuras, Mão de Ragnaros");

            Assert.Equal(sulfurarDepois.Qualidade, sulfurarAntes.Qualidade);
            Assert.Equal(sulfurarDepois.Qualidade, 80);
        }

        [Fact]
        public void ItensDevemTerEntreZeroECinquentaDeQualidadeExcetoRagnaros()
        {
             Programa.Main(new[] { "" });

            var app = Programa.App;

            for(var i = 1; i< 15; i++)
            {
                app.AtualizarQualidade();
            }

            Assert.True(app.Itens.SkipWhile(x => x.Nome == "Sulfuras, Mão de Ragnaros").All(x => x.Qualidade <= 50 || x.Qualidade >= 0));
        }

        [Fact]
        public void NenhumItemPodeTemQualidadeAbaixoDeZero()
        {
            Programa.Main(new[] { "" });

            var app = Programa.App;

            app.AtualizarQualidade();
            app.AtualizarQualidade();
            app.AtualizarQualidade();
            app.AtualizarQualidade();
            app.AtualizarQualidade();
            app.AtualizarQualidade();
            app.AtualizarQualidade();
            app.AtualizarQualidade();

            Assert.True(app.Itens.All(x => x.Qualidade >= 0));
        }

        [Fact]
        public void AposOPrazoDeVendaAQualidadeDeveDegradarDuasVezes()
        {
            Programa.Main(new[] { "" });

            var app = Programa.App;

            app.AtualizarQualidade();
            app.AtualizarQualidade();
            app.AtualizarQualidade();
            app.AtualizarQualidade();
            app.AtualizarQualidade();
            app.AtualizarQualidade();
            app.AtualizarQualidade();
            app.AtualizarQualidade();
            app.AtualizarQualidade();
            app.AtualizarQualidade();

            var item = app.Itens.First(x => x.Nome == "+5 Vestimenta da Destreza");

            Assert.Equal(8, item.Qualidade);
        }

        [Fact]
        public void QueijoBrieEnvelhecidoDeveAumentarAQualidadeAposPrazoDeVenda()
        {
            Programa.Main(new[] { "" });

            var app = Programa.App;

            app.AtualizarQualidade();
            app.AtualizarQualidade();

            Assert.True(app.Itens.Any(x => x.Nome == "Queijo Brie Envelhecido" && x.Qualidade == 4));
        }

    }
}