using EmployeeLeaveManagement.Database;
using EmployeeLeaveManagement.Models;

namespace EmployeeLeaveManagement.Services
{
  public class LeaveRequestService : ILeaveRequestService
  {
    private readonly IAppDbContext _context;
    private readonly ILeaveBalanceService leaveBalance;
    public LeaveRequestService(IAppDbContext context,ILeaveBalanceService leaveBalance)
    {
        _context= context;
        this.leaveBalance= leaveBalance;
    }
    public LeaveRequest insertLeaveRequest(LeaveRequest request)
    {
      int noOfLeaveAvailable = leaveBalance.getLeaveBalance(request.EmployeeId, request.LeaveTypeId);
      int noOfLeaveRequested = (int)(request.EndDate - request.StartDate).TotalDays;
      if(noOfLeaveAvailable >= noOfLeaveRequested) {
        _context.LeaveRequests.Add(request);
        _context.SaveChangesAsync();
        return request;
      }
      return null;
    }
  }
}
