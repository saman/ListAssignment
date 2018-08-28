using System;
using System.Diagnostics;

namespace ListAssignment
{
    public class StudentList : IStudentList
    {
        private Student head = null;

        public void AddAtEnd(Student student)
        {

            int len = this.Length();
            if (len > 0)
            {
                int LastIndex = len - 1;
                Student last = this.GetStudentAt(LastIndex);
                last.next = student;
            } else {
                head = student;
            }

        }

        public void AddAtStart(Student student)
        {
            Student ToAdd = student;
            ToAdd.next = head;
            head = ToAdd;
        }

        public Student RemoveFirst()
        {
            Student RemovedStudent = null;
            if (head != null)
            {
                RemovedStudent = head;
                head = head.next;
            }
            return RemovedStudent;
        }

        public void PrintList()
        {
            Student current = head;
            while (current != null)
            {
                Console.Write(current.Name + ", ");
                Console.Write(current.Age + ", ");
                Console.Write(current.MatriculationNumber + ", ");
                Console.WriteLine("{0:F1}", current.Grade);
                current = current.next;
            }
        }

        public void Replace(object studentIdentifier, Student newStudent)
        {
            Student current = head;
            while (current != null)
            {
                if (studentIdentifier == current.Identifier)
                {
                    newStudent.next = current.next;
                    current = newStudent;
                }
            }
        }

        public void ReadFromFile(string file)
        {
            throw new System.NotImplementedException();
        }

        public Student GetStudentAt(int index)
        {
            int count = 0;
            Student current = head;
            while (current != null)
            {
                if (index == count) {
                    return current;
                }
                current = current.next;
                count++;
            }
            return null;
        }

        public int Length()
        {
            int count = 0;
            Student current = head;
            while (current != null)
            {
                current = current.next;
                count++;
            }
            return count;
        }
    }
}