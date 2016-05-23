using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumPracticeTests
{
    public static class DriverFactory
    {
        private static ChromeDriverService _service;
        private static int _counter;

        static DriverFactory()
        {
            _service = ChromeDriverService.CreateDefaultService(@"C:\Users\Chase\Desktop\Selenium Practice\SeleniumPracticeTests\SeleniumPracticeTests\Libraries");
            _service.Start();
            _counter = 0;
        }

        public static IWebDriver CreateDriver()
        {
            _counter++;
            return new ChromeDriver(_service);
        }

        public static void CloseDriver(IWebDriver driver)
        {
            driver.Close();
            _counter--;
            if (_counter == 0)
                _service.Dispose();
        }
    }
}
