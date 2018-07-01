using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Windows.Forms;


namespace Demo2TestProject
{
    [TestFixture]
    public class PriceWOutLogin:TestRunner
    {
        [Test]
        //Checking names 
        public void ComparePriceWOutLogint()
        {
           
            //Search and choose item
            SearchItem("Iphone SE 64GB");

            //Read price
            driver.FindElement(By.XPath("//h4/a[text()='Apple iPhone SE 64GB']")).Click();
            String expected = driver.FindElement(By.CssSelector(".list-unstyled li h2")).Text;
            

            //Add to cart
            AddToCart();

            //Read title
            String actual = driver.FindElement(By.XPath("//*[@id='content']/form/div/table/tbody/tr/td[5]")).Text;

            //Compare titles
            Assert.AreEqual(expected, actual);

            //Finish webdriver process
            driver.Quit();
        }

    }

}