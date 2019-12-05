using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectAssignment2019
{
    public class MeetingRoom
    {

        public EMeetingRoomName roomName;
        public List<Appointment> appointments;

        public MeetingRoom(EMeetingRoomName name)
        {
            roomName = name;
            appointments = new List<Appointment>();
        }

        public bool isAvailable(Appointment appointment)
        {
            bool available = true;
            foreach (var storedAppointment in appointments)
            {
                if (storedAppointment.StartDateAndTime == appointment.StartDateAndTime)
                {
                    available = false;
                }
            }
            return available;
        }
    }
}
