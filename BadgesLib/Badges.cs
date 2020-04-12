using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgesLib
{
    public class Badges
    {
        public int BadgeId { get; set; }
        public List<string> DoorNames { get; set; }
        public Badges() { }
        public Badges(int badgeId, List<string> doorNames)
        {
            BadgeId = badgeId;
            DoorNames = doorNames;
        }
    }
}
