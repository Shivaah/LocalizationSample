using Resources;
using System.Windows;
using WpfExample.Model;

namespace WpfExample
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void SubmitButton_Click(object sender, RoutedEventArgs args)
        {
            string name = nameBox.Text;
            string city = cityBox.Text;
            string gender = genderSelect.Text;

            if (string.IsNullOrEmpty(name))
            {
                DisplayErrorMessage(GlobalResources.GenderText);
                return;
            }

            if (string.IsNullOrEmpty(city))
            {
                DisplayErrorMessage(GlobalResources.CityText);
                return;
            }

            if (string.IsNullOrEmpty(gender))
            {
                DisplayErrorMessage(GlobalResources.GenderText);
                return;
            }

            UpdateUsersTree(name, city, gender);
        }

        private void UpdateUsersTree(string name, string city, string gender)
        {
            var user = new User {Name = name};
            var cityAttribute = new UserAttribute {Name = GlobalResources.CityText, Value = city};
            var genderAttribute = new UserAttribute {Name = GlobalResources.GenderText, Value = gender};

            user.UserAttributes.Add(cityAttribute);
            user.UserAttributes.Add(genderAttribute);

            usersTree.Items.Add(user);
        }

        private void DisplayErrorMessage(string argumentField)
        {
            string message = string.Format(GlobalResources.errorMessage, argumentField);
            MessageBox.Show(message);
        }
    }
}