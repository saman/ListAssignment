using System;

namespace ListAssignment
{
    public class Student
    {

        public Student next = null;

        // The name of the student
        public string Name { get; }

        // The age of the student
        public int Age { get; }

        // The Matriculation Number of the student
        public int MatriculationNumber { get; }

        // The Grade of the student from his A level
        public double Grade { get; }

        // Constructor
        public Student(string name, int age, int maNumber, double grade)
        {
            next = null;
            Name = name;
            Age = age;
            MatriculationNumber = maNumber;
            Grade = grade;
        }

        // TODO Implement this getter
        public object Identifier => this.MatriculationNumber;
    }
}