using EmployeeLeaveManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeLeaveManagement.Database
{
  public interface IAppDbContext
  {
    DbSet<Employee> Employees { get; set; }
    DbSet<LeaveBalance> LeaveBalances { get; set; }
    DbSet<LeaveRequest> LeaveRequests { get; set; }
    DbSet<LeaveType> LeaveTypes { get; set; }
    DbSet<Manager> Managers { get; set; }
    DbSet<TeamMember> TeamMembers { get; set; }
  
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

  }
}
