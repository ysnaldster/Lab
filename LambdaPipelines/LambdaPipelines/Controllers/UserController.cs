using LambdaPipelines.Entities;
using LambdaPipelines.Mocks;
using Microsoft.AspNetCore.Mvc;

namespace LambdaPipelines.Controllers;

[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly UserMock _userMock;

    public UserController(UserMock userMock)
    {
        _userMock = userMock;
    }

    [HttpGet]
    public IEnumerable<User> Get()
    {
        return _userMock.MapUsers();
    }
}