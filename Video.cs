using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using SpeedTests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AutomaticTesting.Web.Brave.Latest
{
    public class Video
    {
        string name = "bastyonqa_zcGovp";
        string password = "FiKguuoF5cNFpJTFYscq";
        private string _buildName;
        private string _testName;
        private OpenQA.Selenium.Chrome.ChromeOptions _capability;
        IWebDriver _driver;
        ChromeOptions options = new ChromeOptions();
        Helper _helper = new Helper();
        const string url = "https://night.test.bastyon.com/authorization";
        string _keyWords = "oil invite enact shaft isolate surround annual olive uncle better public mistake";
        string _keyWordsField = "//*[@elementsid=\"inputloginkey\"]";
        string _signInButton = "//*[@class=\"enter\"]";
        string _videoButton = "//*[@class=\"far fa-play-circle\"]";
        string _firstVideoButton = "//*[@class=\"wpl opensviurl\"]";
        string _backButton = "//*[@class=\"header_logo all\"]";
        string _buttonTitle = "//*[@class=\"vjs-control-text\"]";
        ChromeDriverService service = ChromeDriverService.CreateDefaultService(@"Brave-Browser\Application\");

        [Obsolete]
        public Video(string browser,string version)
        {
            _buildName = "[C_sharp]" + DateTime.Now.ToShortDateString() + " " + "CheckVideo" + "|Chrome|";
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

        [Obsolete]
        public bool CheckVideo()
        {
            _capability.AddAdditionalCapability("name", _testName + _helper.GetCurrentMethodName(), true); // test name
            _capability.AddAdditionalCapability("build", _buildName, true);
            _capability.AddAdditionalCapability("name", _testName + _helper.GetCurrentMethodName(), true); // test name
            _capability.AddAdditionalCapability("build", _buildName, true);
            _driver = new RemoteWebDriver(new Uri($"https://{name}:{password}@hub-cloud.browserstack.com/wd/hub/"), _capability);
            //_driver = new ChromeDriver(service,options);
            _driver.Navigate().GoToUrl(url);
            IWebElement query;

            for (int i = 0; i < 20; i++)
            {
                try
                {
                    query = _driver.FindElement(By.XPath(_keyWordsField));
                    query.Click();
                    query.SendKeys(_keyWords);
                    break;
                }
                catch
                {
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                }
                if (i == 19)
                {
                    _driver.Quit();
                    return false;
                }
            }

            for (int i = 0; i < 20; i++)
            {
                try
                {
                    query = _driver.FindElement(By.XPath(_signInButton));
                    query.Click();
                    break;
                }
                catch
                {
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                }
                if (i == 19)
                {
                    _driver.Quit();
                    return false;
                }
            }

            for (int i = 0; i < 20; i++)
            {
                try
                {
                    query = _driver.FindElement(By.XPath(_videoButton));
                    query.Click();
                    Thread.Sleep(TimeSpan.FromSeconds(4));
                    break;
                }
                catch
                {
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                }
                if (i == 19)
                {
                    _driver.Quit();
                    return false;
                }
            }

            for (int i = 0; i < 20; i++)
            {
                try
                {
                    query = _driver.FindElement(By.XPath(_firstVideoButton));
                    query.Click();
                    Thread.Sleep(TimeSpan.FromSeconds(4));
                    query = _driver.FindElement(By.XPath(_buttonTitle));
                    if (query.Text == "Pause")
                    {
                        Console.WriteLine("Видео Загружено");
                        return true;
                    }
                    else
                    {
                        _driver.Quit();
                        return false;
                    }


                }
                catch
                {
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                }
                if (i == 19)
                {
                    _driver.Quit();
                    return false;
                }
            }

            for (int i = 0; i < 20; i++)
            {
                try
                {
                    query = _driver.FindElement(By.XPath(_backButton));
                    query.Click();
                    _helper.SendMessage("Проигрывание видео: Success");                   
                    ((IJavaScriptExecutor)_driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"passed\", \"reason\": \" error shown!\"}}");
                    _driver.Quit();
                    break;
                }
                catch
                {
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                }
                if (i == 19)
                {
                    _driver.Quit();
                    return false;
                }

            }
            _driver.Quit();
            return true;
        }
    }

}
