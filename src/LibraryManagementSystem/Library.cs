using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CB015673___SD_Assignment_1
{
    public class Library
    {
        List<Member> Members = new List<Member>();
        List<ChildMember> ChildMembers = new List<ChildMember>();
        List<LibraryItem> Items = new List<LibraryItem>();

        private static int membercounter = 124;

        //add pre-existing books to system
        public void SeedDefaultBooks()
        {
            if (Items.Count == 0) // only seed once
            {
                Items.Add(new Book { itemId = "0001", isbn = "101", title = "1984", author = "George Orwell", publishedYear = 1949 });
                Items.Add(new Book { itemId = "0002", isbn = "102", title = "To Kill a Mockingbird", author = "Harper Lee", publishedYear = 1960 });
                Items.Add(new Book { itemId = "0003", isbn = "103", title = "The Great Gatsby", author = "F. Scott Fitzgerald", publishedYear = 1925 });
                Items.Add(new Book { itemId = "0004", isbn = "104", title = "Moby Dick", author = "Herman Melville", publishedYear = 1851 });
                Items.Add(new Book { itemId = "0005", isbn = "105", title = "Pride and Prejudice", author = "Jane Austen", publishedYear = 1813 });
            }
        }


        public class UnderageMember : Exception
        {
            public UnderageMember()
                      : base("Sorry, but you must be over 12 to have a membership! Apply for a child membership instead!")
            {
            }

            public UnderageMember(string message)
                      : base(message)
            {
            }

            public UnderageMember(string message, Exception innerException)
                      : base(message, innerException)

            {
            }

        }



        public void AddMember() //Assumptions: A person under the age of 12 requires a child-member account linked to their guardian's account
        {
            try
            {
                Member member = new Member();
                Console.WriteLine("Enter your first name");
                member.fName = Console.ReadLine();
                Console.WriteLine("Enter your last name");
                member.lName = Console.ReadLine();
                Console.WriteLine("Enter your age");
                try { 
                    member.age = Convert.ToInt32(Console.ReadLine());
                }
                catch(FormatException)
                {
                    Console.WriteLine("Invalid age format. Please enter a number.");
                    return;
                }
                catch(OverflowException)
                {
                    Console.WriteLine("The number is too long to be a valid age. Please try again.");
                    return;
                }
                if (member.age < 12)
                {
                    throw new UnderageMember();
                }
                Console.WriteLine("Enter your address");
                member.address = Console.ReadLine();
                Console.WriteLine("Enter your phone number");
                member.phoneNumber = Console.ReadLine();

                //auto generate memberId
                member.memberId = "M" + membercounter.ToString("D3");
                membercounter++;

                //add new member to list Members
                Members.Add(member);

                //display message to the user 
                Console.WriteLine($"Member has been created with MemberID: {member.memberId}");
                Console.WriteLine();
            }
            catch (UnderageMember ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Would you like to apply for a child membership instead? (yes/no):");
                string input = Console.ReadLine();
                if(input.ToLower() == "yes")
                {
                    AddChildMember();
                }
            
            }
                
        }

        public void AddChildMember()
        {
            ChildMember member = new ChildMember();
            Console.WriteLine("Enter your first name");
            member.fName = Console.ReadLine();
            Console.WriteLine("Enter your last name");
            member.lName = Console.ReadLine();
            Console.WriteLine("Enter your age");
            try
            {
                member.age = Convert.ToInt32(Console.ReadLine());

            }
            catch(FormatException)
            {
                Console.WriteLine("Invalid input for age. Please enter a number.");
                return;

            }
            
            Console.WriteLine("Enter your address");
            member.address = Console.ReadLine();
            Console.WriteLine("Enter your guardian's member ID:");
             member.guardianID = Console.ReadLine();
            if(!Members.Any(m => m.memberId == member.guardianID))
            {
                Console.WriteLine("Guardian member could not be found!");
                return;
            }

            //auto generate memberId
            member.memberId = "M" + membercounter.ToString("D3");
            membercounter++;

            //add new member to list Members
            ChildMembers.Add(member);

            //display message to the user 
            Console.WriteLine($"Member has been created with MemberID: {member.memberId}");
            Console.WriteLine();


        }

        public  void ViewMember()
        {

            Console.WriteLine("Would you like to view \n1. Adult members OR \n2. Child members? (1-2):"); 
            string input = Console.ReadLine() ;
            if (input == "1")
            {
                if (Members.Count == 0)
                {
                    Console.WriteLine("No members exist! Create members first.");
                    return;

                }

                Console.WriteLine("List of Members:");
                foreach (Member member in Members)
                {
                    Console.WriteLine($"MemberID: {member.memberId}\nMember Name: {member.fName + " " + member.lName}\nAge:{member.age}\nAddress: {member.address}\nContact Number: {member.phoneNumber}");
                    Console.WriteLine();
                }

            }
            else
            {
                if(ChildMembers.Count == 0)
                {
                    Console.WriteLine("No members exist! Create members first.");
                    return;

                }
                Console.WriteLine("List of Members:");
                foreach (ChildMember member in ChildMembers)
                {
                    Console.WriteLine($"MemberID: {member.memberId}\nMember Name: {member.fName + " " + member.lName}\nAge:{member.age}\nGuardian's Member ID:{member.guardianID}\nAddress: {member.address}\nContact Number: {member.phoneNumber}");
                    Console.WriteLine();
                }
            }
            

        }

        public void FindMember()
        {
            
            Console.WriteLine("Enter the MemberID:");
            string userInput = Console.ReadLine();

            // check if userInput matches an ID
            Member foundMember = Members.FirstOrDefault(m => m.memberId.ToLower() == userInput.ToLower());
            if (foundMember != null)
            {
                Console.WriteLine("Member found!");
                Console.WriteLine("Member details:");
                Console.WriteLine($"MemberID: {foundMember.memberId}\nMember Name:{foundMember.fName + " " + foundMember.lName}\nAge:{foundMember.age}\nAddress:{foundMember.address}\nContact Number: {foundMember.phoneNumber} ");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No such member exists. Try again!");
                Console.WriteLine();
            }
            
        }

        private static int itemCounter = 6;
        public void AddItem() 
        {
            LibraryItem item;
            Console.WriteLine("Enter your choice (1-3): ");
            Console.WriteLine("1. Create a Book item");
            Console.WriteLine("2. Create a Reference Book item");
            Console.WriteLine("3. Create a Magazine item");
            string choice = Console.ReadLine();
            
            if (choice == "1")
            {
                Book book = new Book();
                Console.WriteLine("Enter the item's title:");
                book.title = Console.ReadLine();
                Console.WriteLine("Enter the item's ISBN:");
                book.isbn = Console.ReadLine();
                Console.WriteLine("Enter the name of the author of the work:");
                book.author = Console.ReadLine();
                Console.WriteLine("Enter the year in which the item was published:");
                try
                {
                    book.publishedYear = Convert.ToInt32(Console.ReadLine());

                }
                catch(FormatException)
                {
                    Console.WriteLine("Invalid input for year. Please try again.");
                    return;

                }

                Console.WriteLine("Enter the number of pages in the work:");
                try
                {
                    book.pageCount = Convert.ToInt32(Console.ReadLine());

                }
                catch
                {
                    Console.WriteLine("Invalid page count. Please try again.");
                    return;
                }
                 
                item = book;
                //auto generate item ID
                item.itemId = itemCounter.ToString("D4");
                itemCounter++;
                
                Items.Add(item);
                Console.WriteLine($"Item successfully added with ID: {item.itemId}!");
                Console.WriteLine();
            }

            else if(choice == "2")
            {
                ReferenceBook refbook= new ReferenceBook();
                Console.WriteLine("Enter the item's title:");
                refbook.title = Console.ReadLine();
                Console.WriteLine("Enter the item's ISBN:");
                refbook.isbn = Console.ReadLine();
                //Console.WriteLine("Enter the number of pages in the work:");
                //refbook.pagecount = Convert.ToInt32(Console.ReadLine());
                item = refbook;
                //auto generate item ID
                item.itemId = itemCounter.ToString("D4");
                itemCounter++;
                Items.Add(item);
                Console.WriteLine($"Item successfully added with ID: {item.itemId}!");
                Console.WriteLine();

            }

            else if (choice == "3")
            {
                Magazine magazine = new Magazine();
                Console.WriteLine("Enter the title of the work:");
                magazine.title = Console.ReadLine();
                Console.WriteLine("Enter the item's ISBN:");
                magazine.isbn = Console.ReadLine();
                Console.WriteLine("Enter the issue number:");
                try
                {
                    magazine.issueNumber = Convert.ToInt32(Console.ReadLine());

                }
                catch
                {
                    Console.WriteLine("Invalid issue number. Please try again.");
                    return;
                }
                
                Console.WriteLine("Enter the date the work was published (DD MM YYYY):");
                try
                {
                    magazine.publishedDate = DateTime.ParseExact(Console.ReadLine(), "dd MM yyyy", null);


                }
                catch
                {
                    Console.WriteLine("Invalid date. Please try again.");
                }
                
                //Console.WriteLine("Enter the number of pages in the work:");
                //magazine.pagecount = Convert.ToInt32(Console.ReadLine());
                item = magazine;
                //auto generate item ID
                item.itemId = itemCounter.ToString("D4");
                itemCounter++;
                Items.Add(item);
                Console.WriteLine($"Item successfully added with ID: {item.itemId}!");
                Console.WriteLine();
            }

            else
            {
                Console.WriteLine("Invalid choice. Try again!");
            }
        }

        public void ViewItems()
        {
            if (Items.Count == 0)
            {
                Console.WriteLine("No items in the library yet.");
                return;
            }

            Console.WriteLine("\n------------------------------- LIBRARY ITEMS -------------------------------");
            Console.WriteLine("{0,-8} {1,-6} {2,-30} {3,-20} {4,-6}", "Item ID", "ISBN", "Title", "Author", "Year");
            Console.WriteLine(new string('-', 80));

            foreach (var item in Items)
            {
                if (item is Book book)
                {
                    Console.WriteLine("{0,-8} {1,-6} {2,-30} {3,-20} {4,-6}",
                        book.itemId, book.isbn, book.title, book.author, book.publishedYear);
                }
                if (item is ReferenceBook refBook)
                {
                    Console.WriteLine("{0,-8} {1,-6} {2,-30} {3,-20} {4,-6} {5,-12}",
                        refBook.itemId, refBook.isbn, refBook.title, refBook.author, refBook.publishedYear,
                        $"Restricted: {(refBook.isRestricted ? "Yes" : "No")}");
                }
                else if (item is Magazine mag)
                {
                    Console.WriteLine("{0,-8} {1,-6} {2,-30} {3,-20} {4,-6} {5,-12}",
                        mag.itemId, mag.isbn, mag.title, "-", mag.publishedYear,
                        $"Issue {mag.issueNumber}");
                }
            }

            Console.WriteLine(new string('-', 80) + "\n");
        }


        public void SearchItems()
        {
            Console.WriteLine("Enter a keyword:");
            string keyword = Console.ReadLine().ToLower();
            var matches = Items.Where(i=> i.title.ToLower().Contains(keyword)).ToList();
            if(matches.Count == 0)
            {
                Console.WriteLine("No matches found.");
                return;
            }
            else
            {
                Console.WriteLine("Matching Items:");
                foreach (var i in matches)
                {
                    i.DisplayInfo();
                }
            }
        }

        internal void BorrowItem(Member member)
        {
            
            Console.WriteLine("Enter the ISBN of the item you'd like to borrow (you can locate item IDs by using the ViewItems option.)");
            string userInput = Console.ReadLine();
            LibraryItem founditem = Items.FirstOrDefault(i => i.isbn == userInput);
            if(founditem != null )
            {
                if (member.currentlyBorrowed.Count >= 3)
                {
                    Console.WriteLine("You may only borrow three items at a time. Please return an item if you wish to proceed.");
                    return;
                }
                if(founditem is ReferenceBook)
                {
                    Console.WriteLine("Sorry, reference books cannot be borrowed.");
                    return;
                }
                if(!founditem.isAvailable)
                {
                    Console.WriteLine($"Sorry, {founditem.title} is currently not available.");
                    return;
                }

                //check if member has already borrowed this item
                if (member.currentlyBorrowed.Any(b => b.Item == founditem)) //loop through borrowed items
                {
                    Console.WriteLine("You have already borrowed this item!");
                    return;
                }

                Console.WriteLine("Item found!\nItem Details:");
                founditem.DisplayInfo();

                //add item to currentlyBorrowed list
                member.currentlyBorrowed.Add(new BorrowedItem { Item = founditem, borrowedDate = DateTime.Now });
                founditem.isAvailable = false;
                DateTime borrowedDate = DateTime.Now;
                Console.WriteLine($"{founditem.title} has been added to {member.fName}'s borrowed items.");
                // temp hack for testing overdue
                
                //calculate the due date 
                DateTime dueDate = DateTime.Now.AddDays(14);
                Console.WriteLine($"To avoid getting charged with a late fee, please return the item on: {dueDate}");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Item not found. Please try again.");
            }
        }

        internal void ReturnItem(Member member)
        {
            Console.WriteLine($"{member.fName}'s Currently Borrowed Items");
            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"{"ISBN",-10}{"Title",-25} {"Borrowed Date",-20}");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
            foreach (BorrowedItem b in member.currentlyBorrowed)
            {
                Console.WriteLine($"{b.Item.isbn,-10}{b.Item.title,-25}{b.borrowedDate,-20}");
            }
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Enter the ISBN of the item you'd like to return:");
            string userInput = Console.ReadLine();
            BorrowedItem borrowed = member.currentlyBorrowed.FirstOrDefault(i => i.Item.isbn == userInput); 
            if (borrowed != null)
            {
                Console.WriteLine("Item found!\nItem Details:");
                borrowed.Item.DisplayInfo();

                //add item to currentlyBorrowed list
                member.currentlyBorrowed.Remove(borrowed); 
                member.previouslyBorrowed.Add(borrowed);
                Console.WriteLine($"{borrowed.Item.title} has been removed from {member.fName}'s burrowed items and added to {member.fName}'s burrow history.");
                //make item availabe again for other members to borrow
                borrowed.Item.isAvailable = true;
                DateTime returnedDate = DateTime.Now;
            }
            else
            {
                Console.WriteLine("You haven't burrowed this item to return it. Please recheck the item ID and try again.");
            }
        }

        public double CalculateBorrowCost(Member member, string isbn)
        {
            try
            {
                BorrowedItem borrowed = member.currentlyBorrowed.FirstOrDefault(b => b.Item.isbn == isbn);
                if (borrowed == null)
                {
                    Console.WriteLine("You haven't borrowed an item with this ISBN.");
                    return 0;
                }
                double dailyRate = 0;

                if (borrowed.Item is Book)
                    dailyRate = 1.0;
                else if (borrowed.Item is Magazine)
                    dailyRate = 0.5;
                Console.WriteLine("Enter the number of days you borrowed the item for:");
                int borroweddays = Convert.ToInt32(Console.ReadLine());

                //Calculate days borrowed
                //TimeSpan duration = DateTime.Now - borrowed.borrowedDate;
                //double days = Math.Ceiling(duration.TotalDays); // round up to nearest day

                return dailyRate * borroweddays; 

            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Error calculating borrowing cost: {ex.Message}");
                return 0;

            }
            
        }

        public Member GetMemberById(string memberId)
        {
            return Members.FirstOrDefault(m => m.memberId == memberId);
        }

        public void AddDefaultMember()
        {
            Member defaultMember = new Member();
            defaultMember.memberId = "M123";
            defaultMember.fName = "Default";
            defaultMember.lName = "Member";
            defaultMember.age = 25; //random age above 12
            defaultMember.phoneNumber = "N/A";
            defaultMember.address = "N/A";
            //add default member to Members list
            Members.Add(defaultMember);
        }

    }
}

