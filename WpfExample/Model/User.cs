using System.Collections.ObjectModel;

namespace WpfExample.Model
{
    public class User
    {
        public string Name { get; set; }

        public User()
        {
            UserAttributes = new ObservableCollection<UserAttribute>();
        }

        public ObservableCollection<UserAttribute> UserAttributes { get; set; }
    }
}