namespace EmployeeLeaveManagement.Services
{
  public interface ILeaveBalanceService
  {
    public int getLeaveBalance(int empId, int leaveTypeId);
  }
}
