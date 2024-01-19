using EmployeeLeaveManagement.Database;
using EmployeeLeaveManagement.Models;
using System.Text;

namespace EmployeeLeaveManagement.Services
{
  public class LoginService:ILoginService
  {
    private readonly IPasswordHasher _passwordHasher;
    private readonly IAppDbContext _appDbContext;
    public LoginService(IAppDbContext appDbContext, IPasswordHasher passwordHasher)
    {
      _appDbContext = appDbContext;
      _passwordHasher = passwordHasher;
    }



    public Employee LoginDb(string emailid, string password)
    {

      string result = ValidateUser(emailid, password);
      if (result == "Valid user")
      {
        byte[] data = Convert.FromBase64String(password);
        string decodedPassword = Encoding.UTF8.GetString(data);
        var user = _appDbContext.Employees.FirstOrDefault(x => emailid.Equals(x.Email));
        if (user != null)
        {
          if (_passwordHasher.VerifyPassword(user.PasswordHashed, decodedPassword))
          {
            return user;
          }
          
        }
      }
      return null;
    }
    private string ValidateUser(string email, string pswd)
    {
      if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(pswd))
      {
        return "User field is null";
      }

      try
      {
        var addr = new System.Net.Mail.MailAddress(email);
        if (addr.Address == email)
        {
          return "Valid user";
        }
        else
        {
          return "Invalid user";
        }
      }
      catch (Exception e)
      {
        return "Invalid email format";
      }


    }

  }
}
