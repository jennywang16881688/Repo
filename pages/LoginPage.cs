using Microsoft.Playwright;

public class LoginPage
{
    private readonly IPage _page;

    public LoginPage(IPage page)
    {
        _page = page;
    }

    public async Task LoginAsync(string username, string password)
    {
        // ✅ Wait for the page to load completely before interacting
        await _page.GotoAsync("https://demo.snipeitapp.com/login");
        await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);

        // ✅ Safe wait: ensure the "Username" textbox is ready before filling
        var usernameField = _page.GetByRole(AriaRole.Textbox, new() { Name = "Username" });
        await usernameField.WaitForAsync(); // Wait for element to appear
        await usernameField.FillAsync(username); // Fill in username

        // ✅ Same approach for password field
        var passwordField = _page.GetByRole(AriaRole.Textbox, new() { Name = "Password" });
        await passwordField.WaitForAsync();
        await passwordField.FillAsync(password);

        // ✅ Click the login button once everything is filled
        var loginButton = _page.GetByRole(AriaRole.Button, new() { Name = "Login" });
        await loginButton.WaitForAsync();
        await loginButton.ClickAsync();
    }
}