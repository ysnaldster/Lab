using LambdaPipelines.Entities;

namespace LambdaPipelines.Mocks;

public class UserMock
{
    public IEnumerable<User> MapUsers()
    {
        return new List<User>
        {
            new() { UserName = "User1", Email = "User1@mail.com", Password = "oll912", Phone = 39121229 },
            new() { UserName = "User2", Email = "User2@mail.com", Password = "oll912", Phone = 39121229 }
        };
    }
}