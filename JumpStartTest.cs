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

    // TODO: test method including asserts for acceptance criteria -- just copy existing attributes
    [TestMethod]
    public void VerifyFunctionalTest()
    {
        _driver.Navigate().GoToUrl("http://localhost:8080/customers");
        _driver.FindElement(By.CssSelector("a[href='/customers/1/orders']")).Click();

        var tdEl = _driver.FindElement(By.CssSelector("table td"));
        var tdElWidth = tdEl.GetCssValue("width");
        var tdElHeight = tdEl.GetCssValue("height");
        var tdElPadding = tdEl.GetCssValue("padding");
        var tdElFontSize = tdEl.GetCssValue("font-size");
        var tdElColor = tdEl.GetCssValue("color");
        var tdElBackgroundColor = tdEl.GetCssValue("background-color");

        Assert.AreEqual("242.5px", tdElWidth);
        Assert.AreEqual("20px", tdElHeight);
        Assert.AreEqual("0px", tdElPadding);
        Assert.AreEqual("14px", tdElFontSize);
        Assert.AreEqual("rgba(51, 51, 51, 1)", tdElColor);
        Assert.AreEqual("rgba(0, 0, 0, 0)", tdElBackgroundColor);

        // think visual testing - how the element UI is going to change - another example with the h4

        // font-size: 18px; margin-top: 10px; margin - bottom: 10px;font-family: inherit; font - weight: 500; line - height: 1.1; color: inherit
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