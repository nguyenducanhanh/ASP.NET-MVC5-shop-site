using BAITAPLON.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BAITAPLON.Areas.Admin.Data
{
    public class tk
    {
        public static List<tksp> tksp = new List<tksp>();
        public static List<tkdt> tkdt = new List<tkdt>();
        public static int ktk=0;
    }
    public class tksp
    {
        public int id;
        public string tensp;
        public int sl;
    }
    public class tkdt
    {
        public int id;
        public Decimal gia;
    }
}