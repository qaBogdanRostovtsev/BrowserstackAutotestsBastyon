using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;


namespace SpeedTests.Web.Brave.Latest
{
    
    public class CreatePost
    {
        string name = "bastyonqa_zcGovp";
        string password = "FiKguuoF5cNFpJTFYscq";
        private string _buildName;
        private string _testName;
        private OpenQA.Selenium.Chrome.ChromeOptions _capability;
        IWebDriver driver;
        ChromeOptions options = new ChromeOptions();
        Helper _helper = new Helper();
        string uploadQRCode = "//*[@elementsid=\"inputloginkey\"]";
        string keyQR = "face power flee use shrug hole stand immune legal soda mass word";
        string enterQR = "//*[@elementsid=\"buttonsignin\"]";
        string openCreatepostWindow = "//*[@elementsid=\"share-share\"]";
        string publishButton = "//*[@elementsid=\"spost\"]"; 
        string postText = "//*[@elementsid=\"emjInput\"]";
        string publishErrorMessage = "//*[@elementsid=\"errorLinewrapper\"]";
        string lastPostText = "/html/body/div[7]/div/div/div[3]/div/div/div[3]/div/div[3]/div/div/div[3]/div[1]/div/div/div[1]/div[1]/div[3]/div/div";
        string tagInput = "//*[@elementsid=\"sminputsearch_addtagsCategories\"]";
        string addedLink = "//*[@elementsid=\"peertubehref\"]";
        string addPhotoButton = "//*[@elementsid=\"fileuploader_input\"]";
        string lastPostImage = "/html/body/div[7]/div/div/div[3]/div/div/div[3]/div/div[3]/div/div/div[3]/div[1]/div/div/div[1]/div[1]/div[3]/div[2]/div/div/div";
        string addVideoButton = "//*[@elementsid=\"peertubeAddVideo\"]";
        string uploadVideoInput = "//*[@elementsid=\"upload-video-file\"]";
        string videoHeader = "//*[@elementsid=\"videotitle\"]";
        string picPath = "C:\\Users\\hello\\Documents\\images\\wallpaper1.jpg";
        string vidPath = Path.GetFullPath("Files/vid.mp4");
        string errorNotify = "/html/body/div[15]";
        string removeVideoBtn = "//*[@elementsid=\"removepeertube\"]";
        string tagError = "//*[@elementsid=\"errorLinewrapper\"]";
        ChromeDriverService service = ChromeDriverService.CreateDefaultService(@"Brave-Browser\Application\");

        [Obsolete]
        public CreatePost(string browser, string version)
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
            //service.EnableVerboseLogging = false;
            //service.SuppressInitialDiagnosticInformation = true;
            //service.HideCommandPromptWindow = true;
            //options.AddArgument("--no-sandbox");
            //options.AddArgument("--headless");
            //options.BinaryLocation = @"Brave-Browser\Application\brave.exe";
        }

        [Obsolete]
        public bool EmptyPost()
        {
            _capability.AddAdditionalCapability("name", _testName + _helper.GetCurrentMethodName(), true); // test name
            _capability.AddAdditionalCapability("build", _buildName, true);
            _capability.AddAdditionalCapability("name", _testName + _helper.GetCurrentMethodName(), true); // test name
            _capability.AddAdditionalCapability("build", _buildName, true);
            driver = new RemoteWebDriver(new Uri($"https://{name}:{password}@hub-cloud.browserstack.com/wd/hub/"), _capability);
            //driver = new ChromeDriver(service, options);
            Actions action = new Actions(driver);
            driver.Navigate().GoToUrl("https://night.test.bastyon.com/authorization");
            IWebElement query;
            for (; ; )
            {
                try
                {
                    // button "Upload QR Code"
                    query = driver.FindElement(By.XPath(uploadQRCode));
                    query.Click();
                    query.SendKeys(keyQR);
                    break;
                }
                catch
                {

                }
            }
            // button "Enter"
            query = driver.FindElement(By.XPath(enterQR));
            query.Click();
            Thread.Sleep(TimeSpan.FromSeconds(5));
            bool staleElement = true;

            while (staleElement)
            {
                try
                {
                    // open createpost window
                    query = driver.FindElement(By.XPath(openCreatepostWindow));
                    query.Click();
                    staleElement = false;
                    break;
                }
                catch (Exception e)
                {

                    staleElement = true;

                }

            }
            // button "Publish"
            for (int i = 0; i < 120; i++)
            {
              
                try
                {
                    Thread.Sleep(1000);
                    query = driver.FindElement(By.XPath(publishButton));
                    query.Click();
                    break;
                }
                catch
                {

                }
            }
           
            
            // error message
            for (int i = 0; i < 120; i++)
            {
                if (i == 119)
                {
                    _helper.SendMessage("Создание пустого поста: Success");
                    
                    driver.Quit();
                    break;
                }
                try
                {
                    Thread.Sleep(1000);
                    query = driver.FindElement(By.XPath(publishErrorMessage));
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
            driver.Quit();
        }

        [Obsolete]
        public bool PostWithTextInBody_AND_WithoutTags()
        {
            _capability.AddAdditionalCapability("name", _testName + _helper.GetCurrentMethodName(), true); // test name
            _capability.AddAdditionalCapability("build", _buildName, true);
            _capability.AddAdditionalCapability("name", _testName + _helper.GetCurrentMethodName(), true); // test name
            _capability.AddAdditionalCapability("build", _buildName, true);
            driver = new RemoteWebDriver(new Uri($"https://{name}:{password}@hub-cloud.browserstack.com/wd/hub/"), _capability);
            //driver = new ChromeDriver(service, options);
            Actions action = new Actions(driver);           
            driver.Navigate().GoToUrl("https://test.pocketnet.app/authorization");
            IWebElement query;
            for (; ; )
            {
                try
                {
                    // button "Upload QR Code"
                    query = driver.FindElement(By.XPath(uploadQRCode));
                    query.Click();
                    query.SendKeys(keyQR);
                    break;
                }
                catch
                {

                }
            }

            // button "Enter"
            query = driver.FindElement(By.XPath(enterQR));
            query.Click();
            Thread.Sleep(TimeSpan.FromSeconds(5));
            bool staleElement = true;

            while (staleElement)
            {
                try
                {
                    // open createpost window
                    query = driver.FindElement(By.XPath(openCreatepostWindow));
                    query.Click();
                    staleElement = false;
                }
                catch (Exception e)
                {
                    staleElement = true;
                }
            }
            staleElement = true;
            while (staleElement)
            {
                try
                {
                    query = driver.FindElement(By.XPath(
                        postText));
                    query.SendKeys(_helper.GetRandomString());
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                    staleElement = false;
                }
                catch
                {
                    staleElement = true;
                }
            }
            // button "Publish"
            query = driver.FindElement(By.XPath(publishButton));
            query.Click();
            for (int i = 0; i < 360; i++)
            {
                if (i == 179)
                {
                    _helper.SendMessage("Brave | Создание поста с текстом без тэгов: Failed");                   
                    driver.Quit();
                    return false;
                }
                try
                {
                    Thread.Sleep(500);
                    if (driver.FindElement(By.XPath(tagError)).Displayed)
                    {
                        _helper.SendMessage("Brave | Создание поста с текстом без тэгов: Success");                        
                        driver.Quit();
                        return true;
                    }
                }
                catch
                {

                }
            }
            _helper.SendMessage("Brave | Создание поста с текстом без тэгов: Failed");
            ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"passed\", \"reason\": \" error shown!\"}}");
            driver.Quit();
            return false;
        }

        [Obsolete]
        public bool AddLink()
        {
            _capability.AddAdditionalCapability("name", _testName + _helper.GetCurrentMethodName(), true); // test name
            _capability.AddAdditionalCapability("build", _buildName, true);
            _capability.AddAdditionalCapability("name", _testName + _helper.GetCurrentMethodName(), true); // test name
            _capability.AddAdditionalCapability("build", _buildName, true);
            driver = new RemoteWebDriver(new Uri($"https://{name}:{password}@hub-cloud.browserstack.com/wd/hub/"), _capability);
            //driver = new ChromeDriver(service, options);
            Actions action = new Actions(driver);
            driver.Navigate().GoToUrl("https://test.pocketnet.app/authorization");
            IWebElement query;
            for (; ; )
            {
                try
                {
                    // button "Upload QR Code"
                    query = driver.FindElement(By.XPath(uploadQRCode));
                    query.Click();
                    query.SendKeys(keyQR);
                    break;
                }
                catch
                {

                }
            }
            // button "Enter"
            query = driver.FindElement(By.XPath(enterQR));
            query.Click();
            Thread.Sleep(TimeSpan.FromSeconds(5));
            bool staleElement = true;

            while (staleElement)
            {
                try
                {
                    // open createpost window
                    query = driver.FindElement(By.XPath(openCreatepostWindow));
                    query.Click();
                    staleElement = false;
                }
                catch (Exception e)
                {
                    staleElement = true;
                }
            }
            staleElement = true;
            var link = "https://www.google.kz/";
            while (staleElement)
            {

                try
                {
                    query = driver.FindElement(By.XPath(
                        postText));
                    query.SendKeys(link);
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                    staleElement = false;
                    query.Click();
                }
                catch (StaleElementReferenceException e)
                {
                    staleElement = true;
                }
            }
            for (int i = 0; i < 360; i++)
            {
                if (i == 359)
                {
                    _helper.SendMessage("Brave | Создание поста с добавлением ссылки: Failed");
                    driver.Quit();
                    return false;
                }
                Thread.Sleep(500);
                try
                {
                    if (driver.FindElement(By.XPath(addedLink)).Displayed)
                    {
                        _helper.SendMessage("Brave | Создание поста с добавлением ссылки: Success");                       
                        driver.Quit();
                        return true;
                    }
                }
                catch
                {
                }
            }
            _helper.SendMessage("Brave | Создание поста с добавлением ссылки: Failed");
            ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"passed\", \"reason\": \" error shown!\"}}");
            driver.Quit();
            return false;
        }

        [Obsolete]
        public bool SuccefulPostWithImages()
        {
            _capability.AddAdditionalCapability("name", _testName + _helper.GetCurrentMethodName(), true); // test name
            _capability.AddAdditionalCapability("build", _buildName, true);
            _capability.AddAdditionalCapability("name", _testName + _helper.GetCurrentMethodName(), true); // test name
            _capability.AddAdditionalCapability("build", _buildName, true);
            driver = new RemoteWebDriver(new Uri($"https://{name}:{password}@hub-cloud.browserstack.com/wd/hub/"), _capability);
            //driver = new ChromeDriver(service, options);
            driver.Navigate().GoToUrl("https://test.pocketnet.app/authorization");
            IWebElement query;
            for (; ; )
            {
                try
                {
                    // button "Upload QR Code"
                    query = driver.FindElement(By.XPath(uploadQRCode));
                    query.Click();
                    query.SendKeys(keyQR);
                    break;
                }
                catch
                {
                }
            }
            // button "Enter"
            query = driver.FindElement(By.XPath(enterQR));
            query.Click();
            Thread.Sleep(TimeSpan.FromSeconds(5));
            bool staleElement = true;

            while (staleElement)
            {
                try
                {
                    // open createpost window
                    query = driver.FindElement(By.XPath(openCreatepostWindow));
                    query.Click();
                    staleElement = false;
                }
                catch (Exception e)
                {

                    staleElement = true;

                }

            }
            staleElement = true;
            var text = _helper.GetRandomString();
            while (staleElement)
            {

                try
                {
                    query = driver.FindElement(By.XPath(
                        postText));
                    query.SendKeys(text);
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                    staleElement = false;

                }
                catch (StaleElementReferenceException e)
                {
                    staleElement = true;
                }
            }
            staleElement = true;
            for (int i = 0; i < 6; i++)
            {
                while (staleElement)
                {
                    try
                    {
                        query = driver.FindElement(By.XPath(tagInput));
                        query.SendKeys(_helper.GetRandomString());
                        query.SendKeys(Keys.Enter);
                        staleElement = false;
                    }
                    catch (Exception e)
                    {
                        staleElement = true;
                    }
                }
            }
            for (int i = 0; i < 360; i++)
            {
                if (i == 359)
                {
                    _helper.SendMessage("Brave | Создание поста с добавлением картинки: Succes");
                    
                    driver.Quit();
                    return false;
                }
                Thread.Sleep(500);
                try
                {
                    
                        query = driver.FindElement(By.XPath(addPhotoButton));
                        query.SendKeys(picPath);
                        break;
                    
                }
                catch
                {
                }
            }
            Thread.Sleep(5000);
            // button "Publish"
            for (int i = 0; i < 360; i++)
            {
                if (i == 359)
                {
                    _helper.SendMessage("Brave | Создание поста с добавлением картинки: Succes");
                    
                    driver.Quit();
                    return false;
                }
                Thread.Sleep(500);
                try
                {
                        query = driver.FindElement(By.XPath(publishButton));
                        query.Click();
                        break;
                    
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            _helper.SendMessage("Brave | Создание поста с добавлением картинки: Succes");
            ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"passed\", \"reason\": \" error shown!\"}}");
            driver.Quit();
            return false;
        }

        [Obsolete]
        public bool UploadVideo()
        {
            _capability.AddAdditionalCapability("name", _testName + _helper.GetCurrentMethodName(), true); // test name
            _capability.AddAdditionalCapability("build", _buildName, true);
            _capability.AddAdditionalCapability("name", _testName + _helper.GetCurrentMethodName(), true); // test name
            _capability.AddAdditionalCapability("build", _buildName, true);
            driver = new RemoteWebDriver(new Uri($"https://{name}:{password}@hub-cloud.browserstack.com/wd/hub/"), _capability);
            //driver = new ChromeDriver(service, options);
            driver.Navigate().GoToUrl("https://test.pocketnet.app/authorization");
            IWebElement query;
            for (; ; )
            {
                try
                {
                    // button "Upload QR Code"
                    query = driver.FindElement(By.XPath(uploadQRCode));
                    query.Click();
                    query.SendKeys(keyQR);
                    break;
                }
                catch
                {

                }
            }

            // button "Enter"
            query = driver.FindElement(By.XPath(enterQR));
            query.Click();
            Thread.Sleep(TimeSpan.FromSeconds(5));
            bool staleElement = true;

            while (staleElement)
            {
                try
                {
                    // open createpost window
                    query = driver.FindElement(By.XPath(openCreatepostWindow));
                    query.Click();
                    staleElement = false;
                }
                catch (Exception e)
                {

                    staleElement = true;

                }

            }
            staleElement = true;
            var text = _helper.GetRandomString();
            while (staleElement)
            {

                try
                {
                    query = driver.FindElement(By.XPath(
                        postText));
                    query.SendKeys(text);
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                    staleElement = false;

                }
                catch
                {

                    staleElement = true;

                }

            }
            for (int i = 0; i < 360; i++)
            {
                if (i == 359)
                {
                    _helper.SendMessage("Создание поста с загрузкой видео: Failed");
                    
                    driver.Quit();
                    return true;
                }
                Thread.Sleep(500);
                try
                {
                    query = driver.FindElement(By.XPath(tagInput));
                    query.SendKeys(_helper.GetRandomString());
                    query.SendKeys(Keys.Enter);
                    break;
                }
                catch
                {
                }
            }
            for (int i = 0; i < 360; i++)
            {

                if (i == 359)
                {
                    _helper.SendMessage("Создание поста с загрузкой видео: Failed");
                    
                    driver.Quit();
                    return true;
                }
                Thread.Sleep(500);
                try
                {
                    query = driver.FindElement(By.XPath(addVideoButton));
                    query.Click();
                    break;
                }
                catch
                {
                }
            }
            for (int i = 0; i < 360; i++)
            {
                if (i == 359)
                {
                    _helper.SendMessage("Создание поста с загрузкой видео: Failed");
                    
                    driver.Quit();
                    return true;
                }
                Thread.Sleep(500);
                try
                {
                    var queryForElements = driver.FindElements(By.XPath(uploadVideoInput));
                    queryForElements[1].SendKeys(vidPath);
                    break;
                }
                catch
                {
                }
            }


            // button "Publish"
            for (int i = 0; i < 360; i++)
            {
                if (i == 359)
                {
                    _helper.SendMessage("Создание поста с загрузкой видео: Failed");
                    
                    driver.Quit();
                    return false;
                }
                Thread.Sleep(500);
                try
                {
                    query = driver.FindElement(By.XPath(publishButton));
                    query.Click();
                    break;

                }
                catch 
                {
                    
                }
            }
           
            
            //Thread.Sleep(100000);
            //query = driver.FindElement(By.XPath(publishButton));
            //query.Click();

            for (int i = 0; i < 360; i++)
            {
                if (i == 359)
                {
                    _helper.SendMessage("Создание поста с загрузкой видео: Failed");
                    
                    driver.Quit();
                    return true;
                }
                Thread.Sleep(1000);
                try
                {
                    if (driver.FindElement(By.XPath(removeVideoBtn)).Displayed)
                    {
                        _helper.SendMessage("Создание поста с загрузкой видео: Success");
                        Console.WriteLine("Brave | Создание поста с загрузкой видео: Success");
                        driver.Quit();
                        return true;
                    }
                }
                catch
                {
                }
            }
            _helper.SendMessage("Создание поста с загрузкой видео: Failed");
            ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"passed\", \"reason\": \" error shown!\"}}");
            driver.Quit();
            return true;
        }
    }
}