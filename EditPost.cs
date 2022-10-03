using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using SpeedTests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AutomaticTesting
{
    public class EditPost
    {
        string name = "bastyonqa_zcGovp";
        string password = "FiKguuoF5cNFpJTFYscq";
        private string _buildName;
        private string _testName;
        private OpenQA.Selenium.Chrome.ChromeOptions _capability;
        IWebDriver driver;
        ChromeOptions options = new ChromeOptions();
        Helper _helper = new Helper();
        string _loginInputField = "//*[@elementsid=\"inputloginkey\"]";
        string _loginKey = "bless reward sorry rather equal medal song task peanut brush summer retreat";
        string _signInButton = "//*[@class=\"enter\"]";
        string _profileButton = "//*[@class=\"usericon\"]";
        string _myPostsButton = "//*[@class=\"workstation\"]";
        string _myPostSettings = "//*[@class=\"fas fa-ellipsis-h\"]";
        string _editPostButton = "//*[@elementsid=\"lenta_menuitem_edit\"]";
        string _savePostSettingsButton = "//*[@elementsid=\"usave\"]";
        string _errorEditMessage = "//*[@elementsid=\"errorLinewrapper\"]";



        [Obsolete]
        public EditPost(string browser, string version)
        {
            _buildName = "[C_sharp]" + DateTime.Now.ToShortDateString() + " " + "Create Post" + "|Chrome|";
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
        }
        [Obsolete]
        public bool EmptyPost()
        {
            _capability.AddAdditionalCapability("name", _testName + _helper.GetCurrentMethodName(), true); // test name
            _capability.AddAdditionalCapability("build", _buildName, true);
            _capability.AddAdditionalCapability("name", _testName + _helper.GetCurrentMethodName(), true); // test name
            _capability.AddAdditionalCapability("build", _buildName, true);
            driver = new RemoteWebDriver(new Uri($"https://{name}:{password}@hub-cloud.browserstack.com/wd/hub/"), _capability);
            Actions action = new Actions(driver);
            driver.Navigate().GoToUrl("https://test.pocketnet.app/authorization");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            IWebElement query;
            query = driver.FindElement(By.XPath(_loginInputField));
            query.Click();

            query.SendKeys(_loginKey);

            query = driver.FindElement(By.XPath(_signInButton));
            query.Click();

            Thread.Sleep(1000);

            query = driver.FindElement(By.XPath(_profileButton));
            query.Click();

            query = driver.FindElement(By.XPath(_myPostsButton));
            query.Click();

            query = driver.FindElement(By.XPath(_myPostSettings));
            query.Click();

            query = driver.FindElement(By.XPath(_editPostButton));
            query.Click();

            query = driver.FindElement(By.XPath(_savePostSettingsButton));
            query.Click();

            for (int i = 0; i < 120; i++)
            {
                if (i == 119)
                {
                    _helper.SendMessage("Создание пустого поста: False");

                    driver.Quit();
                    break;
                }
                try
                {
                    Thread.Sleep(1000);
                    query = driver.FindElement(By.XPath(_errorEditMessage));
                    break;
                }
                catch
                {

                }
            }
            if (query.Displayed != false)
            {
                _helper.SendMessage("Создание пустого поста: Success");
                ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"passed\", \"reason\": \" error shown!\"}}");
                driver.Quit();
                return true;
            }
            else
            {
                _helper.SendMessage("Создание пустого поста: Failed");

                driver.Quit();
                return false;
            }

        }
    }
   
}
