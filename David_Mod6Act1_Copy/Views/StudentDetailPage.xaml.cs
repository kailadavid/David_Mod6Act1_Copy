using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using David_Mod6Act1_Copy.Services;
using David_Mod6Act1_Copy.Models;

namespace David_Mod6Act1_Copy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentDetailPage : ContentPage
    {
        DBFirebase services;
        public StudentDetailPage(Student student)
        {
            InitializeComponent();
            BindingContext = student;

            services = new DBFirebase();
        }
        public async void BtnDelete(object sender, EventArgs e)
        {
            await services.DeleteStudent(int.Parse(StudentID.Text), StudentName.Text, Course.Text, int.Parse(YearLevel.Text), Section.Text);
            await Navigation.PushAsync(new StudentView());
        }

        public async void BtnUpdate(object sender, EventArgs e)
        {
            await services.UpdateStudent(int.Parse(StudentID.Text), StudentName.Text, Course.Text, int.Parse(YearLevel.Text), Section.Text);
            await Navigation.PushAsync(new StudentView());
        }
    }
}