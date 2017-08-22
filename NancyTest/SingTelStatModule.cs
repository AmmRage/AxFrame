//using System;
//using System.Globalization;
//using Nancy;

//namespace NancyTest
//{
//    public class SingTelStatModule : NancyModule
//    {
//        public const string RequestDateFormat = "yyyyMMdd";

//        public SingTelStatModule()
//        {
//            this.Get["/"] = _ => GetJobStatByStat(DateTime.Now.Date);
//            this.Get[@"/(?<date>\d{8})"] = GetJobStatByString;
//        }

//        private dynamic GetJobStatByString(dynamic parameters)
//        {
//            var dateStr = parameters.date;
//            DateTime dt;
//            if (DateTime.TryParseExact(dateStr, RequestDateFormat, CultureInfo.CurrentCulture, DateTimeStyles.None, out dt))
//            {
//                return GetJobStatByStat(dt);
//            }
//            else //Error
//            {
//                return this.View["Error.html"];
//            }
//        }

//        private dynamic GetJobStatByStat(DateTime date)
//        {
//            var model = new ProcessStatModel()
//            {
//                Title = "title",

//                PrevDayStat = "20170720",

//                NextDayStat = "20170722",

//                ProcessInfos = new ProcessInfo[0],
//            };

//            return View["stat.html", model];
//        }
//    }

//    public class ProcessStatModel
//    {

//        public string Title;

//        public string PrevDayStat;

//        public string NextDayStat;

//        public ProcessInfo[] ProcessInfos;
//    }

//    public class ProcessInfo
//    {
//        public int FileNumber;

//        public string JobName;
//        public string Filename;
//        public string Status;
//        public string ProcessDate;
//        public string ProcessTime;
//        public string Remark;

//        public override string ToString()
//        {
//            return this.FileNumber + ", " + this.JobName + ", " + this.Filename + ", " + this.Status + ", " +
//                   this.ProcessTime + ", " + this.Remark;
//        }
//    }
//}