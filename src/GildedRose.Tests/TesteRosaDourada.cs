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

            var sulfurarAntes = app.Itens.First(x => x.Nome == "Sulfuras, M�o de Ragnaros");

            app.AtualizarQualidade();

            var sulfurarDepois = app.Itens.First(x => x.Nome == "Sulfuras, M�o de Ragnaros");

            Assert.Equal(sulfurarDepois.Qualidade, sulfurarAntes.Qualidade);
            Assert.Equal(sulfurarDepois.Qualidade, 80);
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
    }
}