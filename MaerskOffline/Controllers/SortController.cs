using MaerskOffline.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MaerskOffline.Controllers
{
    public class SortController : Controller
    {
        [HttpPost]
        public JsonResult EnqueueJob(string id, string status, string input)
        {
            SortData data = new SortData();
            data.id = id;
            data.status = status;
            data.input = input.Substring(1, input.Length - 2).Split(',').Select(n => Convert.ToInt32(n)).ToList();
            

            SortDataList.dataSet.Add(data);
            Response.StatusCode = 202;
            return Json("Request Accepted Successfully", JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetJob(string id)
        {
            var returnData = SortDataList.dataSet.Where(x => x.id == id);
            return Json(returnData, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetJobs()
        {
            var returnData = SortDataList.dataSet;
            return Json(returnData, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public void DataSortProcessor()
        {
            var pendingData = SortDataList.dataSet.Where(x => x.status == "Pending");
            foreach(SortData item in pendingData)
            {
                DateTime startTime = DateTime.Now;
                item.output = item.input.OrderBy(x => x).ToList();
                item.status = "Completed";
                Thread.Sleep(1000);
                item.duration = (DateTime.Now - startTime).ToString();
            }
        }
    }
}
