# ListAssignment
Exploring Paderborn Project Assignment

## Assignment

In the Zip archive, you will find a Visual Studio solution and a text file. In this solution, the class Student was already implemented. You must do the following subtasks:

1. Create a linked List in StudentList.cs which can take student objects. It is not allowed to use the data structures C# already provided for that.
2. Write your own!
The list should have the following operations:
    
    ### AddAtEnd
    A new List element will be added at the end
    
    ### AddAtStart
     A new List element will be added at the start
    
    ### RemoveFirst
     The first Element of the List will be removed, and is returned to the caller. If no element is present, it should throw an Exception.
    
    ### PrintList
    The content of all List elements will be printed in the console (well formatted). A grade like 2.0 should not be printed as just &quot;2&quot;, but as &quot;2.0&quot;.
    
    ### Replace
     A certain List element, identified by an attribute of the Student class that is given as a parameter to the function, will be replaced by a new Student element (think which Student attribute is suitable for uniquely identifying a student and return it in Student.Identifier)
        If no student with the specified attribute value exists, an Exception must be thrown.
    
    ### ReadFromFile
     The file specified by the parameter is read into the current list instance. In case the current list is not empty, it is automatically cleared first.
    
    ### GetStudentAt
     The Student at the specified index is retrieved.
    
    ### Length
    Returns the number of Students in the list.
    

1. Fill the list with the data provided in the text file at runtime. You can decide how you do that.

1. Inside ExerciseTest.cs, implement TestAddAtStartInternal. It needs to verify whether the IStudentList passed in as the parameter has a correct implementation of AddAtStart using an xUnit test.

We have supplied some xUnit tests inside the ZIP file. Make sure to make them pass. In general, think of all possible cases for every operation and find solutions to handle them.
