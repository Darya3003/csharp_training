using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;


namespace WebAddressbookTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMEthod1()
        {
            string[] s = new string[] { "I", "want", "to", "sleep" };

            //for (int i = 0; i < s.Length; i++) 
            foreach (string element in s)
            {
                System.Console.WriteLine(element + "\n");
            }

        }

        [TestMethod]
        public void TestMethod2()
        {
            IWebDriver driver = null;
            int attempt = 0;

            //while (driver.FindElements(By.Id("test")).Count == 0 && attempt<=60)
            do
            {
                System.Threading.Thread.Sleep(1000);
                attempt++;
            }
            while (driver.FindElements(By.Id("test")).Count == 0 && attempt <= 60);

            //.....
        }
    }
}
