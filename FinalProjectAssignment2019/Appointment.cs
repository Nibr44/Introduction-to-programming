using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectAssignment2019
{
    public class Appointment
    {

        public int ID { get; set; }
        public int ClientID { get; set; }
        public int LawyerID { get; set; }
        public ETypeOfLawyer TypeOfLawyer { get; set; }
        public string LawyerName { get; set; }
        public DateTime StartDateAndTime { get; set; }
        public DateTime EndDateAndTime{ get; set; }
        public EMeetingRoomName MeetingRoom { get; set; }
        public void AppointmentDetails()
        {
            Console.WriteLine($"\nAppointment details:\nAppointment ID: {this.ID}\nClient ID: {this.ClientID}\nLawyer ID: {this.LawyerID}\nDate of Appointments: {this.StartDateAndTime}\nMeetingRoome: {this.MeetingRoom}");

        }

        /*public override string ToString()
        {
            StringBuilder appointmentString = new StringBuilder();
            //appointmentString.AppendLine($"Appointment ID: {ID}\nClient ID: { ClientDetail.Id}");
            //appointmentString.AppendLine($"Appointment ID: {ID}\nClient ID: { ClientDetail.Id}\n\n\n Date and Time {new DateTime()}\n MeetingRoom: {MeetingRoom}");
            //appointmentString.AppendLine(ClientAppointment.ToString());
            return appointmentString.ToString();
        }*/
    }
}
// Junior Lawyer ID: { JuniorLawyerDetail.ID}\n Senior Lawyer ID: { SeniorLawyerDetail.ID}