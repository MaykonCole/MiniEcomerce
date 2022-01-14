using Ecommerce.Applicattion.CQRS.Queries.Users.GetAllUsers;
using Ecommerce.Applicattion.CQRS.Queries.Users.TakenLogin;
using Ecommerce.Core.IRepositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Ecommerce.Tests.Users.TakeLoginHandler
{
    public class UserTests : UserMock
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;

        public UserTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
        }

        #region TAKELOGINHANDLER
        [Fact]
       public async Task EMAIL_INCORRECT_AND_PASSWORD_CORRECT_EXECUTED_RETURN_USER_NULL()
        {
            // ARRANGE
            // 1° Dependências
            //var userRepositoryMock = new Mock<IUserRepository>();
            // 2° Criacao de uma instancia da Query ou Command
            var takeLoginQuery = new TakeLoginQuery { Email = User.Email, Password = User.Password };
            // 3° Injeção da dependência no seu Handler
            var takeLoginHandler = new Ecommerce.Applicattion.CQRS.Queries.Users.TakenLogin.TakeLoginHandler(_userRepositoryMock.Object);

            //ACTION
            _userRepositoryMock.Setup(u => u.TakeLoginAsync(Faker.Internet.Email(), It.IsAny<string>())).ReturnsAsync(User);
            var resultUser = await takeLoginHandler.Handle(takeLoginQuery, new CancellationToken());
            
            //ASSERT
            Assert.Null(resultUser);
            Assert.False(resultUser != null);
        }

        [Fact]
        public async Task EMAIL_CORRECT_AND_PASSWORD_INCORRECT_EXECUTED_RETURN_USER_NULL()
        {
            // ARRANGE
           // var userRepositoryMock = new Mock<IUserRepository>();
            var takeLoginQuery = new TakeLoginQuery { Email = User.Email, Password = User.Password };
            var takeLoginHandler = new Ecommerce.Applicattion.CQRS.Queries.Users.TakenLogin.TakeLoginHandler(_userRepositoryMock.Object);

            //ACTION
            _userRepositoryMock.Setup(u => u.TakeLoginAsync(It.IsAny<string>(), "PASSWORDINCORRECT" )).ReturnsAsync(User);
            var resultUser = await takeLoginHandler.Handle(takeLoginQuery, new CancellationToken());

            //ASSERT
            Assert.Null(resultUser);
            Assert.False(resultUser != null);
        }

        [Fact]
        public async Task EMAIL_AND_PASSWORD_CORRECTS_EXECUTED_RETURN_USER()
        {
           // var userRepositoryMock = new Mock<IUserRepository>();
            var takeLoginQuery = new TakeLoginQuery { Email = User.Email, Password = User.Password };
            var takeLoginHandler = new Ecommerce.Applicattion.CQRS.Queries.Users.TakenLogin.TakeLoginHandler(_userRepositoryMock.Object);

            _userRepositoryMock.Setup(u => u.TakeLoginAsync(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(User);
            var resultUser = await takeLoginHandler.Handle(takeLoginQuery, new CancellationToken());

            Assert.True(resultUser != null);
        }
        #endregion

        #region GETALLUSERS
        [Fact]
        public async Task GET_ALL_USERS_EXECUTED_RETURN_LIST_USERS()
        {
            //var userRepositoryMock = new Mock<IUserRepository>();
            var getAllUsersQuery = new GetAllUsersQuery();
            var getAllUsersQueryHandler = new Ecommerce.Applicattion.CQRS.Queries.Users.GetAllUsers.GetAllUsersQueryHandler(_userRepositoryMock.Object);

            _userRepositoryMock.Setup(u => u.GetAllUsersAsync()).ReturnsAsync(ListUsers);

            var users = await getAllUsersQueryHandler.Handle(getAllUsersQuery, new CancellationToken());

            Assert.False(users == null);
            Assert.True(users.Count == 3);
        }

        #endregion
    }
}
