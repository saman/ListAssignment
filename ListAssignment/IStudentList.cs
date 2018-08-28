namespace ListAssignment
{
    public interface IStudentList
    {
        void AddAtEnd(Student student);
        void AddAtStart(Student student);
        Student RemoveFirst();
        void PrintList();
        void Replace(object studentIdentifier, Student newStudent);
        void ReadFromFile(string file);
        Student GetStudentAt(int index);
        int Length();
    }
}