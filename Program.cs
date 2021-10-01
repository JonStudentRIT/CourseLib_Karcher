using System;
using System.Collections.Generic;
using PeopleLib;

namespace CourseLib
{
    /* Class: Schedule
     * Author: Jonathan Karcher
     * Purpose: Create a school schedule with a start and end time and how many days of the week that they occure
     */
    public class Schedule
    {
        // start point of the school class
        public DateTime startTime;
        // end point of the school class
        public DateTime endTime;
        // list of the days that this class is taken
        public List<DayOfWeek> daysOfWeek = new List<DayOfWeek>();
    }
    /* Class: Course
     * Author: Jonathan Karcher
     * Purpose: Create school course with a description teacher email a schedule and a course code
     */
    public class Course
    {
        // the class course code
        // Note: this is the element used for indexing in "Classes"
        public string courseCode;
        // the description of the school class
        public string description;
        // the email of the teacher
        public string teacherEmail;
        // the schedual of this course code
        public Schedule schedule;
        /* Constructor: Course
         * Purpose: Course is initialized by defining the courseCode and description
         * Restrictions: None
         */
        public Course(string courseCode, string description)
        {
            this.courseCode = courseCode;
            this.description = description;
        }      
    }
    /* Class: Courses
     * Purpose: Create a listing of courses that are indexed by the course courseCode
     * Restrictions: None
     */
    public class Courses
    {
        // list of the courses
        public SortedList<string, Course> sortedList = new SortedList<string, Course>();
        /* Indexer: Course
         * Purpose: Course is initialized by defining the courseCode and description
         * Restrictions: None
         */
        public Course this[string courseCode]
        {
            get
            {
                // the course to return
                Course returnVal;
                try
                {
                    // if found return the course
                    returnVal = (Course)sortedList[courseCode];
                }
                catch
                {
                    // if not found set to null
                    returnVal = null;
                }
                // return the course found
                return (returnVal);
            }

            set
            {
                try
                {
                    // add a new course to the course list
                    sortedList[courseCode] = value;
                }
                // if the entery was invalid throw it out
                catch
                {}
            }
        }
        /* Method: Remove
         * Purpose: Remove a course from the courese list based on the courseCode
         * Restrictions: None
         */
        public void Remove(string courseCode)
        {
            // if the course entered exists
            if (courseCode != null)
            {
                //remove it
                sortedList.Remove(courseCode);
            }
        }
        /* Constructor: Courses
         * Purpose: Create a list of 100 course items
         * Restrictions: None
         */
        public Courses()
        {
            Course thisCourse;
            Schedule thisSchedule;

            Random rand = new Random();

            // generate courses IGME-200 through IGME-299
            for (int i = 200; i < 300; ++i)
            {
                // use constructor to create new course object with code and description
                thisCourse = new Course(($"IGME-{i}"), ($"Description for IGME-{i}"));

                // create a new Schedule object
                thisSchedule = new Schedule();
                for (int dow = 0; dow < 7; ++dow)
                {
                    // 50% chance of the class being on this day of week
                    if (rand.Next(0, 2) == 1)
                    {
                        // add to the daysOfWeek list
                        thisSchedule.daysOfWeek.Add((DayOfWeek)dow);

                        // select random hour of day
                        int nHour = rand.Next(0, 24);

                        // set start and end times of minute duration
                        // select fixed date to allow time calculations
                        thisSchedule.startTime = new DateTime(1, 1, 1, nHour, 0, 0);
                        thisSchedule.endTime = new DateTime(1, 1, 1, nHour, 50, 0);
                    }
                }

                // set the schedule for this course
                thisCourse.schedule = thisSchedule;

                // add this course to the SortedList
                this[thisCourse.courseCode] = thisCourse;
            }
        }

    }
    /* Class: Program
     * Author: Jonathan Karcher
     * Purpose: Entery class for the library
     */
    class Program
    {
        /* Method: Main
         * Purpose: Entery point for the library
         * Restrictions: None
         */
        static void Main(string[] args)
        {
        }
    }
}
