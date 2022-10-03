using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using SpeedTests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;


namespace AutomaticTesting
{
    public class LastComments
    {
        string name = "bastyonqa_zcGovp";
        string password = "FiKguuoF5cNFpJTFYscq";
        private string _buildName;
        private string _testName;
        private OpenQA.Selenium.Chrome.ChromeOptions _capability;
        ChromeOptions options = new ChromeOptions();
        private IWebDriver _driver;
        const string url = "https://test.pocketnet.app/authorization";
        string _loginKey = "bless reward sorry rather equal medal song task peanut brush summer retreat";
        string _loginInputField = "//*[@elementsid=\"inputloginkey\"]";
        string _signInButton = "//*[@class=\"enter\"]";
        string _lastCommentButton = "//*[@class=\"commentPaddingWrapper\"]";
        string _closeButton = "//*[@class=\"fa fa-times\"]";
        Helper _helper = new Helper();
        ChromeDriverService service = ChromeDriverService.CreateDefaultService(@"Brave-Browser\Application\");


        [Obsolete]
        public LastComments(string browser, string version)
        {
            _buildName = "[C_sharp]" + DateTime.Now.ToShortDateString() + " " + "Change Settings" + "|Chrome|";
            _testName = "[C_sharp] ";
            _helper = new Helper();
            _capability = new OpenQA.Selenium.Chrome.ChromeOptions();
            _capability.AddAdditionalCapability("os_version", "10", true);
            _capability.AddAdditionalCapability("resolution", "1920x1080", true);
            _capability.AddAdditionalCapability("browser", browser, true);
            _capability.AddAdditionalCapability("browser_version", version, true);
            _capability.AddAdditionalCapability("os", "Windows", true);
            _capability.AddAdditionalCapability("browserstack.user", "bastyonqa_zcGovp", true);
            _capability.AddAdditionalCapability("browserstack.key", "FiKguuoF5cNFpJTFYscq", true);


            //service.EnableVerboseLogging = false;
            //service.SuppressInitialDiagnosticInformation = true;
            //service.HideCommandPromptWindow = true;
            //options.AddArgument("--no-sandbox");
            //options.AddArgument("--headless");
            //options.BinaryLocation = @"Brave-Browser\Application\brave.exe";
        }
        public bool CheckLastComment()
        {
            _capability.AddAdditionalCapability("name", _testName + _helper.GetCurrentMethodName(), true); // test name
            _capability.AddAdditionalCapability("build", _buildName, true);
            _capability.AddAdditionalCapability("name", _testName + _helper.GetCurrentMethodName(), true); // test name
            _capability.AddAdditionalCapability("build", _buildName, true);
            _driver = new RemoteWebDriver(new Uri($"https://{name}:{password}@hub-cloud.browserstack.com/wd/hub/"), _capability);
            OpenQA.Selenium.Interactions.Actions action = new OpenQA.Selenium.Interactions.Actions(_driver);
            _driver.Navigate().GoToUrl("https://test.pocketnet.app/authorization");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            IWebElement query;
            query = _driver.FindElement(By.XPath(_loginInputField));
            query.Click();

            query.SendKeys(_loginKey);

            query = _driver.FindElement(By.XPath(_signInButton));
            query.Click();

            Thread.Sleep(1000);

            query = _driver.FindElement(By.XPath(_lastCommentButton));
            query.Click();

            Thread.Sleep(1000);

            query = _driver.FindElement(By.XPath(_closeButton));
            query.Click();

            for (int i = 0; i < 120; i++)
            {
                Thread.Sleep(1000);
                try
                {
                    if (_driver.Url.Contains("index"))
                    {
                        _helper.SendMessage("Авторизация: Succes");
                        ((IJavaScriptExecutor)_driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"passed\", \"reason\": \" error shown!\"}}");
                        _driver.Quit();
                        return true;
                    }
                }
                catch
                {
                }

            }
            _helper.SendMessage("Авторизация: Failed");
            _driver.Quit();
            return false;

        }

    }
}
