using System;
using System.Collections.Generic;
using System.Text;

namespace Proxy
{
    public class ReturnHistoryModel
    {
        public DateTime SoldDate { get; set; }
        public string LastOdoMeter { get; set; }
        public string ImagePath { get; set; }
        public bool HadAccident { get; set; }

    }
}
