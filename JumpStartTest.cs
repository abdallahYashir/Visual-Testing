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

        var h4El = _driver.FindElement(By.CssSelector(".container .row h4"));
        var h4ElFontSize = h4El.GetCssValue("font-size");
        var h4ElMarginTop = h4El.GetCssValue("margin-top");
        var h4ElMarginBottom = h4El.GetCssValue("margin-bottom");
        var h4ElFontFamily = h4El.GetCssValue("font-family");
        var h4ElFontWeight = h4El.GetCssValue("font-weight");
        var h4ElLineHeight = h4El.GetCssValue("line-height");
        var h4ElColor = h4El.GetCssValue("color");

        Assert.AreEqual("18px", h4ElFontSize);
        Assert.AreEqual("10px", h4ElMarginTop);
        Assert.AreEqual("10px", h4ElMarginBottom);
        Assert.AreEqual("\"Open Sans\"", h4ElFontFamily);
        Assert.AreEqual("500", h4ElFontWeight);
        Assert.AreEqual("19.8px", h4ElLineHeight);
        Assert.AreEqual("rgba(51, 51, 51, 1)", h4ElColor);
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