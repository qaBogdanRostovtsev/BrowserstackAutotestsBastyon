using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpeedTests.Windows10.Web.Brave.Latest
{
    public class Registration
    {
        string name = "bastyonqa_zcGovp";
        string password = "FiKguuoF5cNFpJTFYscq";
        private string _buildName;
        private string _testName;
        private OpenQA.Selenium.Chrome.ChromeOptions _capability;
        IWebDriver driver;
        ChromeOptions options = new ChromeOptions();        
        Helper _helper = new Helper();
        string picPath = Path.GetFullPath("Files/pic.jpg");
        string vidPath = Path.GetFullPath("Files/vid.mp4");
        string errorNotify = "/html/body/div[15]";
        string regName = "//*[@elementsid=\"button_name_2\"]";
        string regEmail = "//*[@elementsid=\"button_email_2\"]";
        string regPhoto = "//*[@elementsid=\"fileuploader_input\"]";
        string submitRegPhoto = "//*[@elementsid=\"imageg_exitPanel\"]";
        string regTagOne = "//*[@cat=\"c2\"]";
        string regTagTwo = "//*[@cat=\"c18\"]";
        string copyKey = "//*[@elementsid=\"copycode\"]";
        string iSaveKey = "//*[@elementsid=\"dontshowagain\"]";
        string pkoinValue = @"/html/body/div[4]/div/div/div/div/div[1]/div[4]/div/div/div/span";
        string submitReg = @"/html/body/div[7]/div/div/div[2]/div[1]/div[2]/div/div/span[1]";
        string submitTags = @"/html/body/div[7]/div/div/div[2]/div[1]/div[1]/div/div[4]/div/div/div[4]/div[1]/button";
        string uploadQRButton = "//*[@elementsid=\"fileuploader_input\"]";
        string QRpath = Path.GetFullPath("Files/RedheadSorcQR.png");
        ChromeDriverService service = ChromeDriverService.CreateDefaultService(@"Brave-Browser\Application\");

        [Obsolete]
        public Registration(string browser, string version)
        {
            _buildName = "[C_sharp]" + DateTime.Now.ToShortDateString() + " " + "Registration" + "|Chrome|";
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
        public bool FullySuccefulRegistration()
        {
            _capability.AddAdditionalCapability("name", _testName + _helper.GetCurrentMethodName(), true); // test name
            _capability.AddAdditionalCapability("build", _buildName, true);
            _capability.AddAdditionalCapability("name", _testName + _helper.GetCurrentMethodName(), true); // test name
            _capability.AddAdditionalCapability("build", _buildName, true);
            driver = new RemoteWebDriver(new Uri($"https://{name}:{password}@hub-cloud.browserstack.com/wd/hub/"), _capability);           
            driver.Navigate().GoToUrl("https://night.test.bastyon.com/authorization");
            IWebElement query;
            for (; ; )
            {
                try
                {
                    query = driver.FindElement(By.XPath(regName));
                    query.SendKeys(_helper.GetRandomString());
                    break;
                }
                catch
                {

                }
            }
            for (; ; )
            {
                try
                {
                    query = driver.FindElement(By.XPath(regEmail));
                    query.SendKeys(_helper.GetRandomString() + "@gmail.com");
                    break;
                }
                catch
                {

                }
            }
            for (; ; )
            {
                try
                {
                    query = driver.FindElement(By.XPath(regPhoto));
                    query.SendKeys(picPath);
                    break;
                }
                catch
                {

                }
            }
            Thread.Sleep(5000);
            for (; ; )
            {
                try
                {
                    query = driver.FindElement(By.XPath(submitRegPhoto));
                    query.Click();
                    break;
                }
                catch (Exception ex)
                {
                }
            }
            for (; ; )
            {
                try
                {
                    query = driver.FindElement(By.XPath(submitReg));
                    query.Click();
                    break;
                }
                catch
                {

                }
            }
            for (; ; )
            {
                try
                {
                    query = driver.FindElement(By.XPath(regTagOne));
                    query.Click();
                    query = driver.FindElement(By.XPath(regTagTwo));
                    query.Click();
                    break;
                }
                catch
                {

                }
            }
            for (; ; )
            {
                try
                {
                    query = driver.FindElement(By.XPath(submitTags));
                    query.Click();
                    break;
                }
                catch
                {

                }
            }
            for (int i = 0; i < 300; i++)
            {
                try
                {
                    query = driver.FindElement(By.XPath(copyKey));
                    _helper.SendMessage("Регистрация: Succes");
                    
                    driver.Quit();
                    return true;
                }
                catch
                {
                    Thread.Sleep(1000);
                }
            }
            _helper.SendMessage("Регистрация: Failed");
           
            driver.Quit();
            return false;
        }
        
        public bool FullySuccefulAuthorizationByQR()
        {

            driver = new ChromeDriver(service, options);
            driver.Navigate().GoToUrl("https://test.pocketnet.app/authorization");
            IWebElement query;
            for(; ; )
            {
                try
                {
                    query = driver.FindElement(By.XPath(uploadQRButton));
                    query.SendKeys(QRpath);
                    break;
                }
                catch
                {

                }
            }
            for (int i = 0; i < 120; i++)
            {
                Thread.Sleep(1000);
                try
                {
                    if (driver.Url.Contains("index"))
                    {
                        _helper.SendMessage("Авторизация: Succes");
                        ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"passed\", \"reason\": \" error shown!\"}}");
                        driver.Quit();
                        return true;
                    }
                }
                catch
                {
                }

            }
            _helper.SendMessage("Авторизация: Failed");
            driver.Quit();
            return false;
        }
    }
}
