using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using David_Mod6Act1_Copy.Models;
using System.Collections.ObjectModel;

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
    }
}
