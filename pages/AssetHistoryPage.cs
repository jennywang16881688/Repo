
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

        //  Safely wait for the History link to appear before interacting
        var historyLink = _page.GetByRole(AriaRole.Link, new() { Name = "History" });
        await historyLink.WaitForAsync(); // Ensures element is ready
        await historyLink.ClickAsync();   // Performs the click once visible
    }
}
