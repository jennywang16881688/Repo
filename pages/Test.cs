using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Tests : PageTest
{
    [Test]
    public async Task MyTest()
    {
        //var page = await context.NewPageAsync();

        var loginPage = new LoginPage(Page);
        await loginPage.LoginAsync("admin", "password"); //  Login first

        var assetPage = new AssetCreationPage(Page);
        await assetPage.CreateAssetAsync(); //  Now safe to create asset

    }
}
