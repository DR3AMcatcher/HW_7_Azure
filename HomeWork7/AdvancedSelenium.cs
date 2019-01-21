using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace HomeWork7
{
    [TestFixture]
    public class AdvancedSelenium : SetUpFixture
    {
        
        //Go to http://www.leafground.com/home.html
        //Open “HyperLink” page in new tab
        //Hover on “Go to Home Page” link
        //Take a screenshot and save it somewhere
        [Test]
        public void Hover_And_Screenshot()
        {
            By HyperLink_btn = By.LinkText("HyperLink");
            By GoToHomePage_link = By.XPath("(//a[contains(text(),'Page')])[1]");
            //var actions = new Actions(driver);
            driver.Navigate().GoToUrl("http://www.leafground.com/home.html");

            //Open link in new tab and switch
            new Actions(driver).KeyDown(Keys.Control).Click(driver.FindElement(HyperLink_btn)).Perform();
            driver.SwitchTo().Window(driver.WindowHandles[1]);

            //Hover
            new Actions(driver).MoveToElement(driver.FindElement(GoToHomePage_link)).Perform();


            //Close the tab=
            //Switch to first tab
            driver.Close();
            driver.Quit();
            driver.Dispose();
        }

        //Go to https://jqueryui.com/demos/
        //Navigate to “Droppable” demo(Interactions section)
        //Switch to frame
        //Drag & Drop the small box into a big one
        //Verify that big box now contains text “Dropped!”
        [Test]
        public void Frames_And_Drags()
        {
            By Droppable_link = By.LinkText("Droppable");
            By Testing_Frame = By.CssSelector(".demo-frame");

            By Draggable_el = By.Id("draggable");
            By Droppable_el = By.Id("droppable");
            var actions = new Actions(driver);

            driver.Navigate().GoToUrl("https://jqueryui.com/demos/");
            driver.FindElement(Droppable_link).Click();

            //Switch to frame and drag
            driver.SwitchTo().Frame(driver.FindElement(Testing_Frame));
            actions.DragAndDrop(driver.FindElement(Draggable_el), driver.FindElement(Droppable_el)).Perform();

            //verify text
            Assert.That(driver.FindElement(By.CssSelector("#droppable p")).Text.Contains("Dropped!"));
            driver.Close();
            driver.Quit();
            driver.Dispose();

        }

    }
}