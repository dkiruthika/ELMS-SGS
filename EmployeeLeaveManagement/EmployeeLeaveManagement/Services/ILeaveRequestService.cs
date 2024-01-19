using EmployeeLeaveManagement.Models;

namespace EmployeeLeaveManagement.Services
{
  public interface ILeaveRequestService
  {
    public LeaveRequest insertLeaveRequest(LeaveRequest request);
  }
}
