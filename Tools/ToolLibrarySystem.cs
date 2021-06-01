using Tools;
using System;
using Interfaces;
using System.Collections.Generic;

namespace P
{
    public class ToolLibrarySystem : iToolLibrarySystem
    {
        // INDEX ----------------------------------------------------------------------------------------------------------------
        //Categories (Gardening, Flooring, Fencing, Measuring, Cleaning, Painting, Electronic, Electricity, Automotve)
        public Dictionary<int, ToolCollection> Gardening = new Dictionary<int, ToolCollection>(); public Dictionary<int, ToolCollection> Flooring = new Dictionary<int, ToolCollection>(); public Dictionary<int, ToolCollection> Fencing = new Dictionary<int, ToolCollection>(); public Dictionary<int, ToolCollection> Measuring = new Dictionary<int, ToolCollection>(); public Dictionary<int, ToolCollection> Cleaning = new Dictionary<int, ToolCollection>(); public Dictionary<int, ToolCollection> Painting = new Dictionary<int, ToolCollection>(); public Dictionary<int, ToolCollection> Electronic = new Dictionary<int, ToolCollection>(); public Dictionary<int, ToolCollection> Electricity = new Dictionary<int, ToolCollection>(); public Dictionary<int, ToolCollection> Automotive = new Dictionary<int, ToolCollection>();
        //Tools
        private ToolCollection LineTrimmers = new ToolCollection(); private ToolCollection LawnMowers = new ToolCollection(); private ToolCollection GardenHandTools = new ToolCollection(); private ToolCollection Wheelbarrows = new ToolCollection(); private ToolCollection GardenPowerTools = new ToolCollection();
        private ToolCollection Scrapers = new ToolCollection(); private ToolCollection FloorLasers = new ToolCollection(); private ToolCollection FloorLevellingTools = new ToolCollection(); private ToolCollection FloorLevellingMaterials = new ToolCollection(); private ToolCollection FloorHandTools = new ToolCollection(); private ToolCollection TilingTools = new ToolCollection();
        private ToolCollection FencinHandTools = new ToolCollection(); private ToolCollection ElectricFencing = new ToolCollection(); private ToolCollection SteelFencingTools = new ToolCollection(); private ToolCollection FencingPowerTools = new ToolCollection(); private ToolCollection FencingAccessories = new ToolCollection();
        private ToolCollection DistanceTools = new ToolCollection(); private ToolCollection LaserMeasurer = new ToolCollection(); private ToolCollection MeasuringJugs = new ToolCollection(); private ToolCollection TemperatureHumidityTools = new ToolCollection(); private ToolCollection LevellingTools = new ToolCollection(); private ToolCollection Markers = new ToolCollection();
        private ToolCollection Draining = new ToolCollection(); private ToolCollection CarCleaning = new ToolCollection(); private ToolCollection Vacuum = new ToolCollection(); private ToolCollection PressureCleaners = new ToolCollection(); private ToolCollection PoolCleaning = new ToolCollection(); private ToolCollection FloorCleaning = new ToolCollection();
        private ToolCollection SandingTools = new ToolCollection(); private ToolCollection Brushes = new ToolCollection(); private ToolCollection Rollers = new ToolCollection(); private ToolCollection PaintRemovalTools = new ToolCollection(); private ToolCollection PaintScrapers = new ToolCollection(); private ToolCollection Sprayers = new ToolCollection();
        private ToolCollection VoltageTester = new ToolCollection(); private ToolCollection Oscilloscopes = new ToolCollection(); private ToolCollection ThermalImaging = new ToolCollection(); private ToolCollection DataTestTool = new ToolCollection(); private ToolCollection InsulationTesters = new ToolCollection();
        private ToolCollection TestEquipment = new ToolCollection(); private ToolCollection SafetyEquipment = new ToolCollection(); private ToolCollection BasicHandTools = new ToolCollection(); private ToolCollection CircuitProtection = new ToolCollection(); private ToolCollection CableTools = new ToolCollection();
        private ToolCollection Jacks = new ToolCollection(); private ToolCollection AirCompressors = new ToolCollection(); private ToolCollection BatteryChargers = new ToolCollection(); private ToolCollection SocketTools = new ToolCollection(); private ToolCollection Braking = new ToolCollection(); private ToolCollection Drivetrain = new ToolCollection();

        //assigns tools to the respective category and initialises main menu
        public ToolLibrarySystem()
        {
            Gardening.Add(1, LineTrimmers); Gardening.Add(2, LawnMowers); Gardening.Add(3, GardenHandTools); Gardening.Add(4, Wheelbarrows); Gardening.Add(5, GardenPowerTools);
            Flooring.Add(1, Scrapers); Flooring.Add(2, FloorLasers); Flooring.Add(3, FloorLevellingTools); Flooring.Add(4, FloorLevellingMaterials); Flooring.Add(5, FloorHandTools); Flooring.Add(6, TilingTools);
            Fencing.Add(1, FencinHandTools); Fencing.Add(2, ElectricFencing); Fencing.Add(3, SteelFencingTools); Fencing.Add(4, FencingPowerTools); Fencing.Add(5, FencingAccessories);
            Measuring.Add(1, DistanceTools); Measuring.Add(2, LaserMeasurer); Measuring.Add(3, MeasuringJugs); Measuring.Add(4, TemperatureHumidityTools); Measuring.Add(5, LevellingTools); Measuring.Add(6, Markers);
            Cleaning.Add(1, Draining); Cleaning.Add(2, CarCleaning); Cleaning.Add(3, Vacuum); Cleaning.Add(4, PressureCleaners); Cleaning.Add(5, PoolCleaning); Cleaning.Add(6, FloorCleaning);
            Painting.Add(1, SandingTools); Painting.Add(2, Brushes); Painting.Add(3, Rollers); Painting.Add(4, PaintRemovalTools); Painting.Add(5, PaintScrapers); Painting.Add(6, Sprayers);
            Electronic.Add(1, VoltageTester); Electronic.Add(2, Oscilloscopes); Electronic.Add(3, ThermalImaging); Electronic.Add(4, DataTestTool); Electronic.Add(5, InsulationTesters);
            Electricity.Add(1, TestEquipment); Electricity.Add(2, SafetyEquipment); Electricity.Add(3, BasicHandTools); Electricity.Add(4, CircuitProtection); Electricity.Add(5, CableTools);
            Automotive.Add(1, Jacks); Automotive.Add(2, AirCompressors); Automotive.Add(3, BatteryChargers); Automotive.Add(4, SocketTools); Automotive.Add(5, Braking); Automotive.Add(6, Drivetrain);

            MainMenu();
        }

        // DATA -----------------------------------------------------------------------------------------------------------------
        //current member logged in
        public Member crntMem;
        //member collection
        public MemberCollection mem = new MemberCollection();
        //currently loaned tools
        private Tool[] loaned = new Tool[0];
        //selected tool type in menus
        private ToolCollection tls;

        // INTERFACE FUNCTIONS --------------------------------------------------------------------------------------------------
        //add new tool
        public void Add(Tool aTool) { tls.Add(aTool); }

        //add pieces of existing tool
        public void Add(Tool aTool, int quantity) { aTool.Quantity += quantity; }

        //delete tool
        public void Delete(Tool aTool) { tls.Delete(aTool); }

        //delete pieces of existing tool
        public void Delete(Tool aTool, int quantity)
        {
            if ((aTool.Quantity - quantity) <= 0) Delete(aTool);
            else aTool.Quantity -= quantity;
        }

        //add member
        public void Add(Member aMember) { mem.Add(aMember); }

        //delete member
        public void Delete(Member aMember) { mem.Delete(aMember); }

        //displays tools on hold by member
        public void DisplayBorrowingTools(Member aMember)
        {
            string[] tmp = ListTools(aMember);
            Header(); Console.WriteLine(" ==========Loaning==========");
            if (tmp.Length == 0) Console.Write("\n No tools currently loaned.");
            else
            {
                Console.WriteLine($"  Tools loaned by {crntMem.FirstName} {crntMem.LastName}:");
                for (int i = 0; i < tmp.Length; ++i) Console.WriteLine($"    {i + 1}. {tmp[i]}");
                Console.Write(" ===========================\n\n");
            }
            Continue();
        }

        //displays tool types on hold by member
        public void DisplayTools(string aToolType) { Console.WriteLine(aToolType); }

        //add hold to member
        public void BorrowTool(Member aMember, Tool aTool)
        {
            --aTool.AvailableQuantity;
            aMember.AddTool(aTool);
            aTool.AddBorrower(aMember);

            //updates loaned tools
            Tool[] tmp = new Tool[loaned.Length + 1];
            for (int i = 0; i < loaned.Length; ++i) tmp[i] = loaned[i];
            tmp[tmp.Length - 1] = aTool;
            loaned = tmp;
        }

        //delete hold from member
        public void ReturnTool(Member aMember, Tool aTool)
        {
            ++aTool.AvailableQuantity;
            aMember.DeleteTool(aTool);
            aTool.DeleteBorrower(aMember);
        }

        //get list of tools on hold by member
        public string[] ListTools(Member aMember)
        {
            string[] tmp = new string[aMember.Tools.Length];
            for (int i = 0; i < tmp.Length; ++i) tmp[i] = aMember.Tools[i].Name;
            return tmp;
        }

        //display top 3 most frequently borrowed tools (descending order)
        public void DisplayTopThree()
        {
            Header(); Console.WriteLine(" ============Top 3==========");
            if (loaned.Length > 0)
            {
                //sorts in descending order by times borrowed
                for (int i = 1; i <= loaned.Length - 1; i++)
                {
                    Tool tmp = loaned[i]; int cnt = i - 1;
                    while (cnt >= 0 && loaned[cnt].NoBorrowings.CompareTo(tmp.NoBorrowings) == -1)
                    {
                        loaned[cnt + 1] = loaned[cnt];
                        cnt = cnt - 1;
                    }
                    loaned[cnt + 1] = tmp;
                }

                //filters duplicates and assigns top 3
                Tool[] top3 = new Tool[3];
                for (int i = 0; i < top3.Length; ++i)
                    for (int b = 0; b < loaned.Length; ++b)
                    {
                        if (i == 0) { top3[i] = loaned[b]; break; }
                        if (i == 1 && top3[i] == null && top3[0] != null && !top3[0].Name.Equals(loaned[b].Name)) { top3[i] = loaned[b]; break; }
                        if (i == 2 && top3[i] == null && top3[0] != null && top3[1] != null && !top3[1].Name.Equals(loaned[b].Name) && !top3[0].Name.Equals(loaned[b].Name)) { top3[i] = loaned[b]; break; }
                    }

                //writes to console
                for (int i = 0; i < top3.Length; ++i)
                {
                    if (top3[i] != null) Console.WriteLine($"  {i + 1}. Name: {top3[i].Name} | Borrowed: {top3[i].NoBorrowings}");
                    else Console.WriteLine($"  {i + 1}. Name: ~ | Borrowed: ~");
                }
                Console.Write(" ===========================\n\n");
            }
            else Console.Write("\n No borrow history.");
            Continue();
        }

        // MAIN -----------------------------------------------------------------------------------------------------------------
        //navigation between member and staff menus
        private void MainMenu()
        {
            while (true)
            {
                Header();
                Console.Write(" ==========Main Menu========\n" +
                              "  1. Staff Login\n" +
                              "  2. Member Login\n" +
                              "  0. Exit\n" +
                              " ===========================\n\n" +
                              " Please make a selection (1-2, or 0 to exit): ");

                if (int.TryParse(Console.ReadLine(), out int sel))
                {
                    switch (sel)
                    {
                        case 1: StaffLogin(); break;
                        case 2: MemberLogin(); break;
                        case 0:
                            Header(); Console.Write(" ===========Exit============\n  Are you sure?\n");
                            if (Review()) Environment.Exit(0); break;
                        default: ErrMsg("Invalid selection. Please choose 1-2 or 0."); break;
                    }
                }
            }
        }

        // STAFF ----------------------------------------------------------------------------------------------------------------
        //prompts user for staff credentials ("staff"/"today123")
        private void StaffLogin()
        {
            Header();
            Console.WriteLine(" ========Staff Login========");
            Console.Write("  Username: "); string usr = Console.ReadLine();
            Console.Write("  Password: "); string psk = Console.ReadLine();
            if (usr == "staff" && psk == "today123") StaffMenu();
            else ErrMsg("Invalid username and/or password.");
        }

        //navigation of staff interactions
        private void StaffMenu()
        {
            Header();
            Console.Write(" =========Staff Menu========\n" +
                "  1. Add a new tool\n" +
                "  2. Add new pieces of an existing tool\n" +
                "  3. Remove some pieces of a tool\n" +
                "  4. Register a new member\n" +
                "  5. Remove a member\n" +
                "  6. Find the contact number of a member\n" +
                "  0. Return to main menu\n" +
                " ===========================\n\n" +
                " Please make a selection (1-6, or 0 to return to main menu): ");

            if (int.TryParse(Console.ReadLine(), out int sel))
            {
                switch (sel)
                {
                    case 1: AddTool(); StaffMenu(); break;
                    case 2: AddPiece(); StaffMenu(); break;
                    case 3: RemovePiece(); StaffMenu(); break;
                    case 4: AddMember(); StaffMenu(); break;
                    case 5: RemoveMember(); StaffMenu(); break;
                    case 6: Contact(); StaffMenu(); break;
                    case 0: MainMenu(); break;
                    default: ErrMsg("Invalid selection. Please choose 1-6 or 0."); break;
                }
            }
            StaffMenu();
        }

        //adds tool to inventory
        private void AddTool()
        {
            if (Library(1))
            {
                Tool tmp = new Tool();
                try
                {
                    Header(); Console.WriteLine(" ==========Add Tool=========");
                    Console.Write("  Tool Name/Description: "); tmp.Name = Console.ReadLine().Trim();
                    Console.Write("               Quantity: "); tmp.Quantity = Convert.ToInt16(Console.ReadLine());
                    if (Review()) Add(tmp);
                }
                catch (Exception e) { ErrMsg(e.Message); StaffMenu(); }
            }
        }

        //adds quantity of tool to inventory
        private void AddPiece()
        {
            if (Library(1))
            {
                Tool[] tmp = tls.ToArray();
                if (Inventory(tmp))
                {
                    try
                    {
                        Console.WriteLine(" ==========Add Piece========");
                        Console.Write("     Selection: "); int inpt = Convert.ToInt16(Console.ReadLine());
                        Console.Write("  Add Quantity: "); int amnt = Convert.ToInt16(Console.ReadLine());
                        Tool sel = tmp[inpt - 1];
                        if (Review()) Add(sel, amnt);
                    }
                    catch (Exception e) { ErrMsg(e.Message); }
                }
                else Continue();
            }
        }

        //removes quantity of tool to inventory (if 0, removes tool)
        private void RemovePiece()
        {
            if (Library(1))
            {
                Tool[] tmp = tls.ToArray();
                if (Inventory(tmp))
                {
                    try
                    {
                        Console.WriteLine(" ========Remove Piece=======");
                        Console.Write("        Selection: "); int inpt = Convert.ToInt16(Console.ReadLine());
                        Console.Write("  Remove Quantity: "); int amnt = Convert.ToInt16(Console.ReadLine());
                        Tool sel = tmp[inpt - 1];
                        if ((sel.Quantity - amnt) >= 0) { if (Review()) Delete(sel, amnt); }
                        else ErrMsg("Cannot remove more than available.");
                    }
                    catch (Exception e) { ErrMsg(e.Message); }
                }
                else Continue();
            }
        }

        //adds member to system with given information
        private void AddMember()
        {
            Member tmp = new Member();
            Header(); Console.WriteLine(" =========Add Member========");
            Console.Write("  Firstname: "); tmp.FirstName = Console.ReadLine();
            Console.Write("   Lastname: "); tmp.LastName = Console.ReadLine();
            Console.Write("    Contact: "); tmp.ContactNumber = Console.ReadLine();
            Console.Write("   Password: "); tmp.PIN = Console.ReadLine();
            
            //prevents duplicate member
            Member[] exists = mem.ToArray();
            for (int i = 0; i < exists.Length; ++i)
                if (exists[i].FirstName == tmp.FirstName && exists[i].LastName == tmp.LastName) { ErrMsg("A member with that name already exists."); StaffMenu(); }
            if (Review()) Add(tmp);
        }

        //removes member from system
        private void RemoveMember()
        {
            Member[] tmp = mem.ToArray();
            Header(); Console.WriteLine(" ===========Members=========");
            if (tmp.Length == 0) { Console.Write("\n No members to display."); Continue(); }
            else
            {
                for (int i = 0; i < tmp.Length; ++i) Console.WriteLine($"  {i + 1}. {tmp[i].FirstName} {tmp[i].LastName}");
                Console.Write(" ===========================\n\n");
                try
                {
                    Console.WriteLine(" ========Remove Member======");
                    Console.Write("  Select Member: "); int inpt = Convert.ToInt16(Console.ReadLine());
                    Member sel = tmp[inpt - 1];
                    if (Review()) Delete(sel);
                }
                catch (Exception e) { ErrMsg(e.Message); }
            }
        }

        //retrieves contact for member upon name search
        private void Contact()
        {
            Member[] tmp = mem.ToArray();
            Header(); Console.WriteLine(" ===========Contact=========");
            if (tmp.Length == 0) { Console.Write("\n No members to display."); }
            else
            {
                Console.Write("  Firstname: "); string fst = Console.ReadLine();
                Console.Write("   Lastname: "); string lst = Console.ReadLine();
                Console.Write(" ===========================\n\n");
                for (int i = 0; i < tmp.Length; ++i)
                    if (tmp[i].FirstName == fst && tmp[i].LastName == lst) Console.Write($"  {fst} {lst}'s contact is {tmp[i].ContactNumber}.");
                    else { Console.Write("  No member found by that name."); break; }

            }
            Continue();
        }

        // MEMBER ---------------------------------------------------------------------------------------------------------------
        //prompts user for individual credentials ("firstname"/"lastname"/"password")
        private void MemberLogin()
        {
            Header(); Console.WriteLine(" ========Member Login=======");
            Console.Write("  Firstname: "); string fst = Console.ReadLine();
            Console.Write("   Lastname: "); string lst = Console.ReadLine();
            Console.Write("   Password: "); string psk = Console.ReadLine();

            Member[] tmp = mem.ToArray();
            for (int i = 0; i < tmp.Length; ++i)
                if (tmp[i].FirstName == fst && tmp[i].LastName == lst && tmp[i].PIN == psk) crntMem = tmp[i];
            if (crntMem != null) MemberMenu();
            else ErrMsg("Invalid firstname and/or lastname and/or password.");
        }

        //navigation of member interactions
        private void MemberMenu()
        {
            Header();
            Console.Write(" ========Member Menu========\n" +
                "  1. Display all the tools of a tool type\n" +
                "  2. Borrow a tool\n" +
                "  3. Return a tool\n" +
                "  4. List all the tools that I am renting\n" +
                "  5. Display top three (3) most frequentely rented tools\n" +
                "  0. Return to main menu\n" +
                " ===========================\n\n" +
                " Please make a selection (1-5, or 0 to return to main menu): ");

            if (int.TryParse(Console.ReadLine(), out int sel))
            {
                switch (sel)
                {
                    case 1: Display(); MemberMenu(); break;
                    case 2: Borrow(); MemberMenu(); break;
                    case 3: Return(); MemberMenu(); break;
                    case 4: DisplayBorrowingTools(crntMem); MemberMenu(); break;
                    case 5: DisplayTopThree(); MemberMenu(); break;
                    case 0: crntMem = null; MainMenu(); break;
                    default: ErrMsg("Invalid selection. Please choose 1-5 or 0."); break;
                }
            }
            MemberMenu();
        }

        //displays inventory of tool type
        private void Display()
        {
            try { Library(2); Inventory(tls.ToArray()); Continue(); }
            catch (Exception e) { ErrMsg(e.Message); }
        }

        //associates tool with member (max 3)
        private void Borrow()
        {
            if (crntMem.Tools.Length < 3)
            {
                if (Library(2))
                {
                    Tool[] tmp = tls.ToArray();
                    if (Inventory(tmp))
                    {
                        try
                        {
                            Console.WriteLine(" ========Borrow Tool========");
                            Console.Write("  Selection: "); int inpt = Convert.ToInt16(Console.ReadLine());
                            Tool sel = tmp[inpt - 1];
                            if (sel.AvailableQuantity <= 0) ErrMsg("None available to borrow.");
                            else { if (Review()) { BorrowTool(crntMem, sel); ++sel.NoBorrowings; } }
                        }
                        catch (Exception e) { ErrMsg(e.Message); }
                    }
                    else Continue();
                }
            }
            else { ErrMsg("You have surpassed your loan limit. Please return a tool before borrowing again."); }
        }

        //removes tool from member
        private void Return()
        {
            try
            {
                Tool[] tmp = crntMem.Tools;
                Header(); Console.WriteLine(" ==========Loaning==========");
                if (tmp.Length > 0)
                {
                    Console.WriteLine($"  Tools loaned by {crntMem.FirstName} {crntMem.LastName}:");
                    for (int i = 0; i < tmp.Length; ++i) Console.WriteLine($"    {i + 1}. {tmp[i].Name}");
                    Console.WriteLine(" ===========================\n\n ========Return Tool========");
                    Console.Write("  Selection: "); int inpt = Convert.ToInt16(Console.ReadLine());
                    Tool sel = tmp[inpt - 1];
                    if (Review()) ReturnTool(crntMem, sel);
                }
                else { Console.Write("\n No tools currently loaned."); Continue(); }
            }
            catch (Exception e) { ErrMsg(e.Message); }
        }

        // MISC -----------------------------------------------------------------------------------------------------------------
        //clears console and writes generic header
        private void Header() { Console.Clear(); Console.WriteLine(" Welcome to the Tool Library"); }

        //allows users to confirm interaction
        private bool Review()
        {
            Console.Write(" ===========================\n\n" +
                          " Press Y to confirm or any other key to cancel: ");
            string inpt = Console.ReadLine().ToLower();
            if (inpt == "y") { Console.Write("\n Successful."); Continue(); return true; }
            else { Console.Write("\n Cancelled."); Continue(); return false; }
        }

        //waits for any key to continue
        private static void Continue() { Console.WriteLine(" Press any key to continue."); Console.ReadKey(); }

        //sounds beep and prints string upon error
        private static void ErrMsg(string msg)
        {
            Console.Clear(); Console.Beep();
            Console.Write(" An error occured whilst processing your request...\n\n");
            Console.ForegroundColor = ConsoleColor.Red; Console.Write($" {msg}\n\n"); Console.ResetColor();
            Continue();
        }

        //writes respective inventory to console
        private bool Inventory(Tool[] tools)
        {
            Header(); Console.WriteLine(" ==========Inventory========");
            if (tools.Length == 0) { Console.Write("\n No tools to display."); return false; }
            else
            {
                for (int i = 0; i < tools.Length; ++i) { Console.Write($"  {i + 1}. "); DisplayTools(tools[i].ToString()); }
                Console.Write(" ===========================\n\n"); return true;
            }
        }

        //navigation of category/type and sets selected tool type
        private bool Library(int prevMenu = 0) //1:staff, 2:member
        {
            ToolCollection cat = null;
            Header();
            Console.Write(" ====== Tool Category ======\n" +
                    "  1. Gardening Tools\n" +
                    "  2. Flooring Tools\n" +
                    "  3. Fencing Tools\n" +
                    "  4. Measuring Tools\n" +
                    "  5. Cleaning Tools\n" +
                    "  6. Painting Tools\n" +
                    "  7. Electronic Tools\n" +
                    "  8. Elecricity Tools\n" +
                    "  9. Automotive Tools\n" +
                    "  0. Previous Menu\n" +
                    " ===========================\n\n" +
                    " Please make a selection (1-9, or 0 to previous menu): ");

            //user input validation
            static bool HandleInpt(int inpt, int min, int max)
            {
                if ((min <= inpt && inpt <= max) | inpt == 0) return true;
                else ErrMsg($"Invalid selection. Please choose {min}-{max} or 0."); return false;
            }

            //tool types
            if (int.TryParse(Console.ReadLine(), out int sel))
            {
                Header();
                switch (sel)
                {
                    case 0:
                        if (prevMenu == 1) StaffMenu(); if (prevMenu == 2) MemberMenu(); break;
                    case 1:
                        Console.Write(" === Gardening Tool Type ===\n" +
                                      "  1. Line Trimmers\n" +
                                      "  2. Lawn Mowers\n" +
                                      "  3. Hand Tools\n" +
                                      "  4. Wheelbarrows\n" +
                                      "  5. Garden Power Tools\n" +
                                      "  0. Change Category\n" +
                                      " ===========================\n\n" +
                                      " Please make a selection (1-5, or 0 to change category): ");
                        try { int inpt = Convert.ToInt16(Console.ReadLine()); if (inpt == 0) Library(); if (HandleInpt(inpt, 1, 5)) Gardening.TryGetValue(inpt, out cat); }
                        catch (Exception e) { ErrMsg(e.Message); }
                        break;
                    case 2:
                        Console.Write(" ==== Flooring Tool Type ===\n" +
                                      "  1. Scrapers\n" +
                                      "  2. Floor Lasers\n" +
                                      "  3. Floor Levelling Tools\n" +
                                      "  4. Floor Levelling Materials\n" +
                                      "  5. Floor Hand Tools\n" +
                                      "  6. Tiling Tools\n" +
                                      "  0. Change Category\n" +
                                      " ===========================\n\n" +
                                      " Please make a selection (1-6, or 0 to change category): ");
                        try { int inpt = Convert.ToInt16(Console.ReadLine()); if (inpt == 0) Library(); if (HandleInpt(inpt, 1, 6)) Flooring.TryGetValue(inpt, out cat); }
                        catch (Exception e) { ErrMsg(e.Message); }
                        break;
                    case 3:
                        Console.Write(" ==== Fencing Tool Type ====\n" +
                                      "  1. Hand Tools\n" +
                                      "  2. Electric Fencing\n" +
                                      "  3. Steel Fencing Tools\n" +
                                      "  4. Power Tools\n" +
                                      "  5. Fencing Accessories\n" +
                                      "  0. Change Category\n" +
                                      " ===========================\n\n" +
                                      " Please make a selection (1-5, or 0 to change category): ");
                        try { int inpt = Convert.ToInt16(Console.ReadLine()); if (inpt == 0) Library(); if (HandleInpt(inpt, 1, 5)) Fencing.TryGetValue(inpt, out cat); }
                        catch (Exception e) { ErrMsg(e.Message); }
                        break;
                    case 4:
                        Console.Write(" === Measuring Tool Type ===\n" +
                                      "  1. Distance Tools\n" +
                                      "  2. Laser Measurer\n" +
                                      "  3. Measuring Jugs\n" +
                                      "  4. Temperature & Humidity Tools\n" +
                                      "  5. Levelling Tools\n" +
                                      "  6. Markers\n" +
                                      "  0. Change Category\n" +
                                      " ===========================\n\n" +
                                      " Please make a selection (1-6, or 0 to change category): ");
                        try { int inpt = Convert.ToInt16(Console.ReadLine()); if (inpt == 0) Library(); if (HandleInpt(inpt, 1, 6)) Measuring.TryGetValue(inpt, out cat); }
                        catch (Exception e) { ErrMsg(e.Message); }
                        break;
                    case 5:
                        Console.Write(" ==== Cleaning Tool Type ===\n" +
                                      "  1. Draining\n" +
                                      "  2. Car Cleaning\n" +
                                      "  3. Vacuum\n" +
                                      "  4. Pressure Cleaners\n" +
                                      "  5. Pool Cleaning\n" +
                                      "  6. Floor Cleaning\n" +
                                      "  0. Change Category\n" +
                                      " ===========================\n\n" +
                                      " Please make a selection (1-6, or 0 to change category): ");
                        try { int inpt = Convert.ToInt16(Console.ReadLine()); if (inpt == 0) Library(); if (HandleInpt(inpt, 1, 6)) Cleaning.TryGetValue(inpt, out cat); }
                        catch (Exception e) { ErrMsg(e.Message); }
                        break;
                    case 6:
                        Console.Write(" ==== Painting Tool Type ===\n" +
                                      "  1. Sanding Tools\n" +
                                      "  2. Brushes\n" +
                                      "  3. Rollers\n" +
                                      "  4. Paint Removal Tools\n" +
                                      "  5. Paint Scrapers\n" +
                                      "  6. Sprayers\n" +
                                      "  0. Change Category\n" +
                                      " ===========================\n\n" +
                                      " Please make a selection (1-6, or 0 to change category): ");
                        try { int inpt = Convert.ToInt16(Console.ReadLine()); if (inpt == 0) Library(); if (HandleInpt(inpt, 1, 6)) Painting.TryGetValue(inpt, out cat); }
                        catch (Exception e) { ErrMsg(e.Message); }
                        break;
                    case 7:
                        Console.Write(" === Electronic Tool Type ==\n" +
                                      "  1. Voltage Tester\n" +
                                      "  2. Oscilloscopes\n" +
                                      "  3. Thermal Imaging\n" +
                                      "  4. Data Test Tool\n" +
                                      "  5. Insulation Testers\n" +
                                      "  0. Change Category\n" +
                                      " ===========================\n\n" +
                                      " Please make a selection (1-5, or 0 to change category): ");
                        try { int inpt = Convert.ToInt16(Console.ReadLine()); if (inpt == 0) Library(); if (HandleInpt(inpt, 1, 5)) Electronic.TryGetValue(inpt, out cat); }
                        catch (Exception e) { ErrMsg(e.Message); }
                        break;
                    case 8:
                        Console.Write(" == Electricity Tool Type ==\n" +
                                      "  1. Test Equipment\n" +
                                      "  2. Safety Equipment\n" +
                                      "  3. Basic Equipment\n" +
                                      "  4. Circuit Protection\n" +
                                      "  5. Cable Tools\n" +
                                      "  0. Change Category\n" +
                                      " ===========================\n\n" +
                                      " Please make a selection (1-5, or 0 to change category): ");
                        try { int inpt = Convert.ToInt16(Console.ReadLine()); if (inpt == 0) Library(); if (HandleInpt(inpt, 1, 5)) Electricity.TryGetValue(inpt, out cat); }
                        catch (Exception e) { ErrMsg(e.Message); }
                        break;
                    case 9:
                        Console.Write(" === Automotive Tool Type ==\n" +
                                      "  1. Jacks\n" +
                                      "  2. Air Compressors\n" +
                                      "  3. Battery Chargers\n" +
                                      "  4. Socket Tools\n" +
                                      "  5. Braking\n" +
                                      "  6. Drivetrain\n" +
                                      "  0. Change Category\n" +
                                      " ===========================\n\n" +
                                      " Please make a selection (1-6, or 0 to change category): ");
                        try { int inpt = Convert.ToInt16(Console.ReadLine()); if (inpt == 0) Library(); if (HandleInpt(inpt, 1, 5)) Automotive.TryGetValue(inpt, out cat); }
                        catch (Exception e) { ErrMsg(e.Message); }
                        break;
                    default: ErrMsg("Invalid selection. Please choose 1-9, or 0 to previous menu."); break;
                }
            }
            if (cat != null) { tls = cat; return true; }
            else return false;
        }
    }
}
