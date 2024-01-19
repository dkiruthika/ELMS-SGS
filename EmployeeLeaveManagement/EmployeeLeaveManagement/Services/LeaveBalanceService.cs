using EmployeeLeaveManagement.Database;

namespace EmployeeLeaveManagement.Services
{
  public class LeaveBalanceService : ILeaveBalanceService
  {
    private readonly IAppDbContext _appDbContext;
    public LeaveBalanceService(IAppDbContext _appDbContext)
    {
        this._appDbContext = _appDbContext;
    }
    public int getLeaveBalance(int empId, int leaveTypeId)
    {
      var lb = _appDbContext.LeaveBalances.Where(x => x.EmployeeId == empId && x.LeaveTypeId == leaveTypeId);
       var leave=lb.Select(x=>x.Balance);
        return leave.Single();
     }
  }
}
