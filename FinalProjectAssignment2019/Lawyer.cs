using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectAssignment2019
{
    public class Lawyer : Employee
    {

        private List<Appointment> appointments = new List<Appointment>();
        public Lawyer(string userName, int password) : base(userName, password)
        {
        }
        public Lawyer(int id, string firstName, string lastName, DateTime joinedOn, DateTime dOB, int seniority, ETypeOfSpecialization specialization, ETypeOfEmployee employeeType, ETypeOfLawyer typeOfLawyer)
                : base(id, firstName, lastName, joinedOn, employeeType)
        {
            DOB = dOB;
            Seniority = seniority;
            Specialization = specialization;
            TypeOfLawyer = typeOfLawyer;
        }
        public DateTime DOB { get; set; }
        public int Seniority { get; set; }
        public ETypeOfSpecialization Specialization { get; set; }
        public ETypeOfLawyer TypeOfLawyer { get; set; }

        public bool IsAvailable(Appointment appointment)
        {
            foreach (var storedAppointment in appointments)
            {
                if (storedAppointment.StartDateAndTime == appointment.StartDateAndTime) {
                    return false;
                }
            }

            return true;

        }

        public void Book(Appointment appointment)
        {
            appointments.Add(appointment);        
        }

    }

}
