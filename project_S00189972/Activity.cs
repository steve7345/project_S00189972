using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_S00189972 
{
    //enum for activity type 
    public enum ActivityType { Land, Water, Air}
    public class Activity : IComparable
    {
        //properties
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ActivityDate { get; set; }
        public decimal Cost { get; set; }
        public ActivityType TypeOfActivity { get; internal set; }

        // construstors
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

        //to diplaye the name and activity date in the listboxes
        public override string ToString()
        {
            return $"{Name} - { ActivityDate.ToShortDateString()}";
        }


        //icomparablle to sort dates
        public int CompareTo(object obj)
        {
            Activity that = (Activity)obj;
            return ActivityDate.CompareTo(that.ActivityDate);
        }
    }


   

}





















