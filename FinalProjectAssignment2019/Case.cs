using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectAssignment2019
{
    public class Case
    {
        public Case(int clientID)
        {
            ClientID = clientID;
        }
        public int ClientID { get; set; }
        public string ClientName { get; set; }

        public int CaseID { get; set; }

        public ETypeOfSpecialization CaseType { get; set; }
        public DateTime StartDate { get; set; }
        public int TotalCharge { get; set; }
        public ETypeOfLawyer TypeOfLawyer { get; set; }

        public void TotalChargeOfCase()            
            {
            if (this.TypeOfLawyer == ETypeOfLawyer.JuniorLawyer)
            {
                Console.WriteLine($"You Have selected: {this.TypeOfLawyer}\nTotal cost of the case is: 10.000$");
            }
            else if (this.TypeOfLawyer == ETypeOfLawyer.SeniorLawyer)
            {
                Console.WriteLine($"You Have selected: {this.TypeOfLawyer}\nTotal cost of the case is: 20.000$");
            }
        }

        public void CaseDetails()
        {
            Console.WriteLine($"Case details:\nCase ID: {this.CaseID}\nClient ID: {this.ClientID}\nClient Name: {this.ClientName}\nCaseType: {this.CaseType}\nStartDate: {this.StartDate}");
            TotalChargeOfCase();

        }

    }
}
