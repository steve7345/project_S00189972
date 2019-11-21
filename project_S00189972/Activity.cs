using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_S00189972 
{
    public enum ActivityType { Land, Water, Air}
    public class Activity : IComparable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ActivityDate { get; set; }
        public decimal Cost { get; set; }
        public ActivityType TypeOfActivity { get; internal set; }

        public Activity(string name, string description, DateTime activityDate, decimal cost)
        {
            Name = name;
            Description = Description;
            ActivityDate = activityDate;
            Cost = cost;
            
            
        }

        public Activity()
        {
        }
        public override string ToString()
        {
            return $"{Name} - { ActivityDate.ToShortDateString()}";
        }

        public int CompareTo(object obj)
        {
            Activity that = (Activity)obj;
            return ActivityDate.CompareTo(that.ActivityDate);
        }
    }


   

}





















