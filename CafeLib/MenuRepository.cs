using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeLib
{
    public class MenuRepository
    {
        protected readonly List<Menu> _contentDirectory = new List<Menu>();
        public bool AddContentToDirectory(Menu content)
        {
            int startingCount = _contentDirectory.Count;
            _contentDirectory.Add(content);
            bool wasAdded = (_contentDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }
        public List<Menu> GetContent()
        {
            return _contentDirectory;
        }
        public Menu GetContentByMenuNumber(int mealNumber)
        {
            foreach (Menu content in _contentDirectory)
            {
                if (content.MealNumber == mealNumber)
                {
                    return content;
                }
            }
            return null;
        }
        public bool DeleteExistingContent(Menu menu)
        {
            bool deleteResult = _contentDirectory.Remove(menu);
            return deleteResult;
        }
    }
}