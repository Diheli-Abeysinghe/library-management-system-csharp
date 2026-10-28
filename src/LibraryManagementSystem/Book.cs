using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB015673___SD_Assignment_1
{
    public class Book : LibraryItem
    {
        //public string author { get; set; }
        //public int publishedYear { get; set; }
        public int pageCount {  get; set; }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Book ID: {itemId}\nISBN: {isbn}\nTitle: {title}\nAuthor: {author} \nAvailability: {(isAvailable ? "Available" : "Not Available")}\nNo. of pages: {pageCount}\n Year of Publication: {publishedYear}");
        }
    }
}
