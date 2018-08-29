using System;
using System.Diagnostics;
using System.IO;

namespace ListAssignment
{
    public class Node
    {
        public Node next;
        public Student data;
    }

    public class StudentList : IStudentList
    {
        Node head;

        public void AddAtEnd(Student student)
        {
            Node node = new Node();

            //If the list was not empty find the last one and add the new student
            if (head != null)
            {
                Node current = head;
                while (current.next != null)
                {
                    current = current.next;
                }
                node.data = student;
                node.next = null;
                current.next = node;
            }
            else
            {
                node.data = student;
                node.next = head;
                head = node;
            }
        }

        public void AddAtStart(Student student)
        {
            //Swaping head with the new student
            Node node = new Node();
            node.data = student;
            node.next = head;

            head = node;
        }

        public Student RemoveFirst()
        {
            //Removing the head and set the second one as the head
            if (head != null)
            {
                Student RemovedStudent = head.data;
                head = head.next;
                return RemovedStudent;
            } else {
                // Throw exception if the there is no student
                throw new System.ArgumentException("No student exists");
            }
        }

        public void PrintList()
        {
            //Print whole list one by one in a proper format 
            Node current = head;
            while (current != null)
            {
                Console.Write(current.data.Name + " ");
                Console.Write(current.data.Age + " ");
                Console.Write(current.data.MatriculationNumber + " ");
                Console.WriteLine("{0:F1}", current.data.Grade);
                current = current.next;
            }
        }

        public void Replace(object studentIdentifier, Student newStudent)
        {
            //Checking all nodes until find the student
            Node current = head;
            while (current != null)
            {
                if (studentIdentifier.Equals(current.data.Identifier))
                {
                    current.data = newStudent;
                    break;
                }
                current = current.next;
            }

            //Throw exception if the student doesn't exist
            if (current == null) {
                throw new System.ArgumentException("No student with the specified attribute value exists");
            }
        }

        public void ReadFromFile(string file)
        {
            if (File.Exists(file))
            {
                //Making sure the list will be empty
                head = null;

                //Read file line by line in case of too much records
                foreach (string line in File.ReadLines(file))
                {
                    //Remove all extra spaces
                    string newLine = line.Replace("  ", " ").Trim();
                    if (newLine.Length > 0)
                    {
                        //Make student based on string data
                        Student student = new Student(
                            newLine.Split()[0], // Name
                            Int32.Parse(newLine.Split()[1]), // Age
                            Int32.Parse(newLine.Split()[2]), // MatriculationNumber
                            Double.Parse(newLine.Split()[3]) // Grade
                        );

                        //Finally add the student to the list
                        this.AddAtEnd(student);
                    }
                }
            }
        }

        public Student GetStudentAt(int index)
        {
            //Use i as index of the list and checking all nodes
            int i = 0;
            Node current = head;
            while (current != null)
            {
                if (index == i) {
                    return current.data;
                }
                current = current.next;
                i++;
            }
            return null;
        }

        public int Length()
        {
            //Use a counter for counting the length of whole list
            int count = 0;
            Node current = head;
            while (current != null)
            {
                current = current.next;
                count++;
            }
            return count;
        }
    }
}