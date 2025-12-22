using Xunit;
using AuditLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace AuditLog.Tests
{
    public class LoggerTests
    {
        [Fact()]
        public void WrtiteLogTest()
        {
            //Arange
            var path = Path.Combine(Environment.CurrentDirectory, "Test.log");
            var logger = new Logger(path);
            logger.SetCurrentClass(typeof(LoggerTests));

            logger.WriteLog("test");


            var result1 = File.Exists(path);
            var result2 = File.ReadAllText(path).IndexOf("test") >= 0;


            var expect = true;

            Assert.Equal(expect, result1 && result2);

            if (result1)
            {
                File.Delete(path);
            }

            //Xunit.Assert.Fail("This test needs an implementation");
        }
    }
}