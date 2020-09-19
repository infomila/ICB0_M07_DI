using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace MapEditor.Model
{
    /// <summary>
    /// Classe principal que representa el mapa i els
    /// seus continguts (els items).
    /// Conté també les dimensions de la cel·la.
    /// </summary>
    class Map
    {
        private static Map _MapSingleton;
        public static Map getMap()
        {
            if(_MapSingleton==null) 
            {
                _MapSingleton = new Map();
                MapItem primer = new MapItem(_MapSingleton, Item.getItems()[0], 6, 2, 10,false);
                MapItem segon = new MapItem(_MapSingleton, Item.getItems()[1], 12, 2, 1, false);
                MapItem tercer = new MapItem(_MapSingleton, Item.getItems()[2], 20, 10, 1, true);
                MapItem quart = new MapItem(_MapSingleton, Item.getItems()[1], 6, 15, 3, false);
                _MapSingleton.addItem(primer);
                _MapSingleton.addItem(segon);
                _MapSingleton.addItem(tercer);
                _MapSingleton.addItem(quart);

                _MapSingleton.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/map_0.jpg"));
                _MapSingleton.CellHeight = 49;
                _MapSingleton.CellWidth = 49;
            }
            return _MapSingleton;
        }


        public Map()
        {
            mapItems = new ObservableCollection<MapItem>();
        }
        private ObservableCollection<MapItem> mapItems;


        public ObservableCollection<MapItem> MapItems
        {
            get { return mapItems; }
            
        }

        public void addItem( MapItem pItem)
        {
            if (pItem != null) mapItems.Add(pItem);
        }

        public void removeItem(int index)
        {
            if(index>=0&&index<mapItems.Count)
            {
                mapItems.RemoveAt(index);
            }
        }

        private BitmapImage mImageSource;

        public BitmapImage ImageSource
        {
            get { return mImageSource; }
            set
            {
                mImageSource = value;
            }
        }

        private int mCellHeight;

        public int CellHeight
        {
            get { return mCellHeight; }
            set { mCellHeight = value; }
        }
        private int mCellWidth;

        public int CellWidth
        {
            get { return mCellWidth; }
            set { mCellWidth = value; }
        }

        /// <summary>
        /// Número de cel·les en alçada
        /// </summary>
        public int YSize
        {
            get
            {
                if (ImageSource != null)
                {
                    return ImageSource.PixelHeight / mCellHeight;
                }
                return 0;
            }
        }
        /// <summary>
        /// Número de cel·les en amplada
        /// </summary>
        public int XSize
        {
            get
            {
                if (ImageSource != null)
                {
                    return ImageSource.PixelWidth / mCellWidth;
                }
                return 0;
            }
        }
    }
}
