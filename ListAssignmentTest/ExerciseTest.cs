using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ListAssignment;
using Xunit;

namespace ListAssignmentTest
{
    public class ExerciseTest
    {
        private static IStudentList CreateList() => new StudentList();

        public readonly List<Student> _students = new List<Student>
        {
            new Student("Adrian", 20, 123, 2.0),
            new Student("Max", 21, 1423, 1.0),
            new Student("Lisa", 23, 345, 1.0)
        };

        [Fact]
        public void TestAddAtStart()
        {
            TestAddAtStartInternal(new StudentList());
        }

        public void TestAddAtStartInternal(IStudentList list)
        {
            _students.ForEach(list.AddAtStart);

            var reversed = new List<Student>(_students);
            reversed.Reverse();

            Assert.True(list.IsSameAs(reversed));
        }
    }
}