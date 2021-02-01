using Api.Domain;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTests
{
    public class ValidatorTest
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