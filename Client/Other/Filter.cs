using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Other
{
    public class Filter
    {
        private String _Name;
        private String _ColumnToApplie;
        private filterOption _Option;
        private String _Text;
        private bool CaseSensetive, _isDisabled = false;

        public String Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        
        public String ToApply
        {
            get { return _ColumnToApplie; }
            set { _ColumnToApplie = value; }
        }

        public filterOption filterOption
        {
            get { return _Option; }
            set { _Option = value; }
        }

        public String Text
        {
            get { return _Text; }
            set { _Text = value; }
        }

        public bool isCaseSenestive
        {
            get { return CaseSensetive; }
            set { CaseSensetive = value; }
        }

        public bool isDisabled
        {
            get { return _isDisabled; }
            set { _isDisabled = value; }
        }

    }

    public enum filterOption
    {
        Include, Exclude
    }
}
