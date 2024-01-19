using EmployeeLeaveManagement.Models;

namespace EmployeeLeaveManagement.Services
{
  public interface ILoginService
  {
    Employee LoginDb(string username, string password);
  }
}
