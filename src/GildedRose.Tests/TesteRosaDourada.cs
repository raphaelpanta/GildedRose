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
    }
}