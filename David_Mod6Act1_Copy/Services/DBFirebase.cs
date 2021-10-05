using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using David_Mod6Act1_Copy.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace David_Mod6Act1_Copy.Services
{
    public class DBFirebase
    {
        FirebaseClient client;
        public DBFirebase()
        {
            client = new FirebaseClient("https://pdcmodule07-default-rtdb.firebaseio.com/");
        }
        public ObservableCollection<Student> getStudent()
        {
            var studentData = client
                .Child("Student")
                .AsObservable<Student>()
                .AsObservableCollection();

            return studentData;
        }

        public async Task AddStudent(int StudentID, string StudentName, string Course, int YearLevel, string Section)
        {
            Student st = new Student() { StudentID = StudentID, StudentName = StudentName, Course = Course, YearLevel = YearLevel, Section = Section };
            await client
                .Child("Student")
                .PostAsync(st);
        }

        public async Task DeleteStudent(int StudentID, string StudentName, string Course, int YearLevel, string Section)
        {
            var toDeleteStudent = (await client
                .Child("Student")
                .OnceAsync<Student>()).FirstOrDefault
                (a => a.Object.StudentName == StudentName || a.Object.Course == Course || a.Object.Section == Section);
            //(a => a.Object.StudentID == StudentID || a.Object.StudentName == StudentName || a.Object.Course == Course || a.Object.YearLevel == YearLevel || a.Object.Section == Section);
            await client.Child("Student").Child(toDeleteStudent.Key).DeleteAsync();
        }

        public async Task UpdateStudent(int StudentID, string StudentName, string Course, int YearLevel, string Section)
        {
            var toUpdateStudent = (await client
                .Child("Student")
                .OnceAsync<Student>()).FirstOrDefault
                (a => a.Object.StudentName == StudentName);

            Student s = new Student() { StudentID = StudentID, StudentName = StudentName, Course = Course, YearLevel = YearLevel, Section = Section };
            await client
                .Child("Student")
                .Child(toUpdateStudent.Key)
                .PutAsync(s);

        }
    }
}
