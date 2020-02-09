using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Anastasis.SntpTime.Test
{
    [TestClass]
    public class SntpClientTest
    {
        [TestMethod]
        [TestCategory("Integration")]
        public void IntegrationTest()
        {
            // Arrange

            // Act
            var currentUtcTime = SntpClient.GetTime("time.windows.com");
            var currentTimeZoneTime = TimeZoneInfo.ConvertTime(currentUtcTime, TimeZoneInfo.Local);

            // Assert
            Assert.IsNotNull(currentUtcTime);
            Assert.IsNotNull(currentTimeZoneTime);
        }

        private string test =
            "\"\\u001c\\u0003\\0?\\0\\0\\u0005?\\0\\0\\aa\\u0019B?\\u0002????\\u0001?`?\\0\\0\\0\\0\\0\\0\\0\\0?????\\u0010:\\t?????\\u0010e?\"";

        [TestMethod]
        public void Test()
        {
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(test);

        }
    }
}
