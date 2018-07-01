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
    //Verifying title of selected item before and after add to cart
    [TestFixture]
    public class TitleWLogin:TestRunner
    {
        [Test]
        public void CompareNamesWLogin()
        {
            //Start browser and navigate to URL
            //Login
            Login();

            //Search and choose item
            SearchItem("Iphone SE 64GB");
            
            //Read title
            String expected = driver.FindElement(By.XPath("//h4/a[text()='Apple iPhone SE 64GB']")).Text;
            driver.FindElement(By.XPath("//h4/a[text()='Apple iPhone SE 64GB']")).Click();

            //Add to cart
            AddToCart();
            
            //Read title
            String actual = driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div/table/tbody/tr/td[2]/a")).Text;

            //Compare titles
            Assert.AreEqual(expected, actual);

            //Finish webdriver process
            driver.Quit();

          
            

        }
    }
}
