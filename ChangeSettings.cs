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
    public class ChangeSettings
    {
        string name = "bastyonqa_zcGovp";
        string password = "FiKguuoF5cNFpJTFYscq";
        private string _buildName;
        private string _testName;        
        private OpenQA.Selenium.Chrome.ChromeOptions _capability;
        ChromeOptions options = new ChromeOptions();
        private IWebDriver _driver;
        const string url = "https://night.test.bastyon.com/authorization";
        string _keyWords1 = "bless reward sorry rather equal medal song task peanut brush summer retreat";
        string _keyWordsField = "//*[@elementsid=\"inputloginkey\"]";
        string _signInButton = "//*[@class=\"enter\"]";
        string _moneyButton = "//*[@class=\"number\"]";
        string _accountSettingsButton = "//*[@rid=\"test\"]";
        string _nicknameInputField = "//*[@class=\"nickname input\"]";
        string _newNickname = "3062512713Test2";
        string _saveButton = "//*[@elementsid=\"usave\"]";
        string _upperNickname = "//*[@class=\"adr\"]";
        string _oldNickname = "Test3062512713";
        Helper _helper = new Helper();
        ChromeDriverService service = ChromeDriverService.CreateDefaultService(@"Brave-Browser\Application\");

        [Obsolete]
        public ChangeSettings(string browser, string version)
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

        [Obsolete]
        public bool ChangeNickname()
        {
            _capability.AddAdditionalCapability("name", _testName + _helper.GetCurrentMethodName(), true); // test name
            _capability.AddAdditionalCapability("build", _buildName, true);
           
            _capability.AddAdditionalCapability("name", _testName + _helper.GetCurrentMethodName(), true); // test name
            _capability.AddAdditionalCapability("build", _buildName, true);
            _driver = new RemoteWebDriver(
                new Uri($"https://{name}:{password}@hub-cloud.browserstack.com/wd/hub/"), _capability
            ) ;
            
            _driver.Navigate().GoToUrl(url);
            IWebElement query;
            for (int i = 0; i < 20; i++)
            {
                try
                {
                    query = _driver.FindElement(By.XPath(_keyWordsField));
                    query.Click();
                    query.SendKeys(_keyWords1);

                    break;
                }
                catch
                {
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                }
                if (i == 19)
                {
                    _helper.SendMessage("Смена никнеима: Failed");
                   
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
                    _helper.SendMessage("Смена никнеима: Failed");
                    
                    _driver.Quit();
                    return false;
                }
            }

            for (int i = 0; i < 20; i++)
            {
                try
                {
                    query = _driver.FindElement(By.XPath(_moneyButton));
                    query.Click();
                    break;
                }
                catch
                {
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                }
                if (i == 19)
                {
                    _helper.SendMessage("Смена никнеима: Failed");
                    
                    _driver.Quit();
                    return false;
                }
            }
            for (int i = 0; i < 20; i++)
            {
                try
                {
                    query = _driver.FindElement(By.XPath(_accountSettingsButton));
                    query.Click();
                    break;
                }
                catch
                {
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                }
                if (i == 19)
                {
                    _helper.SendMessage("Смена никнеима: Failed");
                    
                    _driver.Quit();
                    return false;
                }
            }
            for (int i = 0; i < 20; i++)
            {
                try
                {
                    query = _driver.FindElement(By.XPath(_nicknameInputField));
                    query.Click();
                    for (int k = 0; k < 40; k++)
                    {
                        query.SendKeys(Keys.Backspace);
                    }
                    _newNickname = _helper.GetRandomString();
                    query.SendKeys(_newNickname);
                    break;
                }
                catch
                {
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                }
                if (i == 19)
                {
                    _helper.SendMessage("Смена никнеима: Failed");
                    
                    _driver.Quit();
                    return false;
                }
            }

            for (int i = 0; i < 20; i++)
            {
                try
                {
                    query = _driver.FindElement(By.XPath(_saveButton));
                    query.Click();
                    break;
                }
                catch
                {
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                }
                if (i == 19)
                {
                    _helper.SendMessage("Смена никнеима: Failed");
                    
                    _driver.Quit();
                    return false;
                }
            }
            for (int i = 0; i < 20; i++)
            {
                try
                {
                    query = _driver.FindElement(By.XPath(_upperNickname));

                    if (query.Text == _newNickname)
                    {
                        _helper.SendMessage("Смена никнеима: Succes");
                        Console.WriteLine("Brave | Смена никнеима: Succes");
                        _driver.Quit();
                        return true;
                    }
                    else
                    {
                        Thread.Sleep(1000);
                    }

                }
                catch
                {
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                }
                if (i == 19)
                {
                    _helper.SendMessage("Смена никнеима: Failed");
                    
                    _driver.Quit();
                    return false;
                }
            }
            _helper.SendMessage("Смена никнеима: Succes");
            ((IJavaScriptExecutor)_driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"passed\", \"reason\": \" error shown!\"}}");
            _driver.Quit();
            return true;
        }
    }
    
}
