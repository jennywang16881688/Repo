using Microsoft.Playwright;

public class AssetCreationPage
{
    private readonly IPage _page;

    public AssetCreationPage(IPage page)
    {
        _page = page;
    }

    public async Task CreateAssetAsync()
    {
        //  Step 1: Navigate and wait for page to load
        await _page.GotoAsync("https://demo.snipeitapp.com/login");
        await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        await _page.WaitForTimeoutAsync(1000); // Small buffer in case of delayed rendering

        //  Step 2: Fill in asset tag directly
        await _page.GetByRole(AriaRole.Textbox, new() { Name = "Asset Tag" })
                   .FillAsync("BO4007126358");

        //  Step 3: Use direct locator for "Asset Name" to avoid timeout
        var assetNameField = _page.Locator("input[name='assetName']");
        await assetNameField.WaitForAsync(new() { Timeout = 20000 });
        await assetNameField.FillAsync("Thermal Scanner");

        //  Step 4: Handle dropdown with explicit overload
        var assetTypeDropdown = _page.GetByRole(AriaRole.Combobox, new() { Name = "Asset Type" });
        await assetTypeDropdown.WaitForAsync();
        await assetTypeDropdown.SelectOptionAsync(new SelectOptionValue { Label = "Electronics" });

        //  Step 5: Scroll & retry logic for "Hartmann Ltd"
        var companyText = _page.Locator("text=Hartmann Ltd");
        bool found = false;
        for (int i = 0; i < 3; i++)
        {
            try
            {
                await _page.EvaluateAsync("window.scrollBy(0, 3000)");
                await companyText.WaitForAsync(new() { Timeout = 30000 });
                found = true;
                break;
            }
            catch
            {
                await _page.ScreenshotAsync(new() { Path = $"hartmann_retry_{i}.png" });
            }
        }

        if (!found)
            throw new TimeoutException("Could not locate 'Hartmann Ltd' after multiple attempts.");

        await companyText.ClickAsync();

        //  Step 6: Create asset and verify success
        await _page.GetByRole(AriaRole.Button, new() { Name = "Create Asset" }).ClickAsync();
        await _page.GetByText("Asset successfully created")
                   .WaitForAsync(new() { Timeout = 30000 });
    }
}


