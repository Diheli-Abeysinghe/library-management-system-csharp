using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CB015673___SD_Assignment_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Assumptions: This system has been designed for the use of OakTown library staff, NOT members. Therefore all operations and functions of 
            //this system have been designed considering what OakTown library staff (mainly the librarian) would need to do.
            Library lib = new Library();
            lib.AddDefaultMember(); //instantiate default member
            lib.SeedDefaultBooks();

           
            

            while (true)
            {
                Console.WriteLine("| OAKTOWN LIBRARY SYSTEM |");
                Console.WriteLine("Welcome to OakTown Library!");
                Console.WriteLine("---------------------------");
                Console.WriteLine("1. LIBRARY MANAGEMENT");
                Console.WriteLine("2. MEMBER MANAGEMENT");
                Console.WriteLine("3. BORROWING AND RETURNS");
                Console.WriteLine("4. EXIT SYSTEM");
                Console.WriteLine();
                Console.WriteLine("What would you like to do today? (1-4):");
                string userinput = Console.ReadLine();
                switch (userinput)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("LIBRARY ITEM MANAGEMENT");
                        Console.WriteLine("1. View all items");
                        Console.WriteLine("2. Add new item");
                        Console.WriteLine("3. Search available items by keyword");
                        Console.WriteLine();
                        Console.WriteLine("Enter your choice (1-3): ");
                        string input = Console.ReadLine();
                        if (input == "1")
                        {
                            Console.Clear();
                            lib.ViewItems();

                        }
                        if (input == "2")
                        {
                            Console.Clear();
                            lib.AddItem();
                        }

                        if (input == "3")
                        {  
                            Console.Clear();
                            lib.SearchItems();
                        }
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("MEMBER MANAGEMENT");
                        Console.WriteLine("1. Add (adult) member");
                        Console.WriteLine("2. Add (child) member");
                        Console.WriteLine("3. View members");
                        Console.WriteLine("4.Find member by ID");
                        Console.WriteLine();
                        string choice = Console.ReadLine();
                        if (choice == "1")
                        {
                            Console.Clear();
                            lib.AddMember();
                        }
                        if (choice == "2")
                        {
                            Console.Clear();
                            lib.AddChildMember();
                        }
                        if (choice == "3")
                        {
                            Console.Clear();
                            lib.ViewMember();
                        }
                        if(choice == "4")
                        {
                            Console.Clear();
                            lib.FindMember();
                        }
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("BORROWING AND RETURNS");
                        Console.WriteLine("1. Borrow an item");
                        Console.WriteLine("2. Return an item");
                        Console.WriteLine("3. Calculate Burrowing Cost");
                        Console.WriteLine("4. List a member's currently borrowed items");
                        Console.WriteLine("5. List a member's previously borrowed items");
                        Console.WriteLine("6. Check overdue items");
                        Console.WriteLine();
                        string decision = Console.ReadLine();
                        if (decision == "1")
                        {
                            Console.Clear();
                            Console.WriteLine("------AVAILABLE ITEMS--------");
                            lib.ViewItems();
                            Member borrowingmember = SelectMember(lib);
                            if (borrowingmember != null)
                                lib.BorrowItem(borrowingmember);
                            
                        }
                        if (decision == "2")
                        {
                            Console.Clear();
                            Member returningmember = SelectMember(lib);
                            if (returningmember != null)
                                lib.ReturnItem(returningmember);
                        }
                        if (decision == "3")
                        {
                            Console.Clear();
                            Member borrowcostmember = SelectMember(lib);
                            if (borrowcostmember != null)
                            {
                                if (borrowcostmember.currentlyBorrowed.Count == 0)
                                {
                                    Console.WriteLine("No currently borrowed items to calculate cost.");
                                    break;
                                }
                                Console.WriteLine("Currently borrowed items:");
                                foreach (var b in borrowcostmember.currentlyBorrowed)
                                {
                                    Console.WriteLine("----------------------------------");
                                    Console.WriteLine("{0,-10} {1,-30}", "Item ID", "Title");
                                    Console.WriteLine("----------------------------------");
                                    Console.WriteLine("{0,-10} {1,-30}", b.Item.itemId, b.Item.title);
                                }
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine("------------------------");
                                Console.WriteLine("{0,-10} {1,10}", "Item", "Daily Cost");
                                Console.WriteLine("------------------------");
                                Console.WriteLine("{0,-10} {1,10}", "Book", "1 USD");
                                Console.WriteLine("{0,-10} {1,10}", "Magazine", "0.50 USD");
                                Console.WriteLine("------------------------");

                                Console.WriteLine("Enter Item ID to calculate borrowing cost:");
                                string itemID = Console.ReadLine();

                                var borrowedItem = borrowcostmember.currentlyBorrowed.FirstOrDefault(x => x.Item.itemId == itemID);
                                if (borrowedItem != null)
                                {
                                    double cost = lib.CalculateBorrowCost(borrowcostmember, borrowedItem.Item.isbn);
                                    Console.WriteLine($"Borrowing cost: {cost} USD");
                                }
                                else
                                {
                                    Console.WriteLine("Item not found.");
                                }
                            }
                        }
                        if (decision == "4")
                        {
                            Console.Clear();
                            Member currentlyborrowedmember = SelectMember(lib);
                            currentlyborrowedmember?.ViewCurrentlyBorrowed();
                        }
                        if (decision == "5")
                        {
                            Console.Clear();
                            Member borrowhistorymember = SelectMember(lib);
                            borrowhistorymember?.ViewBorrowHistory();
                        }
                        if(decision == "6")
                        {
                            Console.Clear();
                            Member member = SelectMember(lib);
                            member.ViewOverdueItems();
                        }
                        break;
                    case "4":
                        Console.WriteLine("Enter '-1' to confirm exit");
                        string choice2 = Console.ReadLine();
                        if (choice2 == "-1")
                        {
                            Console.Clear();
                            Console.WriteLine("Thank you for using OakTown Library! Goodbye!");
                            Environment.Exit(0);

                        }
                        else
                        {
                            Console.WriteLine("Invalid input.");
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again!");
                        break;
                }

            }
            
        }

        



        public static Member SelectMember(Library lib)
        {
            Console.Write("Enter Member ID: ");
            string memberId = Console.ReadLine();
            Member member = lib.GetMemberById(memberId);
            if (member == null)
            {
                Console.WriteLine("Member not found!");
            }
            return member;
        }


    

    


    }
}
        
 

