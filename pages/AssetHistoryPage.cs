// using Microsoft.Playwright.NUnit;
// using Microsoft.Playwright;

// [Parallelizable(ParallelScope.Self)]
// [TestFixture]
// public class Tests : PageTest
// {
//     [Test]
//     public async Task MyTest()
//     {
//         await Page.GotoAsync("https://demo.snipeitapp.com/login");
//         await Page.GetByRole(AriaRole.Textbox, new() { Name = "Username" }).ClickAsync();
//         await Page.GetByRole(AriaRole.Textbox, new() { Name = "Username" }).ClickAsync();
//         await Page.GetByRole(AriaRole.Textbox, new() { Name = "Username" }).FillAsync("admin");
//         await Page.GetByRole(AriaRole.Textbox, new() { Name = "Password" }).ClickAsync();
//         await Page.GetByRole(AriaRole.Textbox, new() { Name = "Password" }).FillAsync("password");
//         await Page.GetByRole(AriaRole.Button, new() { Name = "Login" }).ClickAsync();
//         await Page.GetByRole(AriaRole.Link, new() { Name = "Assets view all" }).ClickAsync();
//         await Page.GetByRole(AriaRole.Link, new() { Name = "Create New" }).ClickAsync();
//         await Page.GetByLabel("Select Company").GetByText("Select Company").ClickAsync();
//         await Page.GetByText("Bauch Inc").ClickAsync();
//         await Page.GetByRole(AriaRole.Textbox, new() { Name = "Asset Tag", Exact = true }).ClickAsync();
//         await Page.GetByRole(AriaRole.Textbox, new() { Name = "Asset Tag", Exact = true }).FillAsync("99999999999");
//         await Page.GetByRole(AriaRole.Textbox, new() { Name = "Serial" }).ClickAsync();
//         await Page.GetByRole(AriaRole.Textbox, new() { Name = "Serial" }).FillAsync("888888888888");
//         await Page.GetByText("Select a Model").ClickAsync();
//         await Page.GetByText("Laptops - Macbook Pro 13").ClickAsync();
//         await Page.GetByLabel("Select Status").GetByText("Select Status").ClickAsync();
//         await Page.GetByRole(AriaRole.Option, new() { Name = "Ready to Deploy" }).ClickAsync();
//         await Page.Locator("#assignto_selector").GetByText("User").ClickAsync();
//         await Page.Locator("#select2-assigned_user_select-container").ClickAsync();
//         await Page.GetByText("Abshire, Nola (schuster.evert) - #").ClickAsync();
//         //await Page.Locator("button[name=\"submit\"]").ClickAsync();
//         await Page.GetByRole(AriaRole.Link, new() { Name = "Assets view all" }).ClickAsync();
//         await Page.GetByText("Asset Tag", new() { Exact = true }).ClickAsync();
//         await Page.GetByText("Asset Tag", new() { Exact = true }).ClickAsync();
//         await Page.GetByRole(AriaRole.Link, new() { Name = "99999999999" }).ClickAsync();
//         await Page.GetByRole(AriaRole.Link, new() { Name = "History" }).ClickAsync();
//     }
// }

using Microsoft.Playwright;

public class AssetHistoryPage
{
    private readonly IPage _page;

    public AssetHistoryPage(IPage page)
    {
        _page = page;
    }

    public async Task ViewAssetHistoryAsync()
    {
        // Navigate to 'Assets view all'
        await _page.GetByRole(AriaRole.Link, new() { Name = "Assets view all" }).ClickAsync();

        // Click on "Asset Tag" twice to ensure correct filtering or selection
        await _page.GetByText("Asset Tag", new() { Exact = true }).ClickAsync();
        await _page.GetByText("Asset Tag", new() { Exact = true }).ClickAsync();

        // Click into the specific asset entry
        await _page.GetByRole(AriaRole.Link, new() { Name = "BO4007126358" }).ClickAsync();

        // ✅ Safely wait for the History link to appear before interacting
        var historyLink = _page.GetByRole(AriaRole.Link, new() { Name = "History" });
        await historyLink.WaitForAsync(); // Ensures element is ready
        await historyLink.ClickAsync();   // Performs the click once visible
    }
}