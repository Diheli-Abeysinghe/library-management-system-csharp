using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CB015673___SD_Assignment_1
{
    public class Magazine : LibraryItem
    {
        public int issueNumber {  get; set; }
        public DateTime publishedDate { get; set; }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Magazine ID: {itemId}\nISBN: {isbn}\nTitle:{title}\nAvailability: {(isAvailable ? "Available": "Not Available")}\nIssue Number:{ issueNumber}\nPublished Date: {publishedDate}");
        }
    }
}
