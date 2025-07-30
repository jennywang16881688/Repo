The automated script performs the following steps:
- Login to demo.snipeitapp.com
  username: admin
  password: password
  
- Create a new asset:
  Device: MacBook Pro 13"
  Status: Ready to Deploy
  Checked out to a randomly selected user
  Save the new asset
  
- Verify creation by locating the new asset in the asset list
  Validate details on the asset detail page
  Confirm matching history tab records for creation and checkout

Project Structure
├── pages/
│   ├── LoginPage.cs
│   ├── AssetCreationPage.cs
│   └── AssetHistoryPage.cs
├── tests/
│   └── Tests.cs
├── Playwright_test2.csproj
├── README.md


