using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace Visual_Testing;

[TestClass]
public class JumpStartTest
{
    private IWebDriver _driver = null!;

    [TestInitialize]
    public void Setup()
    {
        _driver = ChromeSession();
    }

    [TestMethod]
    public void Verify()
    {
        _driver.Navigate().GoToUrl("http://localhost:8080/customers");
    }

    [TestCleanup]
    public void TearDown()
    {
        _driver?.Quit();
    }

    private WebDriver ChromeSession()
    {
        new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
        return new ChromeDriver();
    }
}