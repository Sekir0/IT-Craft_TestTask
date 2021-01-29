using Api.Domain;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.UnitTest
{
    public class UserValidatorTests
    {
        [Test]
        public async Task Name_Null_Argument()
        {
            //Arrange
            var validator = new UsersValidator();

            //Act
            var result = validator.Validate(new UsersContext(""));

            //Assert
            Assert.IsFalse(result.Successed && result.Errors.Count() == 1);
        }
    }
}
