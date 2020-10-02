using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace MapEditor
{
    public class Item: INotifyPropertyChanged
    {
        private string mName;

        public string Name
        {
            get { return mName; }
            set {
                mName = value;
                RaisePropertyChanged("Name");
            }
        }

        private string mDesc;

        public string Desc
        {
            get { return mDesc; }
            set {                
                mDesc = value;
                RaisePropertyChanged("Desc");
            }
        }

        private BitmapImage mImageSource;

        public BitmapImage ImageSource
        {
            get { return mImageSource; }
            set {                
                mImageSource = value;
                RaisePropertyChanged("ImageSource");
            }
        }

        private static ObservableCollection<Item> _items;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public static ObservableCollection<Item> getItems()
        {
            
            if(_items==null)
            {
                _items = new ObservableCollection<Item>();
                _items.Add(new Item() { Name = "Saphire", Desc = "Ancient Saphire of the dark", ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/medal.png")) });
                _items.Add(new Item() { Name = "Poison delerum", Desc = "Obscure poison for assassins.", ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/potion.png")) });
                _items.Add(new Item() { Name = "Decorative cup", Desc = "For drinking after the battle.", ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/skull.png")) });
            }

            return _items;
        }
    }
}
