using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CB015673___SD_Assignment_1
{
    public class Member
    {
        public string memberId {  get; set; }
        public string fName { get; set; }
        public string lName { get; set; }
        public int age { get; set; }
        public string address { get; set; }
        public string phoneNumber { get; set; }

        

        public List<BorrowedItem> currentlyBorrowed { get; set; } = new List<BorrowedItem>();
        public List<BorrowedItem> previouslyBorrowed { get; set; } = new List<BorrowedItem>();
        public List<OverdueItem> overdue { get; set; } = new List<OverdueItem>();

        //view borrow history
        public void ViewBorrowHistory()
        {
            if(previouslyBorrowed.Count == 0)
            {
                Console.WriteLine("You haven't borrowed any items yet! Borrow and item first.");
                return;
            }
            else
            {
                Console.WriteLine("User's Borrow History:");
                Console.WriteLine();
                Console.WriteLine("----------------------------------------------------------------------------------------------------------");
                Console.WriteLine($"{"Item ID",-10}{"Title",-25} {"Borrowed Date",-20}");
                Console.WriteLine("----------------------------------------------------------------------------------------------------------");
                foreach (BorrowedItem b in previouslyBorrowed)
                {
                    Console.WriteLine($"{b.Item.itemId, -10}{b.Item.title,-25}{b.borrowedDate,-20}");

                 
                }
            }
        }

        public void ViewCurrentlyBorrowed()
        {
            if(currentlyBorrowed.Count == 0)
            {
                Console.WriteLine("You currently have no borrowed items.");
                return;
            }
            if(currentlyBorrowed.Count == 3)
            {
                Console.WriteLine("You've reached your maximum borrowing capacity! To borrow another item, make sure you return an item first!");
            }
            else
            {
                Console.WriteLine($"{fName}'s Currently Borrowed Items");
                Console.WriteLine();
                Console.WriteLine("----------------------------------------------------------------------------------------------------------");
                Console.WriteLine($"{"Item ID", -10}{"Title", -25} {"Borrowed Date", -20}");
                Console.WriteLine("----------------------------------------------------------------------------------------------------------");
                foreach (BorrowedItem b in currentlyBorrowed)
                {
                    Console.WriteLine($"{b.Item.itemId,-10}{b.Item.title, -25}{b.borrowedDate, -20}");
                }
                Console.WriteLine("----------------------------------------------------------------------------------------------------------");
            }
        }

        public void ViewOverdueItems()
        {
            var overdue = this.currentlyBorrowed
                .Where(b => (DateTime.Now - b.borrowedDate).TotalDays >14)
                .Select(b => new OverdueItem
                {
                    Item = b.Item,
                    borrowedDate = b.borrowedDate,
                    dueDate = b.borrowedDate.AddDays(14)
                }).ToList();
            if(overdue.Count == 0)
            {
                Console.WriteLine("Yay, you have no overdue items!");
                return;
            }
            else
            {
                foreach(var o in overdue)
                {
                    int daysLate = (DateTime.Now - o.dueDate).Days; 
                    Console.WriteLine($"{o.Item.title} is overdue by {daysLate} day(s).");
                    //calculate late fees (assume the daily fine is 50 cents)
                    double lateFee = daysLate * 0.5;
                    Console.WriteLine($"You have been charged ${lateFee} as a late fee.");
                }
            }
        }

       
        
        


    }
}
