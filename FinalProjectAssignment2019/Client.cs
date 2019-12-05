using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectAssignment2019
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public ETypeOfSpecialization CaseType { get; set; }
        public string Street { get; set; }
        public int Zip{ get; set; }
        public string City{ get; set; }


        public void ClientDetails()
        {
            Console.WriteLine($"\nClient details:\nID: {this.Id}\nName: {this.Name}\nDOB: {this.DOB}\nStreet: {this.Street}\nZip: {this.Zip}\nCity: {this.City}");

        }


    }
}
