using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace MapEditor.Model
{
    /// <summary>
    /// Instància d'un Item en un Mapa
    /// </summary>
    class MapItem
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pMap">El mapa on es posa el ítem</param>
        /// <param name="pItem">El tipus de ítem</param>
        /// <param name="pX">Casella X de la graella ( compte, no són pixels )</param>
        /// <param name="pY">Casella Y de la graella ( compte, no són pixels )</param>
        /// <param name="pAmount">Quantitat de l'item</param>
        /// <param name="pIsHidden">Inidica si èstà ocult</param>
        public MapItem ( Map pMap, Item pItem, int pX, int pY, int pAmount, bool pIsHidden)
        {
            mMap = pMap;
            X = pX;
            Y = pY;
            Amount = pAmount;
            Item = pItem;
            IsHidden = pIsHidden;
        }


        private Map mMap;

        private Item mItem;

        public Item Item
        {
            get { return mItem; }
            set { mItem = value; }
        }
        private int mX;

        public int X
        {
            get { return mX; }
            set { mX = value; }
        }

        private int mY;

        public int Y
        {
            get { return mY; }
            set {
                mY = value;
            }
        }

        private bool mHidden;

        public bool IsHidden
        {
            get { return mHidden; }
            set { mHidden = value; }
        }

        private int mAmount;

        public Visibility ShowCloack
        {
            get { if (mHidden) return Visibility.Visible; else return Visibility.Collapsed; }
        }

        public int Amount
        {
            get { return mAmount; }
            set {
                if (value <= 0) throw new Exception("Invalid amount");
                mAmount = value;
            }
        }





    }
}
