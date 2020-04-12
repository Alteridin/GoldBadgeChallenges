using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgesLib
{
    public class BadgesRepository
    {
        Dictionary<int, List<string>> _badgeDict = new Dictionary<int, List<string>>();
        public Dictionary<int, List<string>> FullAccessList()
        {
            return _badgeDict;
        }
        public bool NewBadge(Badges idDoor)
        {
            int startingCount = _badgeDict.Count;
            _badgeDict.Add(idDoor.BadgeId, idDoor.DoorNames);
            bool wasAdded = (_badgeDict.Count > startingCount) ? true : false;
            return wasAdded;
        }
        public bool AddDoorToID(int ids, string door)
        {
            List<string> listDoors = ListDoorById(ids);
            listDoors.Add(door);
            if (listDoors.Contains(door))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<string> ListDoorById(int badgeId)
        {
            foreach (KeyValuePair<int, List<string>> content in _badgeDict)
            {
                if(content.Key == badgeId)
                {
                    return content.Value;
                }
            }
            return null;
        }
        public bool RemoveDoorFromID(int ids, string door)
        {
            List<string> listDoors = ListDoorById(ids);
            listDoors.Remove(door);
            if (listDoors.Contains(door))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
