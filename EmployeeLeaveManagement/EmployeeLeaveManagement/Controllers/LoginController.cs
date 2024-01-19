using EmployeeLeaveManagement.Models;
using EmployeeLeaveManagement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeLeaveManagement.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class LoginController : ControllerBase
  {
    private readonly ILoginService _loginService;
    public LoginController(ILoginService loginService)
    {
      this._loginService = loginService;
    }

    [HttpPost]
    public ActionResult Login(UserLogin user)
    {

      Employee employee = _loginService.LoginDb(user.emailid, user.password);

      if (employee!=null)
      {
        return Ok(employee);
      }
      return BadRequest(false);


    }

  }
}
