using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace Demo2TestProject
{
    [TestFixture]
    public abstract class TestRunner
    {

        private readonly int IMPLICIT_WAIT = 10;
        private string urlUnderTest = "http://atqc-shop.epizy.com";
        public virtual string UrlUnderTest
        {
            get { return urlUnderTest; }
        }
        protected IWebDriver driver;
        

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(IMPLICIT_WAIT);
            //
            Console.WriteLine("[OneTimeSetUp] BeforeAllMethods()");
            //MessageBox.Show("[OneTimeSetUp] BeforeAllMethods()", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            driver.Quit();
            Console.WriteLine("[OneTimeTearDown] AfterAllMethods()");
            //MessageBox.Show("[OneTimeTearDown] AfterAllMethods()", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        [SetUp]
        public void SetUp()
        {
            driver.Navigate().GoToUrl(UrlUnderTest);
            
            Console.WriteLine("[SetUp] SetUp()");
        }

        public void Login()
        {
            driver.FindElement(By.ClassName("dropdown")).Click();
            driver.FindElement(By.XPath("//a[text()='Login']")).Click();
            driver.FindElement(By.Name("email")).SendKeys("kimachuk88@yahoo.com");
            driver.FindElement(By.Name("password")).SendKeys("qwerty");
            driver.FindElement(By.CssSelector("input.btn.btn-primary")).Click();
        }
        
        public void SearchItem(string itemName)
        {
            driver.FindElement(By.Name("search")).Click();
            driver.FindElement(By.Name("search")).Clear();
            driver.FindElement(By.Name("search")).SendKeys(itemName);
            driver.FindElement(By.CssSelector(".btn.btn-default.btn-lg")).Click();


        }
        public void AddToCart()
        {
            //Add to cart
            driver.FindElement(By.Id("button-cart")).Click();
            Thread.Sleep(2000);
            //Click "Cart" button
            driver.FindElement(By.CssSelector("#cart-total")).Click();
            Thread.Sleep(2000);
            //Click "View Cart"
            driver.FindElement(By.PartialLinkText("View")).Click();
        }
    }
}
