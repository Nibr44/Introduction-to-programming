using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectAssignment2019
{
    public abstract class Employee
    {
        public Employee() { } //Makes it possible to add employee without inserting properties
        public Employee(string userName, int password) //Makes it possible to add employee without inserting properties
        {

            UserName = userName;
            Password = password;

        }
        public int ID { get; set; }
        public ETypeOfEmployee EmployeeType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime JoinedOn{ get; set; }
        public string UserName{ get; set; }
        public int Password{ get; set; }


        public Employee(int id, string firstName, string lastName, DateTime joinedOn, ETypeOfEmployee employeeType)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            JoinedOn = joinedOn;
            EmployeeType = employeeType;
        }
 


    }
    public class Receptionist : Employee
    {
        public Receptionist(string userName, int password)
       : base(userName, password)
        {
        }
        public Receptionist(int id, string firstName, string lastName, DateTime joinedOn, ETypeOfEmployee employeeType)
            : base(id, firstName, lastName, joinedOn, employeeType)
        {
        }

        public void MainMenu()
        {

        }
    }

    public class Administrative : Receptionist
    {
        public Administrative(string userName, int password)
            : base (userName, password)
        {
        }

        public Administrative(int id, string firstName, string lastName, DateTime joinedOn, string role, ETypeOfEmployee employeeType)
            : base(id, firstName, lastName, joinedOn, employeeType)
        {
            Role = role;
        }
        public string Role { get; set; }

        
    }
   
}
