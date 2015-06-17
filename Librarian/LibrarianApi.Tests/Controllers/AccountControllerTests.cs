using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Librarian.API;
using Librarian.API.Models;
using Librarian.API.Controllers;
using Moq;
using Xunit;

namespace Librarian.API.Controllers.Tests
{
  public class AccountControllerTests
  {
    [Fact()]
    public void AccountControllerTest()
    {
      //Assert.True(false, "not implemented yet");
    }

    [Fact]
    public void RegisterUser()
    {
      // Arrange
      var wasCalled = false;
      var repoMock = new Mock<IAuthenticationRepository>();
      repoMock.Setup(p => p.RegisterUser(It.IsAny<UserModel>())).Callback(() => wasCalled = true);

      var controller = new AccountController(repoMock.Object);
      var user = new UserModel
      {
        UserName = "test1",
        Password = "pass001",
        ConfirmPassword = "pass001"
      };

      // Act
      var result = controller.Register(user);

      // Assert
      Assert.True(wasCalled);
    }
  }
}
