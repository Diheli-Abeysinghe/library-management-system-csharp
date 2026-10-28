using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB015673___SD_Assignment_1
{
    public class ReferenceBook : LibraryItem
    {
        public bool isRestricted = true; //Note: assume all reference books are restricted to members. Only library staff can access them

        public override void DisplayInfo()
        {
            Console.WriteLine($"Reference Book ID: {itemId}\nISBN: {isbn}\nTitle: {title}\n Restricted Status: {isRestricted}");
        }
    }
}
