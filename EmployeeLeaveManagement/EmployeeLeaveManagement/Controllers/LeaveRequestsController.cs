using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeLeaveManagement.Database;
using EmployeeLeaveManagement.Models;
using EmployeeLeaveManagement.Services;

namespace EmployeeLeaveManagement.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class LeaveRequestsController : ControllerBase
  {

    private readonly ILeaveRequestService leaveRequestService;

    public LeaveRequestsController(ILeaveRequestService leaveRequestService)
    {
      this.leaveRequestService = leaveRequestService;

    }

    // GET: api/LeaveRequests
    /*[HttpGet]
    public async Task<ActionResult<IEnumerable<LeaveRequest>>> GetLeaveRequests()
    {
        return await _context.LeaveRequests.ToListAsync();
    }

    // GET: api/LeaveRequests/5
    [HttpGet("{id}")]
    public async Task<ActionResult<LeaveRequest>> GetLeaveRequest(int id)
    {
        var leaveRequest = await _context.LeaveRequests.FindAsync(id);

        if (leaveRequest == null)
        {
            return NotFound();
        }

        return leaveRequest;
    }

    // PUT: api/LeaveRequests/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutLeaveRequest(int id, LeaveRequest leaveRequest)
    {
        if (id != leaveRequest.RequestId)
        {
            return BadRequest();
        }

        _context.Entry(leaveRequest).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!LeaveRequestExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }*/

    // POST: api/LeaveRequests
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public ActionResult<LeaveRequest> PostLeaveRequest(LeaveRequest leaveRequest)
    {
      LeaveRequest lr = leaveRequestService.insertLeaveRequest(leaveRequest);

      return Ok();//reatedAtAction("GetLeaveRequest", new { id = leaveRequest.RequestId }, leaveRequest);
    }
  }
}

        // DELETE: api/LeaveRequests/5
        /*[HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeaveRequest(int id)
        {
            var leaveRequest = await _context.LeaveRequests.FindAsync(id);
            if (leaveRequest == null)
            {
                return NotFound();
            }

            _context.LeaveRequests.Remove(leaveRequest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LeaveRequestExists(int id)
        {
            return _context.LeaveRequests.Any(e => e.RequestId == id);
        }
    }
}*/
