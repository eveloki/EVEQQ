using System;

namespace EVE_Central.Model
{
    [Serializable]
    public class marketstat
    {
        private string _buy_avg;

        private string _buy_max;

        private string _buy_min;

        private string _buy_median;

        private string _sell_avg;

        private string _sell_max;

        private string _sell_min;

        private string _sell_median;

        public string buy_avg
        {
            get
            {
                return this._buy_avg;
            }
            set
            {
                this._buy_avg = value;
            }
        }

        public string buy_max
        {
            get
            {
                return this._buy_max;
            }
            set
            {
                this._buy_max = value;
            }
        }

        public string buy_min
        {
            get
            {
                return this._buy_min;
            }
            set
            {
                this._buy_min = value;
            }
        }

        public string buy_median
        {
            get
            {
                return this._buy_median;
            }
            set
            {
                this._buy_median = value;
            }
        }

        public string sell_avg
        {
            get
            {
                return this._sell_avg;
            }
            set
            {
                this._sell_avg = value;
            }
        }

        public string sell_max
        {
            get
            {
                return this._sell_max;
            }
            set
            {
                this._sell_max = value;
            }
        }

        public string sell_min
        {
            get
            {
                return this._sell_min;
            }
            set
            {
                this._sell_min = value;
            }
        }

        public string sell_median
        {
            get
            {
                return this._sell_median;
            }
            set
            {
                this._sell_median = value;
            }
        }
    }
}
