using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "The New Guy";
        job1._company = "The New Store";
        job1._startYear = 2091;
        job1._endYear = 2061;

        Job job2 = new Job();
        job2._jobTitle = "The Old Guy";
        job2._company = "The Old Store";
        job2._startYear = 647;
        job2._endYear = 9999;

        Resume userResume = new Resume();
        userResume._name = "Nicholas Bastian";
        userResume._jobs.Add(job1);
        userResume._jobs.Add(job2);
        userResume.Display();
    }
}