using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB015673___SD_Assignment_1
{
    public abstract class LibraryItem
    {
        public string itemId {  get; set; }
        public string title { get; set; }
        public string isbn { get; set; }
        public string author { get; set; }
        public int publishedYear { get; set; }
        public bool isAvailable = true; //by default, every item is available until someone borrows it
        

        public abstract void DisplayInfo();

        public void CheckAvailability()
        {
            if (isAvailable) //if is available is true, then
            {
                Console.WriteLine("This item is available for borrowing.");
            }
            else
            {
                Console.WriteLine("Sorry, this item is currently not available.");
            }
        }
    }
}
