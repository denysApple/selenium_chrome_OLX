using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                                    Steps
            ======
                1. Go to https://www.ebay.com
                2. Enter "Astronomical Telescope" into the search field
                3. Click "Search" button
                4. Get prices first 10 found items
                5. Verify that sum of prices from the last steps is more then 1000$
            */
            string Price;
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.ebay.com/");
            driver.FindElement(By.Id("gh-ac")).SendKeys("Astronomical Telescope");
            driver.FindElement(By.Id("gh-btn")).Click();
            Console.ReadKey();
            Console.WriteLine(Finding10Prices(driver));
        }
        public static double Finding10Prices(IWebDriver driver)
        {
            double Suma = 0;
            String temp = "0";
            /*for (int i = 0; i <= 10; i++)
            {
                try
                {
                    temp = driver.FindElement(By.CssSelector("span.bold")).Text;
                    Console.WriteLine(temp);
                }
                catch
                {
                    Console.WriteLine("Элемент class: span.bold - не найдено");
                    try
                    {
                        temp = driver.FindElement(By.CssSelector("span.s-item__price")).Text;
                        Console.WriteLine(temp);
                    }
                    catch
                    {
                        Console.WriteLine("Элемент class: span.s-item__price - не найдено еще раз!");
                    }
                    finally
                    {
                        temp.Replace('$', ' ');
                        temp.Replace('.', ',');
                        Console.WriteLine(temp);
                        Suma += Convert.ToDouble(temp.Replace("$", " "));
                        Console.WriteLine("Удалили первый элемент");
                        Console.WriteLine(temp);
                        //Suma += Convert.ToDouble(temp.Replace('.', ',');
                    }
                }
                finally
                {
                    Suma += Convert.ToDouble(temp.Replace("$", " "));
                }
                else if 
                {
                    temp = driver.FindElement(By.ClassName("lvprice prc")).Text;
                    Suma += double.Parse(temp);
                    return Suma;
                }
                //lvprice prc
                //s-item__price
                //css=span.s-item__price
                Console.WriteLine(Suma);
            }*/


            temp = driver.FindElement(By.XPath(".//*[@id='ListViewInner']//li/ul/li/span")).Text;
            Console.WriteLine(temp);
            Suma = (double)temp;
            Console.WriteLine("FINALLY COUNT:");
            Console.WriteLine(Suma);
            return Suma;
        }
    }
}
