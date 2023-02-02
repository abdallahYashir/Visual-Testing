using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PercyIO.Selenium;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace Visual_Testing;

[TestClass]
public class JumpStartTest
{
    private WebDriver _driver = null!;

    [TestInitialize]
    public void Setup()
    {
        _driver = ChromeSession();
        // TODO: add implicit wait 5 seconds
    }

    [TestMethod]
    public void Verify()
    {
        _driver.Navigate().GoToUrl("http://localhost:8080/customers");
        Percy.Snapshot(_driver, "Customers");

        _driver.Navigate().GoToUrl("http://localhost:8080/orders");
        Percy.Snapshot(_driver, "Orders");

        _driver.Navigate().GoToUrl("http://localhost:8080/about");
        Percy.Snapshot(_driver, "About");

        _driver.Navigate().GoToUrl("http://localhost:8080/login");
        Percy.Snapshot(_driver, "Login");

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