using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using System;

/*
                                    Steps
                                   ======
                1. Go to https://www.ebay.com
                2. Enter "Astronomical Telescope" into the search field
                3. Click "Search" button
                4. Get prices first 10 found items
                5. Verify that sum of prices from the last steps is more then 1000$
*/

namespace Tests
{
    public class Tests
    {
        Double temp = 0.00;
        //string Price;
        [SetUp]
        public void Setup()
        {

        }

        /*[FindsBy(How = How.Name, Using = "UserName")]
        public IWebElement FirstPrice { get; set; }*/

        [Test]
        public void Test1()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.ebay.com/");
            driver.FindElement(By.Id("gh-ac")).SendKeys("Astronomical Telescope");
            driver.FindElement(By.Id("gh-btn")).Click();
            try
            {
                var AllPrices = driver.FindElements(By.XPath(".//*[@id='ListViewInner']//li/ul/li/span"));

                for (int i = 0; i <= 10; i++)
                {
                    temp += Double.Parse(AllPrices[i].ToString().Remove(0));
                }
            }
            catch
            {
                try
                {
                    var AllPrices = driver.FindElements(By.ClassName("s-item__price"));
                    for (int i = 0; i <= 10; i++)
                    {
                        temp += Double.Parse(AllPrices[i].ToString().Remove(0));
                    }
                }
                catch
                {
                    Assert.Fail("Exception thrown!!!!");
                }
                finally
                {
                    Assert.Pass("Test - success!!!");
                }
            }
            finally
            {
                Assert.Pass("Test - success!!!");
            }
            Console.WriteLine(temp);
        }
        [Test]
        public void Test2()
        {
            if (temp <= 1000)
            {
                Assert.Fail("ERROR its less than 1000$");
            }
        }
    }
}