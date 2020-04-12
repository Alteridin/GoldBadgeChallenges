using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims
{
    public class ClaimsRepository
    {
        protected readonly Queue<Claims> _queueDirectory = new Queue<Claims>();
        public Queue<Claims> GetClaims()
        {
            return _queueDirectory;
        }
        public bool AddContentToQueue(Claims content)
        {
            int startingCount = _queueDirectory.Count;
            _queueDirectory.Enqueue(content);
            bool wasAdded = (_queueDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }

    }
}
