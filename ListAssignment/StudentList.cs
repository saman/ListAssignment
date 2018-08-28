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
            Node node = new Node();
            node.data = student;
            node.next = head;

            head = node;
        }

        public Student RemoveFirst()
        {
            Student RemovedStudent = null;
            if (head != null)
            {
                RemovedStudent = head.data;
                head = head.next;
            }
            return RemovedStudent;
        }

        public void PrintList()
        {
            Node current = head;
            while (current != null)
            {
                Console.Write(current.data.Name + ", ");
                Console.Write(current.data.Age + ", ");
                Console.Write(current.data.MatriculationNumber + ", ");
                Console.WriteLine("{0:F1}", current.data.Grade);
                current = current.next;
            }
        }

        public void Replace(object studentIdentifier, Student newStudent)
        {
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
        }

        public void ReadFromFile(string file)
        {
            foreach (string line in File.ReadLines(file))
            {
                string newLine = line.Replace("  ", " ");
                if (newLine.Length > 0)
                {
                    Student student = new Student(
                        newLine.Split()[0], // Name
                        Int32.Parse(newLine.Split()[1]), // Age
                        Int32.Parse(newLine.Split()[2]), // MatriculationNumber
                        Double.Parse(newLine.Split()[3]) // Grade
                    );
                    this.AddAtEnd(student);
                }
            }
        }

        public Student GetStudentAt(int index)
        {
            int count = 0;
            Node current = head;
            while (current != null)
            {
                if (index == count) {
                    return current.data;
                }
                current = current.next;
                count++;
            }
            return null;
        }

        public int Length()
        {
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