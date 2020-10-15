using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaerskOffline.Models
{
    public class SortData
    {
        public string id;
        public String status;
        public string duration;
        public List<int> input;
        public List<int> output;
    }

    public static class SortDataList
    {
        public static List<SortData> dataSet = new List<SortData>();
    }
}