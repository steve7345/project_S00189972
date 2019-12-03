using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace project_S00189972
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Activity> activities = new List<Activity>();
        List<Activity> selectedactivities = new List<Activity>();
        List<Activity> filteredactivities = new List<Activity>();
        decimal totalCost = 0;

        public MainWindow()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


            //information for each activity
            Activity l1 = new Activity()
            {
                Name = "Treking",
                Description = "Instructor led group trek through local mountains.",
                ActivityDate = new DateTime(2019, 06, 01),
                TypeOfActivity = ActivityType.Land,
                Cost = 20m

            };

            Activity l2 = new Activity()
            {
                Name = "Mountain Biking",
                Description = "Instructor led half day mountain biking.  All equipment provided.",
                ActivityDate = new DateTime(2019, 06, 02),
                TypeOfActivity = ActivityType.Water,
                Cost = 30m
            };

            Activity l3 = new Activity()
            {
                Name = "Abseiling",
                Description = "Experience the rush of adrenaline as you descend cliff faces from 10-500m.",
                ActivityDate = new DateTime(2019, 06, 03),
                TypeOfActivity = ActivityType.Land,
                Cost = 40m
            };

            Activity w1 = new Activity()
            {
                Name = "Kayaking",
                Description = "Half day lakeland kayak with island picnic.",
                ActivityDate = new DateTime(2019, 06, 01),
                TypeOfActivity = ActivityType.Water,
                Cost = 40m
            };

            Activity w2 = new Activity()
            {
                Name = "Surfing",
                Description = "2 hour surf lesson on the wild atlantic way",
                ActivityDate = new DateTime(2019, 06, 02),
                TypeOfActivity = ActivityType.Water,
                Cost = 25m
            };

            Activity w3 = new Activity()
            {
                Name = "Sailing",
                Description = "Full day lakeland kayak with island picnic.",
                ActivityDate = new DateTime(2019, 06, 03),
                TypeOfActivity = ActivityType.Water,
                Cost = 50m
            };

            Activity a1 = new Activity()
            {
                Name = "Parachuting",
                Description = "Experience the thrill of free fall while you tandem jump from an airplane.",
                ActivityDate = new DateTime(2019, 06, 01),
                TypeOfActivity = ActivityType.Air,
                Cost = 100m
            };

            Activity a2 = new Activity()
            {
                Name = "Hang Gliding",
                Description = "Soar on hot air currents and enjoy spectacular views of the coastal region.",
                ActivityDate = new DateTime(2019, 06, 02),
                TypeOfActivity = ActivityType.Air,
                Cost = 80m
            };

            Activity a3 = new Activity()
            {
                Name = "Helicopter Tour",
                Description = "Experience the ultimate in aerial sight-seeing as you tour the area in our modern helicopters",
                ActivityDate = new DateTime(2019, 06, 03),
                TypeOfActivity = ActivityType.Air,
                Cost = 200m
            };

            //add activities to the listbox
            activities.Add(l1);
            activities.Add(l2);
            activities.Add(l3);
            activities.Add(w1);
            activities.Add(w2);
            activities.Add(w3);
            activities.Add(a1);
            activities.Add(a2);
            activities.Add(a3);
            activities.Sort();
            lbxActivities.ItemsSource = activities;
        }


        //method to show the description when activity is selected
        private void LbxActivities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            // show description in text box when activity is clicked
            Activity activity = lbxActivities.SelectedItem as Activity;
            if (activity != null)
            {

                TblkShowDespription.Text = activity.Description;
            }

        }



        //Add activity to cart from activity listbox
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            //figure out what is been selected
            Activity selectedActivity = lbxActivities.SelectedItem as Activity;

            //null check
            if (selectedActivity != null)
            {
                Boolean dateConflict = false;
                foreach (Activity activity in selectedactivities)
                {

                    if (activity.ActivityDate == selectedActivity.ActivityDate)
                    {
                        dateConflict = true;
                        MessageBox.Show("Date already selected");
                    }
                }
                if (!dateConflict)
                {

                    //move activity from left listbox to right
                    activities.Remove(selectedActivity);
                    selectedactivities.Add(selectedActivity);
                    
                    totalCost += selectedActivity.Cost;
                    TblkTotalCost.Text = totalCost.ToString();
                    RefreshScreen();
                }

            }
            else
            {
                MessageBox.Show("Nothing selected");
            }
            activities.Sort();
        }


        //move activity back from cart to activity list box
        private void BtnRemove_Click(object sender, RoutedEventArgs e)
        {
            //figure out what is been selected
            Activity selectedActivity = lbxCart.SelectedItem as Activity;

            //null check
            if (selectedActivity != null)
            {
                //move activity from left listbox to right

                activities.Add(selectedActivity);
                selectedactivities.Remove(selectedActivity);
                
                totalCost -= selectedActivity.Cost;
                TblkTotalCost.Text = totalCost.ToString();
                
                RefreshScreen();
            }
            activities.Sort();
        }

        //method handles all radio buttons 
        private void RbAll_Click(object sender, RoutedEventArgs e)
        {
            //empties list
            filteredactivities.Clear();

            if (rbAll.IsChecked == true)
            {
                //show all activities
                RefreshScreen();

            }
            else if (rbLand.IsChecked == true)
            {
                //show all land activities
                foreach (Activity activity in activities)
                {
                    if (activity.TypeOfActivity == ActivityType.Land)
                    {
                        filteredactivities.Add(activity);
                        RefreshActivities();
                    }
                }


            }
            else if (rbWater.IsChecked == true)
            {
                //show all water activities
                foreach (Activity activity in activities)
                {
                    if (activity.TypeOfActivity == ActivityType.Water)
                    {
                        filteredactivities.Add(activity);
                        RefreshActivities();
                    }
                }
            }
            else if (rbAir.IsChecked == true)
            {
                //show all air activities
                foreach (Activity activity in activities)
                {
                    if (activity.TypeOfActivity == ActivityType.Air)
                    {
                        filteredactivities.Add(activity);
                        RefreshActivities();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select option for land, air, water or all");
            }
        }

        //method to refresh the activities for radio buttons
        private void RefreshActivities()
        {
            lbxActivities.ItemsSource = null;
            lbxActivities.ItemsSource = filteredactivities;
        }

        //method to refresh screen
        private void RefreshScreen()
        {
            lbxActivities.ItemsSource = null;
            lbxActivities.ItemsSource = activities;

            lbxCart.ItemsSource = null;
            lbxCart.ItemsSource = selectedactivities;
        }

    }
}
