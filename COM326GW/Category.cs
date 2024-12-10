using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COM326GW
{
    public class Category
    {
        private static int _nextCategoryId = 1;

        private int _categoryId;
        private string _categoryName;
        private string _categoryDescription;

        public Category(string categoryName, string categoryDescription)
        {
            _categoryId = _nextCategoryId++;
            _categoryName = categoryName;
            _categoryDescription = categoryDescription;
        }

        public int CategoryId { get => _categoryId; set => _categoryId = value; }
        public string CategoryName { get => _categoryName; set => _categoryName = value; }
        public string CategoryDescription { get => _categoryDescription; set => _categoryDescription = value; }

        // Viewing a category
        public void ViewCategory()
        {
            int width = 15;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Global.Format("Name:", width)}{Global.LightGreen}{CategoryName}{Global.Reset}\n");
            sb.AppendLine($"{Global.Format("Description:", width)}{Global.LightGreen}{CategoryDescription}{Global.Reset}\n");

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
