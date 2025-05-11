using NUnit.Framework;
using Assessment_Matching_Engine.Base;
using Assessment_Matching_Engine.Pages;
using System.Linq;

namespace Assessment_Matching_Engine.Tests
{
    public class RepertoireModuleTest : TestBase
    {
        [Test]
        public void VerifySupportedProductsInRepertoireModule()
        {
            var homePage = new HomePage(Driver, Wait);
            var repertoirePage = new RepertoirePage(Driver, Wait);

            homePage.NavigateTo();
            homePage.ExpandModulesMenu();
            homePage.ClickRepertoireModule();

            repertoirePage.ScrollToAdditionalFeatures();
            repertoirePage.ClickProductsSupported();

            var supportedProducts = repertoirePage.GetSupportedProductList();

            Assert.That(supportedProducts,Is.Not.Empty, "Supported product list should not be empty.");
            Assert.That(supportedProducts.All(p => !string.IsNullOrWhiteSpace(p)), "All product entries must be non-empty.");
        }
    }
}