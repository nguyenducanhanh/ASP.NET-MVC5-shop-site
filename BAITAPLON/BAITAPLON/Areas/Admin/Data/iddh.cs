using BAITAPLON.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BAITAPLON.Areas.Admin.Data
{
    public class iddh
    {
        public static int id=1;
        public static List<ctdh> ct= new List<ctdh>();
    }
    public class ctdh
    {
        public int id;
        public int sl;
        public Decimal gia;
    }
}