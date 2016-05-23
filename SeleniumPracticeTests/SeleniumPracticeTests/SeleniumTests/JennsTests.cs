using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumPracticeTests;
using System;

namespace SeleniumTests
{
    public class JennsTests
    {
        [TestClass]
        public class DriverTests
        {
            private IWebDriver _driver;

            [TestMethod]
            public void RedditTest()
            {
                _driver = DriverFactory.CreateDriver();

                _driver.Navigate().GoToUrl("http://www.reddit.com");

                WaitHelper.Wait();
                IWebElement redditLogin = _driver.FindElement(By.XPath("//div[@id='header-bottom-right']//a"));
                redditLogin.Click();

                WaitHelper.Wait();
                IWebElement username = _driver.FindElement(By.XPath("//div[@class='c-form-group ']//input[@id='user_login']"));
                username.SendKeys("testmyselenium");

                IWebElement password = _driver.FindElement(By.XPath("//div[@class='c-form-group ']//input[@id='passwd_login']"));
                password.SendKeys("hunter2");

                //no unique id or difference from sign up/log in buttons

                IWebElement login = _driver.FindElement(By.XPath("//div[@class='c-clearfix c-submit-group']//button[@type='submit' and @tabindex='3']"));
                login.Click();

                WaitHelper.Wait();
                IWebElement pickSubreddit = _driver.FindElement(By.XPath("//div[@class='sr-list']//a[@href='https://www.reddit.com/r/videos/']"));
                pickSubreddit.Click();

                WaitHelper.Wait();
                IWebElement firstLink = _driver.FindElement(By.XPath("//div[@id='siteTable']//a"));
                firstLink.Click();

                WaitHelper.Wait(15);
                _driver.Navigate().Back();

                WaitHelper.Wait();
                IWebElement upvoteTopPost = _driver.FindElement(By.XPath("//div[@id='siteTable']//div[@role='button']"));
                upvoteTopPost.Click();

                WaitHelper.Wait();
                IWebElement pickNewVideos = _driver.FindElement(By.XPath("//div[@id='header-bottom-left']//a[@href='https://www.reddit.com/r/videos/new/']"));
                pickNewVideos.Click();

                WaitHelper.Wait();
                IWebElement firstNewLink = _driver.FindElement(By.XPath("//div[@id='siteTable']//a"));
                firstNewLink.Click();

                WaitHelper.Wait(15);
                _driver.Navigate().Back();

                WaitHelper.Wait();

            }

            
        }
    }
}
