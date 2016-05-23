using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SeleniumPracticeTests.Libraries
{
    [TestClass]
    public class DriverTests
    {
        private IWebDriver _driver;

        [TestMethod]
        public void SearchGoogleTest()
        {
            _driver = DriverFactory.CreateDriver();
            //Navigate to google
            _driver.Navigate().GoToUrl("http://www.google.com");

            //do a search
            ////type search text
            IWebElement searchTextbox = _driver.FindElement(By.XPath("//div[@id='gs_lc0']/input[@type='text']"));

            int counter = 0;
            while (counter < 1000 && !searchTextbox.Displayed)
            {
                //Do Nothing
            }

            searchTextbox.SendKeys("cat");

            ////click search
            IWebElement searchButton = _driver.FindElement(By.XPath("//div[@class='lsbb kpbb']//button[@type='submit' and @value='Search']"));

            searchButton.Click();

            //wait for search results to populate

            //click first search result
            IWebElement firstLink = null;
                
            int waitTime = 3;
            DateTime start = DateTime.Now;
            while (firstLink == null && DateTime.Now.Subtract(start).TotalSeconds < waitTime)
            {
                try
                {
                    firstLink = _driver.FindElement(By.XPath("//div[@id='rso']//a"));
                }
                catch
                {
                    Console.WriteLine("Couldnt find it.");
                    //Do Nothing, Look for element again in loop
                }
            }

            if (firstLink == null)
                throw new Exception("No hyperlink could be found");

            firstLink.Click();

            //Print title of first search

            System.Console.WriteLine(_driver.Title);

            DriverFactory.CloseDriver(_driver);
        }
    }
}
