using Resources;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace WinFormExample
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text;
            string city = cityTextBox.Text;
            string gender = genderComboBox.Text;

            if (string.IsNullOrEmpty(name))
            {
                DisplayErrorMessage(GlobalResources.NameText);
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

        private void LanguageSelection_Click(object sender, EventArgs e)
        {
            var selectedLanguageItem = (ToolStripMenuItem) sender;
            var text = selectedLanguageItem.Text;

            System.Threading.Thread.CurrentThread.CurrentUICulture = GetUICulture(text);
        }

        private void UpdateUsersTree(string name, string city, string gender)
        {
            var userNode = new TreeNode(name);
            var subNodes = new[] {new TreeNode($"{GlobalResources.CityText} : {city}"), new TreeNode($"{GlobalResources.GenderText} : {gender}")};

            userNode.Nodes.AddRange(subNodes);
            usersTree.Nodes.Add(userNode);
        }

        private CultureInfo GetUICulture(string language)
        {
            if (language.Equals(GlobalResources.FrenchText))
                return CultureInfo.GetCultureInfo("fr-FR");

            if (language.Equals(GlobalResources.EnglishText))
                return CultureInfo.GetCultureInfo("en-US");

            if (language.Equals(GlobalResources.GermanText))
                return CultureInfo.GetCultureInfo("de");

            return CultureInfo.CurrentUICulture;
        }

        private void DisplayErrorMessage(string argumentField)
        {
            string message = string.Format(GlobalResources.errorMessage, argumentField);
            MessageBox.Show(message);
        }
    }
}
