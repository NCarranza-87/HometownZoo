using System;
using HomeTownZoo.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MultiProjectTest.Tests.CoreProject
{
    [TestClass]
    public class ValidatorTest
    {
        [TestMethod]
        [DataRow("98399")]
        [DataRow("98499-")]
        [DataRow("98499-1234")]
        public void IsValidZipCode_USFormate_ReturnsTrue(string input)
        {
            // Arrange
            //String input = "98499";
            
            // Act
            bool result = Validator.IsValidUSZipCode(input);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
