using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using David_Mod6Act1_Copy.Models;
using David_Mod6Act1_Copy.Services;
using MvvmHelpers;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace David_Mod6Act1_Copy.ViewModels
{
    class StudentViewModel : BaseViewModel
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string Course { get; set; }
        public int YearLevel { get; set; }
        public string Section { get; set; }

        private DBFirebase services;

        public Command AddStudentCommand { get; }
        public ObservableCollection<Student> _students = new ObservableCollection<Student>();
        public ObservableCollection<Student> Students
        {
            get { return _students; }
            set
            {
                _students = value;
                OnPropertyChanged();
            }
        }

        public StudentViewModel()
        {
            services = new DBFirebase();
            Students = services.getStudent();
            AddStudentCommand = new Command(async () => await addStudentAsync(StudentID, StudentName, Course, YearLevel, Section));
        }

        public async Task addStudentAsync(int StudentID, string StudentName, string Course, int YearLevel, string Section)
        {
            await services.AddStudent(StudentID, StudentName, Course, YearLevel, Section);
        }
    }
}
