using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppoimentManager.Core
{
    public class DataLoader
    {
        private static string AppointmentsHistoryFileName = "appointments.xml";
        private static string EmployeesFileName = "employees.xml";
        private AppointmentsHistory appHistory;
        private Employees employees;

        private static DataLoader current;
        public DataLoader Current
        {
            get
            {
                if (current == null)
                {
                    current = new DataLoader();
                }

                return current;
            }
        }

        public void LoadData()
        {
            LoadEmployees();
            LoadAppointments();
        }

        private void LoadAppointments() 
        {

        }

        private void LoadEmployees() 
        {

        }
    }
}
