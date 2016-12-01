using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE_Central.Model
{
    /// <summary>
    /// plexs实体类
    /// </summary>
    public class PLEX
    {
        public PLEX()
        { }
        private double _PLEX1;
        private double _PLEX2;
        private double _PLEX6;
        private double _PLEX12; 
        private double _PLEX28;
        public double PLEX1
        {
            set { _PLEX1 =19.95 ; }
            get { return _PLEX1; }
        }
        public double PLEX2
        {
            set { _PLEX2 = 34.99; }
            get { return _PLEX2; }
        }
        public double PLEX6
        {
            set { _PLEX6 = 104.97; }
            get { return _PLEX6; }
        }
        public double PLEX12
        {
            set { _PLEX12 = 209.94; }
            get { return _PLEX12; }
        }
        public double PLEX28
        {
            set { _PLEX28 = 489.86; }
            get { return _PLEX28; }
        }
    }
}
