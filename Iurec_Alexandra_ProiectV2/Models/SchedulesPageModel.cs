using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Iurec_Alexandra_ProiectV2.Data;


namespace Iurec_Alexandra_ProiectV2.Models
{
    public class SchedulesPageModel : PageModel
    {
        public List<AssignedEmployeeData>AssignedEmployeeDataList;
        public void PopulateAssignedEmployeeData(Iurec_Alexandra_ProiectV2Context context, Contract contract)
        {
            var allEmployees = context.Employee;
            var schedules = new HashSet<int>(
            contract.Schedules.Select(c => c.ContractID));
            AssignedEmployeeDataList = new List<AssignedEmployeeData>();
            foreach (var emp in allEmployees)
            {
                AssignedEmployeeDataList.Add(new AssignedEmployeeData
                {
                    EmployeeID = emp.ID,
                    Name = emp.EmployeeName,
                    Assigned = schedules.Contains(emp.ID)
                });
            }
        }
        public void UpdateSchedules(Iurec_Alexandra_ProiectV2Context context,
        string[] selectedeEmployees, Contract contractToUpdate)
        {
            if (selectedeEmployees == null)
            {
                contractToUpdate.Schedules = new List<Schedule>();
                return;
            }
            var selectedEmployeesHS = new HashSet<string>(selectedeEmployees);
            var schedule = new HashSet<int>
            (contractToUpdate.Schedules.Select(c => c.Employee.ID));
            foreach (var emp in context.Employee)
            {
                if (selectedEmployeesHS.Contains(emp.ID.ToString()))
                {
                    if (!schedule.Contains(emp.ID))
                    {
                        contractToUpdate.Schedules.Add(
                        new Schedule
                        {
                            ContractID = contractToUpdate.ID,
                            EmployeeID = emp.ID
                        });
                    }
                }
                else
                {
                    if (schedule.Contains(emp.ID))
                    {
                        Schedule courseToRemove
                        = contractToUpdate
                        .Schedules
                        .SingleOrDefault(i => i.EmployeeID == emp.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
