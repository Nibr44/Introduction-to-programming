using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace FinalProjectAssignment2019
{
    public class Processor
    {
        ETypeOfEmployee employeeType = ETypeOfEmployee.Undefined;
        public List<DateTime> bookings = new List<DateTime>();
        private List<Case> cases = new List<Case>();
        private List<Appointment> appointments = new List<Appointment>();
        private List<Client> clients = new List<Client>(2);
        private List<Lawyer> lawyers = new List<Lawyer>();
        private List<Receptionist> receptionists = new List<Receptionist>();
        private List<Administrative> administratives = new List<Administrative>();
        private List<MeetingRoom> meetingRooms = new List<MeetingRoom>();
        
        Receptionist receptionistUserNameAndPassword = new Receptionist("qwerty", 12345);
        Lawyer LawyerUserNameAndPassword = new Lawyer("Lawyer", 123);//Default password and username for all JuniorLawyer
        Administrative AdmUserNameAndPassword = new Administrative("admstaff", 1234); //Default password and username for all AdmStaff

        public void Process()
        {
            signEmployees(); //creates objects of each respective class
            registerMeetingRooms();//Creates object of the MéetingRooms

            int selection = -1;
            do
            {
                selection = MainLoginInput();
                switch (selection)
                {
                    case 1:
                        employeeType = ETypeOfEmployee.Receptionist;
                        ReceptionistLogin();
                        break;
                    case 2:
                        employeeType = ETypeOfEmployee.AdministrativeStaff;
                        AdministrativeStaffLogin();

                        break;
                    case 3:
                        employeeType = ETypeOfEmployee.Lawyer;
                        LawyerLogin();
                        break;
                    default:
                        Console.WriteLine("Invalid selection");
                        break;
                         
                }
            } while (selection != 4);
        }
        private void registerMeetingRooms()
        {
            meetingRooms.Add(new MeetingRoom(EMeetingRoomName.Aqarium));
            meetingRooms.Add(new MeetingRoom(EMeetingRoomName.Cave));
            meetingRooms.Add(new MeetingRoom(EMeetingRoomName.Cube));
        }
        private void signEmployees()
        {
            receptionists.Add(new Receptionist(1, "Donna", "Paulsen", new DateTime(2000, 01, 04), ETypeOfEmployee.Receptionist)); //A New object for the Receptionist class
            administratives.Add(new Administrative(1, "Lis", "Lissi", new DateTime(2002, 01, 04), "Cleaning", ETypeOfEmployee.AdministrativeStaff));//A New object for the adm.staff class
            administratives.Add(new Administrative(2, "Leif", "Leifi", new DateTime(2007, 01, 04), "IT Support", ETypeOfEmployee.AdministrativeStaff));
            administratives.Add(new Administrative(3, "Linda", "Lindi", new DateTime(2016, 01, 04), "HandyMan", ETypeOfEmployee.AdministrativeStaff));
            lawyers.Add(new Lawyer(1, "Lonni", "B", new DateTime(2016, 01, 04), new DateTime(1993, 01, 04), 3, ETypeOfSpecialization.Corporate, ETypeOfEmployee.Lawyer, ETypeOfLawyer.JuniorLawyer)); //A New object for the JuniorLawyer class
            lawyers.Add(new Lawyer(2, "Astrid", "G", new DateTime(2016, 01, 04), new DateTime(1993, 01, 04), 3, ETypeOfSpecialization.FamilyCase, ETypeOfEmployee.Lawyer, ETypeOfLawyer.JuniorLawyer));
            lawyers.Add(new Lawyer(3, "Helene", "C", new DateTime(2016, 01, 04), new DateTime(1993, 01, 04), 3, ETypeOfSpecialization.CriminalCase, ETypeOfEmployee.Lawyer, ETypeOfLawyer.JuniorLawyer));
            lawyers.Add(new Lawyer(4, "Kurt", "K", new DateTime(2017, 01, 04), new DateTime(1993, 01, 04), 2, ETypeOfSpecialization.Corporate, ETypeOfEmployee.Lawyer, ETypeOfLawyer.JuniorLawyer));
            lawyers.Add(new Lawyer(5, "Franz", "H", new DateTime(2017, 01, 04), new DateTime(1993, 01, 04), 2, ETypeOfSpecialization.FamilyCase, ETypeOfEmployee.Lawyer, ETypeOfLawyer.JuniorLawyer));
            lawyers.Add(new Lawyer(6, "Ida", "G", new DateTime(2017, 01, 04), new DateTime(1993, 01, 04), 2, ETypeOfSpecialization.CriminalCase, ETypeOfEmployee.Lawyer, ETypeOfLawyer.JuniorLawyer));
            lawyers.Add(new Lawyer(7, "August", "K", new DateTime(2018, 01, 04), new DateTime(1993, 01, 04), 1, ETypeOfSpecialization.Corporate, ETypeOfEmployee.Lawyer, ETypeOfLawyer.JuniorLawyer));
            lawyers.Add(new Lawyer(8, "Kasper", "K", new DateTime(2019, 01, 04), new DateTime(1993, 01, 04), 1, ETypeOfSpecialization.FamilyCase, ETypeOfEmployee.Lawyer, ETypeOfLawyer.JuniorLawyer));
            lawyers.Add(new Lawyer(9, "Emil", "B", new DateTime(2019, 01, 04), new DateTime(1993, 01, 04), 0, ETypeOfSpecialization.CriminalCase, ETypeOfEmployee.Lawyer, ETypeOfLawyer.JuniorLawyer));

            lawyers.Add(new Lawyer(10, "Nicklas", "Bruttin", new DateTime(2010, 01, 04), new DateTime(1990, 01, 04), 10, ETypeOfSpecialization.Corporate, ETypeOfEmployee.Lawyer, ETypeOfLawyer.SeniorLawyer));//A New object for the SeniorLawyer class
            lawyers.Add(new Lawyer(20, "Hanz", "Hanzi", new DateTime(2006, 01, 04), new DateTime(1985, 01, 04), 15, ETypeOfSpecialization.FamilyCase, ETypeOfEmployee.Lawyer, ETypeOfLawyer.SeniorLawyer));
            lawyers.Add(new Lawyer(30, "Harvey", "Specter", new DateTime(2002, 01, 04), new DateTime(1970, 01, 04), 20, ETypeOfSpecialization.CriminalCase, ETypeOfEmployee.Lawyer, ETypeOfLawyer.SeniorLawyer));

        }
        private void ReceptionistLogin() //method for the receptionist to login
        {
            ReceptionistMainMenu(); // Dont forget to delete

            Console.Clear();
            Console.WriteLine($"Welcome to the {employeeType} login page");
            string Receptionistusername;
            int Receptionistpassword;
            int ctr = 0;

            do
            {
                Console.Write("N.B. : Default user name and password is :qwerty and 12345\n");
                Console.Write("-----------------------------------------------------------\n");
                Console.Write("Input a username: ");
                Receptionistusername = Console.ReadLine();

                Console.Write("Input a password: ");
                Receptionistpassword = int.Parse(Console.ReadLine());

                if (Receptionistusername != receptionistUserNameAndPassword.UserName || Receptionistpassword != receptionistUserNameAndPassword.Password)
                {
                    ctr++;
                    if (ctr < 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("The username or password is wrong");
                        Console.WriteLine($"You have {3 - ctr} attempts left");
                        Console.ResetColor();
                        Thread.Sleep(2000);
                        Console.Clear();
                    }
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("\nThe password entered successfully!\n\n");
                    Console.ResetColor();
                    Thread.Sleep(2000);
                    ReceptionistMainMenu();
                }


            }
            while ((Receptionistusername != receptionistUserNameAndPassword.UserName || Receptionistpassword != receptionistUserNameAndPassword.Password) && (ctr != 3));
            {
                if (ctr == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"\nYou have entered a wrong username and password three times. please try again later!\n\n");
                    Console.ResetColor();
                    Thread.Sleep(2000);
                    Environment.Exit(0);
                }
            }
        }
        private void AdministrativeStaffLogin() //method for the AdministrateiveStaff to login
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the {employeeType} login page");
            string username;
            int password;
            int ctr = 0;

            do
            {
                Console.Write("N.B. : Default user name and password is :admstaff and 1234\n");
                Console.Write("-----------------------------------------------------------\n");
                Console.Write("Input a username: ");
                username = Console.ReadLine();

                Console.Write("Input a password: ");
                password = int.Parse(Console.ReadLine());

                if (username != AdmUserNameAndPassword.UserName || password != AdmUserNameAndPassword.Password)
                {
                    ctr++;
                    if (ctr < 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("The username or password is wrong");
                        Console.WriteLine($"You have {3 - ctr} attempts left");
                        Console.ResetColor();
                        Thread.Sleep(2000);
                        Console.Clear();
                    }
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("\nThe password entered successfully!\n\n");
                    Console.ResetColor();
                    AdmMainMenu();
                }
            }
            while ((username != AdmUserNameAndPassword.UserName || password != AdmUserNameAndPassword.Password) && (ctr != 3));
            {
                if (ctr == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"\nYou have entered a wrong username and password three times. please try again later!\n\n");
                    Console.ResetColor();
                    Thread.Sleep(2000);
                    Environment.Exit(0);
                }
            }
        }
        private void LawyerLogin() //method for the Lawyer to login
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the {employeeType} login page");
            string LawyerUsername;
            int LawyerPassword;
            int ctr = 0;

            do
            {
                Console.Write("N.B. : Default user name and password is :Lawyer and 123\n");
                Console.Write("-----------------------------------------------------------\n");
                Console.Write("Input a username: ");
                LawyerUsername = Console.ReadLine();

                Console.Write("Input a password: ");
                LawyerPassword = int.Parse(Console.ReadLine());

                if (LawyerUsername != LawyerUserNameAndPassword.UserName || LawyerPassword != LawyerUserNameAndPassword.Password)
                {
                    ctr++;
                    if (ctr < 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("The username or password is wrong");
                        Console.WriteLine($"You have {3 - ctr} attempts left");
                        Console.ResetColor();
                        Thread.Sleep(2000);
                        Console.Clear();
                    }
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("\nThe password entered successfully!\n\n");
                    Console.ResetColor();
                    LawyerMainMenu();
                }


            }
            while ((LawyerUsername != LawyerUserNameAndPassword.UserName || LawyerPassword != LawyerUserNameAndPassword.Password) && (ctr != 3));
            {
                if (ctr == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"\nYou have entered a wrong username and password three times. please try again later!\n\n");
                    Console.ResetColor();
                    Thread.Sleep(2000);
                    Environment.Exit(0);
                }
            }

        }
        private int MainLoginInput() //Method to choose which employee function and thereby going to the login of that employee type

        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("***** Welcome to LegalX *****\n");
            Console.ResetColor();
            Console.WriteLine("Please select your EmployeeType");
            Console.WriteLine("1. Receptionist");
            Console.WriteLine("2. AdministrativeStaff");
            Console.WriteLine("3. Lawyer");
            Console.WriteLine("4. Exit\n");
            Console.Write("Enter here: ");

            return TryCatchMainMenu();
        }

        private int TryCatchMainMenu()//Method to use Try Parse on MainLoginInput
        {
            int selection = -1; //just a default selection

            try //Try Catch
            {
                string actionSelection = Console.ReadLine();
                if (int.TryParse(actionSelection, out selection) == false)
                {
                    throw new Exception("Invalid selection");
                }

                if (selection < 0 || selection > 4)
                {
                    throw new Exception("Invalid selection");
                }
                return selection;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}. Select again.");
                Console.WriteLine("Press any key to try again");
                Console.ReadLine();
                Console.Clear();

                MainLoginInput();
            }

            return 4;
        }

        public void WelcometoMainMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($" ****** Welcome to the {employeeType} main menu ****** \n");
            Console.ResetColor();
            Console.WriteLine("Please select ont of the following options:");
        }//Generic Welcome (Can be used to all mainMenu)
        public void ReceptionistMainMenu()
        
        {
            WelcometoMainMenu();
            Console.WriteLine("1. Add a new Appointment");
            Console.WriteLine("2. List all appointments");
            Console.WriteLine("3. List all appointsments for the day");
            Console.WriteLine("4. List all clients");
            Console.WriteLine("5. Log out");
            Console.WriteLine("6. Exit");

            int selection = -1;

            try //Try Catch
            {
                string actionSelection = Console.ReadLine();
                if (int.TryParse(actionSelection, out selection) == false)
                {
                    throw new Exception("Invalid selection");
                }

                if (selection < 0 || selection > 6)
                {
                    throw new Exception("Invalid selection");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}. Select again.");
                Console.WriteLine("Press any key to try again");
                Console.ReadLine();
                Console.Clear();

                EmployeeType();
            } 
            do
            {
                switch (selection)
                {
                    case 1:
                        CreateNewAppointment();
                        break;
                    case 2:
                        ListAllAppointments();
                        break;
                    case 3:
                        ListAllAppointmentsToday();
                        break;
                    case 4:
                        ListAllClients();
                        break;
                    case 5:
                        Process();
                        break;
                    default:
                        Console.WriteLine("Invalid selection");
                        break;
                }
            } while (selection != 6);

        }//Receptionist MainMenu
        public void AdmMainMenu()
        {
            WelcometoMainMenu();


            WelcometoMainMenu();
            Console.WriteLine("1. List all appointments");
            Console.WriteLine("2. List all cases");
            Console.WriteLine("3. Log out");
            Console.WriteLine("4. Exit");
            Console.Write("Enter here:");

            int selection = -1;

            try //Try Catch
            {
                string actionSelection = Console.ReadLine();
                if (int.TryParse(actionSelection, out selection) == false)
                {
                    throw new Exception("Invalid selection");
                }

                if (selection < 0 || selection > 3)
                {
                    throw new Exception("Invalid selection");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}. Select again.");
                Console.WriteLine("Press any key to try again");
                Console.ReadLine();
                Console.Clear();

                EmployeeType();
            }
            do
            {
                switch (selection)
                {
                    case 1:
                        ListAllAppointments();
                        break;
                    case 2:
                        ListAllCases();
                        break;
                    case 3:
                        Process();
                        break;
                    default:
                        Console.WriteLine("Invalid selection");
                        break;
                }
            } while (selection != 4);

            Console.ReadLine();
        }//Adm. Staff MainMenu
        public void LawyerMainMenu()
        {
            WelcometoMainMenu();
            Console.WriteLine("1. List all cases");
            Console.WriteLine("2. Create a new case");
            Console.WriteLine("3. List all appointsments");
            Console.WriteLine("4. Log out");
            Console.WriteLine("5. Exit");
            int selection = -1;
            try
            {
                string actionSelection = Console.ReadLine();
                if (int.TryParse(actionSelection, out selection) == false)
                {
                    throw new Exception("Invalid selection");
                }

                if (selection < 0 || selection > 5)
                {
                    throw new Exception("Invalid selection");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}. Select again.");
                Console.WriteLine("Press any key to try again");
                Console.ReadLine();
                Console.Clear();

                MainLoginInput();
            }

            do
            {
                switch (selection)
                {
                    case 1:
                        ListAllCases();
                        break;
                    case 2:
                        CreateCase();
                        break;
                    case 3:
                        ListAllAppointments();
                        break;
                    case 4:
                        Process();//Functions as log out 
                        break;
                    default:
                        Console.WriteLine("Invalid selection");
                        break;
                }
            } while (selection != 5);


        } //Lawyer MainMenu
        private void createApointment()
        {

            // Create client if client does not exist

            // Add client to list of clients

            // Create empty 

            // Assign ID

            // Assign ClientID

            // Assign LawyerID

            // Assign Date and time

            // Assign MeetingRoom

            // Assign Apointment to Client and Lawyer

        }
        private void CreateNewAppointment()
        {
            Console.Clear();
            Console.WriteLine($"****** Welcome  {DateTime.Today} ******\nThis is the process to add an Appointment\n");
            Client client = CreateClient(); //Call CreateClient Method to create the client
            Appointment appointment = new Appointment();
            appointment.ClientID = client.Id;
            AppointmentDateAndTime(appointment);


            List<MeetingRoom> availableMeetingRoom = meetingRooms.Where(x => x.isAvailable(appointment)).ToList();
            List<Lawyer> relevantLawyers = lawyers.Where(x => x.Specialization == client.CaseType && x.IsAvailable(appointment)).ToList(); //Creates a list with the relevant lawyers based on the clients need of caseType and check if they are available
            Console.WriteLine($"___________________________________________________________\nHere is a list of all lawyers specialized in {client.CaseType}:");
            foreach (Lawyer lawyer in relevantLawyers)
            {

                Console.WriteLine($"\nLawyer ID: {lawyer.ID}\nLawyer name: {lawyer.FirstName}\nLaywer speciality: {lawyer.Specialization}\nLawyer type: {lawyer.TypeOfLawyer} {lawyer.IsAvailable(appointment)}");
            }
            Console.WriteLine("___________________________________________________________\n");
            if (relevantLawyers.Count > 0)// Add relevenat lawyer to case
            {
                appointment.LawyerID = relevantLawyers[0].ID;
                appointment.LawyerName = relevantLawyers[0].FirstName;
                appointment.TypeOfLawyer = relevantLawyers[0].TypeOfLawyer;

                foreach (var lawyer in lawyers)
                {
                    if (lawyer.ID == appointment.LawyerID) {
                        lawyer.Book(appointment);
                        break;
                    }
                }

            }
            else
            {
                Console.WriteLine("No available lawyer"); // Inform users of no available lawyers
            }
            Console.WriteLine($"Your appointed lawyer is: {appointment.LawyerName} - (ID: {appointment.LawyerID})\n");


            //Console.WriteLine("Book the appointment by entering the following information:");
            appointment.ID = appointments.Count() + 1; //Assign appointment ID
            Console.Write($"Appointment ID: {appointment.ID}\n");// 


            Console.WriteLine($"Client ID: {client.Id}");

            //AppointmentDateAndTime(appointment);
            //availablelawyers.book(CreateNewAppointment StartDateAndTime);

            List<Lawyer> currentLawyer = lawyers.Where(x => x.ID == appointment.LawyerID).ToList();

            Console.WriteLine("Please select the a meetingroom:\n1. Aquarium\n2. Cube\n3. Cave");
            Console.Write("Enter input here: ");
            int meetingRoom = int.Parse(Console.ReadLine());

            // Asign meeting room

            switch (meetingRoom)
            {
                case 1:
                    appointment.MeetingRoom = EMeetingRoomName.Aqarium;
                    break;
                case 2:
                    appointment.MeetingRoom = EMeetingRoomName.Cave;
                    break;
                case 3:
                    appointment.MeetingRoom = EMeetingRoomName.Cube;
                    break;
                default:
                    appointment.MeetingRoom = EMeetingRoomName.Unknown;
                    break;
            }


            appointments.Add(appointment);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nThe appointment has been created");
            Console.ResetColor();

            Console.WriteLine("Press any key to go back to the main menu");
            Console.ReadLine();
            ReceptionistMainMenu();

        } //Create new appointment
        private static void AppointmentDateAndTime(Appointment appointment)
        {
            Console.Write("Please select a date for the appointment(MM/dd/yyyy HH:mm): ");
            appointment.StartDateAndTime = readDate();//Convert.ToDateTime(Console.ReadLine());

            while (appointment.StartDateAndTime < DateTime.Today)
            {
                Console.WriteLine("Invalid date. Please enter date after today");
                appointment.StartDateAndTime = readDate();
            }

            appointment.EndDateAndTime = appointment.StartDateAndTime.AddHours(1);
            Console.WriteLine($"Start time: {appointment.StartDateAndTime.ToString("MM/dd/yyyy HH:mm")}\nEnd time: {appointment.EndDateAndTime.ToString("MM/dd/yyyy HH:mm")}");
        }

        private static DateTime readDate()
        {
            // var dateTime
            DateTime dateTime = DateTime.MinValue;

            string userDate = Console.ReadLine();
            while (dateTime == DateTime.MinValue)
            {

                // Validate DateTime
                if (DateTime.TryParse(userDate, out dateTime))
                {
                    return dateTime;
                }
                else
                {
                    Console.WriteLine("please try again");
                    userDate = Console.ReadLine();
                    // Aww.. :(
                }
            }
            // if invalid ask again

            // return Date
            return dateTime;

            // return Convert.ToDateTime(Console.ReadLine());

        }

        private Client CreateClient()
        {
            Console.WriteLine($"___________________________________________________________\nPlease start by adding a client:\n");

            Client client = new Client();
            client.Id = clients.Count() + 1;
            Console.Write($"Client ID: {client.Id}\n");// Define ClientID
            Console.Write("Enter Name: ");
            client.Name = Console.ReadLine();
            /*Console.Write("Enter Date of Birth(dd/mm/yyyy): ");
            client.DOB = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Enter Street Name: ");w
            client.Street = Console.ReadLine();

            Console.Write("Enter Zip-code: ");
            client.Zip = int.Parse(Console.ReadLine());

            Console.Write("Enter City: ");
            client.City = Console.ReadLine();
            */
            Console.WriteLine("Please select the type of Case:\n1. Corporate\n2. FamilyCase\n3. CriminalCase\n4. Undefined");
            Console.Write("Enter input here: ");
            int typeOfCase = int.Parse(Console.ReadLine());

            switch (typeOfCase)
            {
                case 1:
                    client.CaseType = ETypeOfSpecialization.Corporate;
                    break;
                case 2:
                    client.CaseType = ETypeOfSpecialization.FamilyCase;
                    break;
                case 3:
                    client.CaseType = ETypeOfSpecialization.CriminalCase;
                    break;
                default:
                    client.CaseType = ETypeOfSpecialization.Undefined;
                    break;
            }
            clients.Add(client);
            return client;
        }
      
        public void CreateCase() //Method for creating a case
        {
            Console.Clear();
            Console.WriteLine($"****** Welcome  {DateTime.Today} ******\n\nThis is the process to create a new case\n");
            Console.WriteLine("___________________________________________________________");
            Console.WriteLine("Here is a list of all the clients:");
            foreach (Client client in clients)
            {
                client.ClientDetails();
            }
            Console.WriteLine("___________________________________________________________");
            Console.Write("Please enter the ID of the client you wish to create a case for: ");
            int clientID = int.Parse(Console.ReadLine());
            Case newCase = new Case(clientID);
            List<Client> clientmatch = clients.Where(x => x.Id == (clientID)).ToList();
            if (clientmatch.Count == 0)
            {
                Console.WriteLine("It looks like no clients of that ID has been added to the system\n");
                Console.WriteLine("Please add a client to the system\nPress Any key to go back");
                Console.ReadLine();
                LawyerMainMenu();

            }
            else if (clients.Any())
            {
                Console.WriteLine($"Here is the client details with ID: {clientID}");
                foreach (Client cmatch in clientmatch)
                {
                    cmatch.ClientDetails();
                }
            }
       

            newCase.CaseID = cases.Count() + 1;//int.Parse(Console.ReadLine());
            Console.WriteLine($"Case ID:  {newCase.CaseID}\n");

            Console.WriteLine("Please select the type of Case:\n1. Corporate\n2. FamilyCase\n3. CriminalCase\n4. Undefined");
            Console.Write("Enter input here: ");
            int typeOfCase = int.Parse(Console.ReadLine());

            switch (typeOfCase)
            {
                case 1:
                    newCase.CaseType = ETypeOfSpecialization.Corporate;
                    break;
                case 2:
                    newCase.CaseType = ETypeOfSpecialization.FamilyCase;
                    break;
                case 3:
                    newCase.CaseType = ETypeOfSpecialization.CriminalCase;
                    break;
                default:
                    newCase.CaseType = ETypeOfSpecialization.Undefined;
                    break;
            }
            Console.WriteLine($"\nType of Case: {newCase.CaseType}");
            Console.Write("\nDo you need a junior or a senior lawyer?\n1. Junior Lawyer\n2. Senior Lawyer\nEnter input here: ");
            int typeOfLawyer = int.Parse(Console.ReadLine());

            switch (typeOfLawyer)
            {
                case 1:
                    newCase.TypeOfLawyer = ETypeOfLawyer.JuniorLawyer;
                    break;
                case 2:
                    newCase.TypeOfLawyer = ETypeOfLawyer.SeniorLawyer;
                    break;
                default:
                    newCase.TypeOfLawyer = ETypeOfLawyer.Undefined;
                    break;
            }


            Console.Write("Please select a startdate for the case (mm/dd/yyyy): ");
            newCase.StartDate = Convert.ToDateTime(Console.ReadLine());

            newCase.TotalChargeOfCase();

            cases.Add(newCase);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nThe Case has been created");
            Console.ResetColor();

            Console.WriteLine("Press any key to go back to the main menu");
            Console.ReadLine();
            LawyerMainMenu();

        }
        /*
        private List<MeetingRoom> findAvailableMeetingRooms(DateTime dateAndTime)
        {
            List<MeetingRoom> availableRooms = new List<MeetingRoom>();
            foreach ( MeetingRoom room in meetingRooms)
            {

            }
            return ;

        }
        */
        public void ListAllAppointments() //Method for listing all appointments
        {

            if (appointments.Count == 0)
            {
                Console.WriteLine("It looks like no appointments have been created \n");
            }
            else if (appointments.Any())
            {
                Console.WriteLine("Here is list of all appointments");
                foreach (Appointment appointments in appointments)
                {
                    appointments.AppointmentDetails();
                }
            }
            Console.WriteLine("Press any key to go back to the main menu");
            Console.ReadLine();
            EmployeeType();
            
        }
        public void ListAllAppointmentsToday() //Method for listing all appointments for today
        {
            Console.WriteLine("Here is list of Appointments for today:");

            appointments = appointments.Where(x => x.StartDateAndTime == DateTime.Today).ToList();

            foreach (var appointments in appointments)

                foreach (Appointment appointment in this.appointments)
                {
                    Console.WriteLine($"Appointment ID: {appointment.ID}\n Client ID: {appointment.ClientID}");
                }
            Console.WriteLine("Press any key to go back to the main menu");
            Console.ReadLine();
            EmployeeType();
        }
        public void ListAllClients() //Method for listing all Clients

        {
            Console.WriteLine("___________________________________________________________");
            if (clients.Count == 0)
            {
                Console.WriteLine("It looks like no clients have been added to the system\n");
            }
            else if (clients.Any())
            {
                Console.WriteLine("Here is list of all clients");
                foreach (Client clients in clients)
                {
                    clients.ClientDetails();
                }
            }
            Console.WriteLine("___________________________________________________________");
            Console.WriteLine("Press any key to go back to the main menu");
            Console.ReadLine();
            EmployeeType();
        }
        public void ListAllCases() //Method for listing all Cases
        {
            if(cases.Count == 0)
            {
                Console.WriteLine("It looks like no cases have been created\n");
            }
            else if (cases.Any())
            {
                Console.WriteLine("Here is list of Cases");
            foreach (Case cases in cases)
                {
                    cases.CaseDetails();
                }
            }
            Console.WriteLine("Press any key to go back to the main menu");
            Console.ReadLine();
            EmployeeType();
        }
        private void EmployeeType()
        {
            if (employeeType == ETypeOfEmployee.Receptionist)
            {
                ReceptionistMainMenu();
            }
            else if (employeeType == ETypeOfEmployee.Lawyer)
            {
                LawyerMainMenu();
            }
            else if (employeeType == ETypeOfEmployee.AdministrativeStaff)
            {
                AdmMainMenu();
            }
        }//Method to go back to the relevant mainmenu

    }


}
