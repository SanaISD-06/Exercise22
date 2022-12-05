using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using Microsoft.VisualBasic.FileIO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;


class AutomationDriver
{
    static IWebDriver driver = new ChromeDriver();
    static IWebElement radioButton;
    private static object WebElement;

    // static IWebElement checkBox;
    static void Main(string[] args)
    {
        string url = "https://rahulshettyacademy.com/AutomationPractice/";
        driver.Navigate().GoToUrl(url);
        // excerciseOne();
        // excerciseTwo();
        //  excerciseThree();
        // excerciseFour();
        //  excercise4p1();
        //   excercise4p2();
        //  excerciseFive();
        //  excerciseSix();
        //  excerciseSeven();
        //  excerciseEight();
        excerciseNine();
        driver.Quit();
    }

    private static void excercise2()
    {
        throw new NotImplementedException();    
    }
    public static void excerciseOne()
    {
        string[] option = {"1", "2", "3" };
        int i = 0;
        while (i < 3)
        {
            radioButton = driver.FindElement(By.XPath("//*[@id=\"radio-btn-example\"]/fieldset/label[" + option[i] + "]/input"));
            radioButton.Click();
            if (radioButton.GetAttribute("checked") == "true")
            {
                Console.WriteLine("the radio button" + (i + 1) + " is checked!");
            }
            else
            {
                Console.WriteLine("The radio button is unchecked!");
            }
            i++;
            Thread.Sleep(4000);
        }
    }

    public static void excerciseTwo()
    {
        IWebElement sugg = driver.FindElement(By.Id("autocomplete"));
        sugg.SendKeys("united");
        IList<IWebElement> suggeBox = driver.FindElements(By.XPath("//*[@id=\"autocomplete\"]"));
        foreach(var sugge in suggeBox)
        {
            if(sugge.Text.Contains("United States(usa)"))
            {
                sugge.Click();
            }
        }
        Thread.Sleep(2000);
    }

    public static void excerciseThree()
    {
        IWebElement dropd = driver.FindElement(By.Id("dropdown-class-example"));
        dropd.Click();
        SelectElement dropDown = new SelectElement(dropd);
        for(int i=1; i<=3; i++)
        {
            dropDown.SelectByText("Option" + i + "");
            Thread.Sleep(3000);
        }
    }
 
    public static void excerciseFour()
    {
        string option1 = "1";
        IWebElement checkBox1 = driver.FindElement(By.XPath("//*[@id=\"checkBoxOption" + option1 + "\"]"));
        checkBox1.Click();
        Thread.Sleep(3000);
        Console.WriteLine(checkBox1.GetAttribute("value") + " is checkedoff ");
        checkBox1.Click();
        Thread.Sleep(2000);
        Console.WriteLine(checkBox1.GetAttribute("value") + " is unchecked ");

      //  string option2 = "2";
        IWebElement checkBox2 = driver.FindElement(By.XPath("//*[@id=\"checkBoxOption2\"]"));
        checkBox2.Click();
        Thread.Sleep(3000);
        Console.WriteLine(checkBox2.GetAttribute("value") + " is checkedoff ");
        checkBox2.Click();
        Thread.Sleep(2000);
        Console.WriteLine(checkBox2.GetAttribute("value") + " is unchecked ");

      //  string option3 = "3";
        IWebElement checkBox3 = driver.FindElement(By.XPath("//*[@id=\"checkBoxOption3\"]"));
        checkBox3.Click();
        Thread.Sleep(3000);
        Console.WriteLine(checkBox3.GetAttribute("value") + " is checkedoff ");
        checkBox3.Click();
        Thread.Sleep(2000);
        Console.WriteLine(checkBox3.GetAttribute("value") + " is unchecked ");
    }

    static public void excercise4p1()
    {

        IWebElement checkBox1 = driver.FindElement(By.XPath("//*[@id=\"checkBoxOption1\"]"));
        checkBox1.Click();
        Thread.Sleep(3000);
        IWebElement checkBox2 = driver.FindElement(By.XPath("//*[@id=\"checkBoxOption2\"]"));
        checkBox2.Click();
        Thread.Sleep(3000);
        IWebElement checkBox3 = driver.FindElement(By.XPath("//*[@id=\"checkBoxOption3\"]"));
        checkBox3.Click();
        Thread.Sleep(3000);
        Console.WriteLine("all checkboxes are selected");
        
        /*  string[] option = { "1", "2", "3" };
          for (int i = 0; i <= option.Length; i++)
          {
              IWebElement checkBox = driver.FindElement(By.XPath("//*[@id=\"checkBoxOption" + option[i] + "\"]"));
              checkBox.Click();
              Thread.Sleep(2000);
          }
         // excercise4p2();
         // Thread.Sleep(1000);
        //  Console.WriteLine("All checkboxes are selected");
        //  driver.Quit();

          */
    }

    static public void excercise4p2()
    {
        for(int j=1; j<=3; j++)
        {
            IWebElement Deselect = driver.FindElement(By.XPath("//*[@id=\"checkBoxOption" + j + "\"]"));
            Deselect.Click();
        }
        Thread.Sleep(3000);
        Console.WriteLine("all checkboxes are deselected");
        driver.Quit();
    }

    static public void excerciseFive()
    {
        IWebElement openWindow = driver.FindElement(By.Id("openwindow"));
        openWindow.Click();
        Thread.Sleep(3000);
        driver.SwitchTo().Window(driver.WindowHandles[1]);
        driver.Close();
        driver.SwitchTo().Window(driver.WindowHandles[0]);
        /*  WebElement text = (WebElement)driver.FindElement(By.Id("home"));
          if (text.GetAttribute("homepage") == "true")
          {
              Console.WriteLine(" It is same window");
          }
          Thread.Sleep(2000);
        */

        driver.Close();
    }


    static public void excerciseSix()
    {
        IWebElement openTab = driver.FindElement(By.Id("opentab"));
        openTab.Click();
        Thread.Sleep(5000);
        driver.SwitchTo().Window(driver.WindowHandles[1]);
        driver.Close();
        driver.SwitchTo().Window(driver.WindowHandles[0]);
    }

    static public void excerciseSeven()
    {
        IWebElement EnterName = driver.FindElement(By.Id("name"));
        EnterName.SendKeys("sana");
        Thread.Sleep(5000);
        driver.FindElement(By.XPath("//*[@id=\"alertbtn\"]")).Click();
        Thread.Sleep(2000);

        IAlert simpleAlert = driver.SwitchTo().Alert();

        string alertText = simpleAlert.Text;    
        Console.WriteLine("Alert text is " + alertText);
        simpleAlert.Accept();
    }

    public static void excerciseEight()
    {
        IJavaScriptExecutor js = driver as IJavaScriptExecutor;
        System.Threading.Thread.Sleep(5000);
        js.ExecuteScript("window.scrollBy(0,600);");
        Thread.Sleep(1500);
        js.ExecuteScript("document.querySelector('.tableFixHead').scrollBy(0,6000)");
        Thread.Sleep(1000);
      //  Console.Read();

      //  WebElement = SeleniumManager (driver.FindElements(By.XPath("//*[@id=\"product\"]/tbody/tr[1]")));
    }


    public static void excerciseNine()
    {
        Actions a = new Actions(driver);
        IWebElement mousehower = driver.FindElement(By.XPath("//*[@id=\"mousehover\"]"));
        a.MoveToElement(mousehower).Click().Build().Perform();
        Thread.Sleep(3000);

        IWebElement mouseclick = driver.FindElement(By.XPath("/html/body/div[4]/div/fieldset/div/div/a[1]"));
        a.MoveToElement(mouseclick).Click().Build().Perform();
        Thread.Sleep(5000);
    }
}













//# radio-btn-example > fieldset > label:nth-child(4)   string[] option = {"2", "3", "4"};

/*driver.Navigate().GoToUrl(url);
for (int i = 2; i < option.Length; i++)
{

    radio1 = driver.FindElement(By.XPath("//*[@id=\"radio - btn - example\"]/fieldset/label[" + option[i] + "]/input"));
    radio1.Click();


    if (radio1.GetAttribute("value") == "true")
    {
        Console.WriteLine("The " + (i + 2) + " radioButton  is checked!");
    }
    else
    {
        Console.WriteLine("The radioButton is not checked");
    }

}

//# radio-btn-example > fieldset > label:nth-child(3)
//# radio-btn-example > fieldset > label:nth-child(2)


*/
