using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using David_Mod6Act1_Copy.ViewModels;
using David_Mod6Act1_Copy.Models;


namespace David_Mod6Act1_Copy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentView : ContentPage
    {
        public StudentView()
        {
            InitializeComponent();
            BindingContext = new StudentViewModel();
        }

        private async void OnItemTapped(object sender, ItemTappedEventArgs args)
        {
            var student = args.Item as Student;
            if (student == null) return;

            await Navigation.PushAsync(new StudentDetailPage(student));
            lstStudent.SelectedItem = null;
        }
    }
}