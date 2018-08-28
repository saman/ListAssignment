using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ListAssignment;
using Xunit;
using System.Diagnostics;

namespace ListAssignmentTest
{
    public class Test
    {
        private static IStudentList CreateList() => new StudentList();

        private readonly List<Student> _students = new List<Student>
        {
            new Student("Adrian", 20, 123, 2.0),
            new Student("Max", 21, 1423, 1.0),
            new Student("Lisa", 23, 345, 1.0)
        };

        [Fact]
        public void TestAddAtEnd()
        {
            var list = CreateList();
            _students.ForEach(list.AddAtEnd);

            Assert.True(list.IsSameAs(_students));
        }

        [Fact]
        public void TestRemoveFirst()
        {
            var list = CreateList();
            _students.ForEach(list.AddAtStart);

            var removed = new List<Student>();
            while (list.Length() > 0)
            {
                removed.Add(list.RemoveFirst());
            }

            var reversed = new List<Student>(_students);
            reversed.Reverse();
            Assert.Equal(reversed, removed);
        }

        [Fact]
        public void TestPrintList()
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            Console.SetOut(writer);

            var list = CreateList();
            list.AddAtStart(_students[0]);
            list.PrintList();
            writer.Flush();

            var output = Encoding.UTF8.GetString(stream.ToArray());
            Assert.Contains("Adrian", output);
            Assert.Contains("20", output);
            Assert.Contains("123", output);
            Assert.Contains("2.0", output);

            var standardOutput = new StreamWriter(Console.OpenStandardOutput()) {AutoFlush = true};
            Console.SetOut(standardOutput);
        }

        [Fact]
        public void TestReplace()
        {
            var list = CreateList();
            _students.ForEach(list.AddAtEnd);

            var newAdrian = new Student("Adrian", 20, 123, 3.0);
            var studentsReplaced = new List<Student>(_students) {[0] = newAdrian};
            list.Replace(newAdrian.Identifier, newAdrian);

            Assert.True(list.IsSameAs(studentsReplaced));
        }

        [Fact]
        public void TestReadFromFile()
        {
            var tempFile = Path.GetTempFileName();
            var lines = _students.Select(s => $"{s.Name} {s.Age} {s.MatriculationNumber} {s.Grade:0.0}");
            File.WriteAllLines(tempFile, lines);

            var list = CreateList();
            list.ReadFromFile(tempFile);

            Assert.True(list.IsSameAs(_students));
        }

        [Fact]
        public void TestGetStudentAt()
        {
            var list = CreateList();
            _students.ForEach(list.AddAtEnd);

            Assert.Equal(list.GetStudentAt(1), _students[1]);
        }

        [Fact]
        public void TestLengths()
        {
            var list = CreateList();
            _students.ForEach(list.AddAtEnd);
            Assert.Equal(list.Length(), _students.Count);
        }
    }

    internal static class Extensions
    {
        private sealed class StudentEqualityComparer : IEqualityComparer<Student>
        {
            public bool Equals(Student x, Student y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return string.Equals(x.Name, y.Name) && x.Age == y.Age &&
                       x.MatriculationNumber == y.MatriculationNumber && x.Grade.Equals(y.Grade);
            }

            public int GetHashCode(Student obj)
            {
                unchecked
                {
                    var hashCode = (obj.Name != null ? obj.Name.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ obj.Age;
                    hashCode = (hashCode * 397) ^ obj.MatriculationNumber;
                    hashCode = (hashCode * 397) ^ obj.Grade.GetHashCode();
                    return hashCode;
                }
            }
        }

        private static List<Student> ToList(this IStudentList list) =>
            Enumerable.Range(0, list.Length()).Select(list.GetStudentAt).ToList();

        internal static bool IsSameAs(this IStudentList a, IEnumerable<Student> b) =>
            a.ToList().SequenceEqual(b, new StudentEqualityComparer());
    }
}