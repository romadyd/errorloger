using System;
using System.Text;
using System.Collections.Generic;
using LogNotifier;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestLogNotifier
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class NLoger
    {
        [TestMethod]
        public void checkLoger()
        {
            string _err = null;
            string _ex = string.Format("Log\\Log_{0}.txt", DateTime.Now.ToString("yyyyMMdd"));

            try
            {
                int x = Convert.ToInt32("asdf");
            }
            catch (Exception ex)
            {
                Loger loger = new Loger("App","yudi2610@gmail.com");
                _err = loger.Write(ex);
            }

            Assert.AreEqual(_ex, _err);
        }
    }
}
