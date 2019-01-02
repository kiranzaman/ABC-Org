using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PRSipl.Models;

namespace PRSipl.Controllers
{

    public class ReportsController : Controller
    {
        public int data()
        {
            String m = Request["month"];
            //Debug.WriteLine(m);
            int mon = 0;
            if (m == "January")
                mon = 01;
            else if (m == "February")
                mon = 02;
            else if (m == "March")
                mon = 03;
            else if (m == "April")
                mon = 04;
            else if (m == "May")
                mon = 05;
            else if (m == "June")
                mon = 06;
            else if (m == "July")
                mon = 07;
            else if (m == "August")
                mon = 08;
            else if (m == "September")
                mon = 09;
            else if (m == "October")
                mon = 10;
            else if (m == "November")
                mon = 11;
            else if (m == "December")
                mon = 12;
            return mon;
        }
        public int[] getData(int mon, String y, String r)
        {
            Database1Entities1 db = new Database1Entities1();
            int c1 = 0, c2 = 0, c3 = 0, c4 = 0, c5 = 0, c6 = 0, c7 = 0, c8 = 0;

            var records = db.Data.Where(x => x.Date.Value.Month == mon && x.Date.Value.Year.ToString().Equals(y) && x.Region.Equals(r) && x.Probability.Equals("0%")).Select(x => x);

            c1 = records.Count();
            records = db.Data.Where(x => x.Date.Value.Month == mon && x.Date.Value.Year.ToString().Equals(y) && x.Region.Equals(r) && x.Probability.Equals("10%")).Select(x => x);
            c2 = records.Count();
            records = db.Data.Where(x => x.Date.Value.Month == mon && x.Date.Value.Year.ToString().Equals(y) && x.Region.Equals(r) && x.Probability.Equals("50%")).Select(x => x);
            c3 = records.Count();
            records = db.Data.Where(x => x.Date.Value.Month == mon && x.Date.Value.Year.ToString().Equals(y) && x.Region.Equals(r) && x.Probability.Equals("70%")).Select(x => x);
            c4 = records.Count();
            records = db.Data.Where(x => x.Date.Value.Month == mon && x.Date.Value.Year.ToString().Equals(y) && x.Region.Equals(r) && x.Probability.Equals("90%")).Select(x => x);
            c5 = records.Count();
            records = db.Data.Where(x => x.Date.Value.Month == mon && x.Date.Value.Year.ToString().Equals(y) && x.Region.Equals(r) && x.Probability.Equals("100%")).Select(x => x);
            c6 = records.Count();
            records = db.Data.Where(x => x.Date.Value.Month == mon && x.Date.Value.Year.ToString().Equals(y) && x.Region.Equals(r) && x.Probability.Equals("110%")).Select(x => x);
            c7 = records.Count();
            records = db.Data.Where(x => x.Date.Value.Month == mon && x.Date.Value.Year.ToString().Equals(y) && x.Region.Equals(r) && x.Probability.Equals("120%")).Select(x => x);
            c8 = records.Count();
            int[] values = { c1, c2, c3, c4, c5, c6, c7, c8 };
            return values;
        }
        //get data for annual report
        public int[] getData(String y, String r)
        {
            Debug.WriteLine("do wla cllh rha");
            Database1Entities1 db = new Database1Entities1();
            int c1 = 0, c2 = 0, c3 = 0, c4 = 0, c5 = 0, c6 = 0, c7 = 0, c8 = 0;

            var records = db.Data.Where(x => x.Date.Value.Year.ToString().Equals(y) && x.Region.Equals(r) && x.Probability.Equals("0%")).Select(x => x);

            c1 = records.Count();
            records = db.Data.Where(x => x.Date.Value.Year.ToString().Equals(y) && x.Region.Equals(r) && x.Probability.Equals("10%")).Select(x => x);
            c2 = records.Count();
            records = db.Data.Where(x => x.Date.Value.Year.ToString().Equals(y) && x.Region.Equals(r) && x.Probability.Equals("50%")).Select(x => x);
            c3 = records.Count();
            records = db.Data.Where(x => x.Date.Value.Year.ToString().Equals(y) && x.Region.Equals(r) && x.Probability.Equals("70%")).Select(x => x);
            c4 = records.Count();
            records = db.Data.Where(x => x.Date.Value.Year.ToString().Equals(y) && x.Region.Equals(r) && x.Probability.Equals("90%")).Select(x => x);
            c5 = records.Count();
            records = db.Data.Where(x => x.Date.Value.Year.ToString().Equals(y) && x.Region.Equals(r) && x.Probability.Equals("100%")).Select(x => x);
            c6 = records.Count();
            records = db.Data.Where(x => x.Date.Value.Year.ToString().Equals(y) && x.Region.Equals(r) && x.Probability.Equals("110%")).Select(x => x);
            c7 = records.Count();
            records = db.Data.Where(x => x.Date.Value.Year.ToString().Equals(y) && x.Region.Equals(r) && x.Probability.Equals("120%")).Select(x => x);
            c8 = records.Count();
            int[] values = { c1, c2, c3, c4, c5, c6, c7, c8 };
            Debug.WriteLine("fghgfhfghdfghdhh" + c1 + c2 + c3 + c4);
            Debug.WriteLine(values);
            return values;
        }
        //summary data
        public int[] getData(String r)
        {
            Database1Entities1 db = new Database1Entities1();
            int c1 = 0, c2 = 0, c3 = 0, c4 = 0, c5 = 0, c6 = 0, c7 = 0, c8 = 0;

            var records = db.Data.Where(x => x.Region.Equals(r) && x.Probability.Equals("0%")).Select(x => x);

            c1 = records.Count();
            records = db.Data.Where(x => x.Region.Equals(r) && x.Probability.Equals("10%")).Select(x => x);
            c2 = records.Count();
            records = db.Data.Where(x => x.Region.Equals(r) && x.Probability.Equals("50%")).Select(x => x);
            c3 = records.Count();
            records = db.Data.Where(x => x.Region.Equals(r) && x.Probability.Equals("70%")).Select(x => x);
            c4 = records.Count();
            records = db.Data.Where(x => x.Region.Equals(r) && x.Probability.Equals("90%")).Select(x => x);
            c5 = records.Count();
            records = db.Data.Where(x => x.Region.Equals(r) && x.Probability.Equals("100%")).Select(x => x);
            c6 = records.Count();
            records = db.Data.Where(x => x.Region.Equals(r) && x.Probability.Equals("110%")).Select(x => x);
            c7 = records.Count();
            records = db.Data.Where(x => x.Region.Equals(r) && x.Probability.Equals("120%")).Select(x => x);
            c8 = records.Count();
            int[] values = { c1, c2, c3, c4, c5, c6, c7, c8 };
            return values;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PrincipalReport(String id1)
        {
            ViewBag.identity = id1;
            if (id1 == "1")
            {
                using (Database1Entities1 db = new Database1Entities1())
                {
                    String m = Request["month"];
                    String y = Request["year"];
                    String principal = Request["principal"];
                    int mon = data();
                    var records = db.Data.AsQueryable();
                    records = records.Where(x => x.Date.Value.Month == mon && x.Date.Value.Year.ToString() == y && x.Principal == principal);
                    var v = records.ToList();
                    return View(v);
                }
            }
            else if (id1 == "2")
            {
                using (Database1Entities1 db = new Database1Entities1())
                {
                    String y = Request["year"];
                    String principal = Request["principal"];
                    int mon = data();
                    var records = db.Data.AsQueryable();
                    records = records.Where(x =>x.Date.Value.Year.ToString() == y && x.Principal == principal);
                    var v = records.ToList();
                    return View(v);
                }
            }
            else if (id1 == "3")
            {
                using (Database1Entities1 db = new Database1Entities1())
                {
                    String principal = Request["principal"];
                    int mon = data();
                    var records = db.Data.AsQueryable();
                    records = records.Where(x =>x.Principal == principal);
                    var v = records.ToList();
                    return View(v);
                }
            }
            else
            {
                return View();
            }
        }

        public ActionResult LeadSource(string id1)
        {
            ViewBag.identity = id1;
            if (id1 == "1")
            {
                using (Database1Entities1 db = new Database1Entities1())
                {
                    String m = Request["month"];
                    String y = Request["year"];
                    String ls = Request["leadsource"];
                    int mon = data();
                    var records = db.Data.AsQueryable();
                    records = records.Where(x => x.Date.Value.Month == mon && x.Date.Value.Year.ToString() == y && x.Lead_Source == ls);
                    var v = records.ToList();
                    return View(v);
                }
            }
            else if (id1 == "2")
            {
                using (Database1Entities1 db = new Database1Entities1())
                {
                    String ls = Request["leadsource"];
                    String y = Request["year"];
                    var records = db.Data.AsQueryable();
                    records = records.Where(x =>x.Date.Value.Year.ToString() == y&& x.Lead_Source == ls);
                    var v = records.ToList();
                    return View(v);
                }
            }
            else if (id1 == "3")
            {
                using (Database1Entities1 db = new Database1Entities1())
                {
                    String ls = Request["leadsource"];
                    var records = db.Data.AsQueryable();
                    records = records.Where(x =>x.Lead_Source == ls);
                    var v = records.ToList();
                    return View(v);
                }
            }
            else
            {
                return View();
            }
           }
        public ActionResult Company(String id1)
        {
            ViewBag.identity = id1;
            if (id1 == "1")
            {
                using (Database1Entities1 db = new Database1Entities1())
                {
                    String m = Request["month"];
                    String y = Request["year"];
                    String c = Request["company"];
                    int mon = data();
                    var records = db.Data.AsQueryable();
                    records = records.Where(x => x.Date.Value.Month == mon && x.Date.Value.Year.ToString() == y && x.Company == c);
                    var v = records.ToList();
                    return View(v);
                }
            }
            else if (id1 == "2")
            {
                using (Database1Entities1 db = new Database1Entities1())
                {
                    String c = Request["compnay"];
                    String y = Request["year"];
                    var records = db.Data.AsQueryable();
                    records = records.Where(x => x.Date.Value.Year.ToString() == y && x.Company == c);
                    var v = records.ToList();
                    return View(v);
                }
            }
            else if (id1 == "3")
            {
                using (Database1Entities1 db = new Database1Entities1())
                {
                    String c = Request["company"];
                    var records = db.Data.AsQueryable();
                    records = records.Where(x => x.Company == c);
                    var v = records.ToList();
                    return View(v);
                }
            }
            else
            {
                return View();
            }

        }
        public ActionResult City(string id1)
        {
            ViewBag.identity = id1;
            if (id1 == "1")
            {
                using (Database1Entities1 db = new Database1Entities1())
                {
                    String m = Request["month"];
                    String y = Request["year"];
                    String city = Request["city"];
                    int mon = data();
                    var records = db.Data.AsQueryable();
                    records = records.Where(x => x.Date.Value.Month == mon && x.Date.Value.Year.ToString() == y && x.City == city);
                    var v = records.ToList();
                    return View(v);
                }
            }
            else if (id1 == "2")
            {
                using (Database1Entities1 db = new Database1Entities1())
                {
                    String city = Request["city"];
                    String y = Request["year"];
                    int mon = data();
                    var records = db.Data.AsQueryable();
                    records = records.Where(x =>x.Date.Value.Year.ToString() == y && x.City == city);
                    var v = records.ToList();
                    return View(v);
                }
            }
            else if (id1 == "3")
            {
                using (Database1Entities1 db = new Database1Entities1())
                {
                    String city = Request["city"];
                    var records = db.Data.AsQueryable();
                    records = records.Where(x => x.City == city);
                    var v = records.ToList();
                    return View(v);
                }
            }
            else
            {
                return View();
            }

        }
        public ActionResult Name(string id1 )
        {
            ViewBag.identity = id1;
            if (id1 == "1")
            {
                using (Database1Entities1 db = new Database1Entities1())
                {
                    String m = Request["month"];
                    String y = Request["year"];
                    String firstname = Request["firstname"];
                    String lastname = Request["lastname"];
                    int mon = data();
                    var records = db.Data.AsQueryable();
                    records = records.Where(x => x.Date.Value.Month == mon && x.Date.Value.Year.ToString() == y && x.First_Name == firstname && x.Last_Name == lastname);
                    var v = records.ToList();
                    return View(v);
                }
            }
            else if (id1 == "2")
            {
                using (Database1Entities1 db = new Database1Entities1())
                {
                    String y = Request["year"];
                    String firstname = Request["firstname"];
                    String lastname = Request["lastname"];
                    int mon = data();
                    var records = db.Data.AsQueryable();
                    records = records.Where(x => x.Date.Value.Year.ToString() == y && x.First_Name == firstname && x.Last_Name == lastname);
                    var v = records.ToList();
                    return View(v);
                }
            }
            else if (id1 == "3")
            {
                using (Database1Entities1 db = new Database1Entities1())
                {
                    String firstname = Request["firstname"];
                    String lastname = Request["lastname"];
                    int mon = data();
                    var records = db.Data.AsQueryable();
                    records = records.Where(x =>x.First_Name == firstname && x.Last_Name == lastname);
                    var v = records.ToList();
                    return View(v);
                }
            }
            else
            {
                return View();
            }
        }
        public ActionResult Sector(String id1)
        {
            ViewBag.identity = id1;
            if (id1 == "1")
            {
                using (Database1Entities1 db = new Database1Entities1())
                {
                    String m = Request["month"];
                    String y = Request["year"];
                    String sector = Request["sector"];
                    int mon = data();
                    var records = db.Data.AsQueryable();
                    records = records.Where(x => x.Date.Value.Month == mon && x.Date.Value.Year.ToString() == y && x.Sector == sector);
                    var v = records.ToList();
                    return View(v);
                }
            }
            else if (id1 == "2")
            {
                using (Database1Entities1 db = new Database1Entities1())
                {
                    String sector = Request["sector"];
                    String y = Request["year"];
                    var records = db.Data.AsQueryable();
                    records = records.Where(x => x.Date.Value.Year.ToString() == y && x.Sector == sector);
                    var v = records.ToList();
                    return View(v);
                }
            }
            else if (id1 == "3")
            {
                using (Database1Entities1 db = new Database1Entities1())
                {
                    String sector = Request["sector"];
                    var records = db.Data.AsQueryable();
                    records = records.Where(x => x.Sector == sector);
                    var v = records.ToList();
                    return View(v);
                }
            }
            else
            {
                return View();
            }

        }
        public ActionResult Product(String id1)
        {
            ViewBag.identity = id1;
            if (id1 == "1")
            {
                using (Database1Entities1 db = new Database1Entities1())
                {
                    String m = Request["month"];
                    String y = Request["year"];
                    String product = Request["product"];
                    int mon = data();
                    var records = db.Data.AsQueryable();
                    records = records.Where(x => x.Date.Value.Month == mon && x.Date.Value.Year.ToString() == y && x.Product == product);
                    var v = records.ToList();
                    return View(v);
                }
            }
            else if (id1 == "2")
            {
                using (Database1Entities1 db = new Database1Entities1())
                {
                    String product = Request["product"];
                    String y = Request["year"];
                    var records = db.Data.AsQueryable();
                    records = records.Where(x => x.Date.Value.Year.ToString() == y && x.Product == product);
                    var v = records.ToList();
                    return View(v);
                }
            }
            else if (id1 == "3")
            {
                using (Database1Entities1 db = new Database1Entities1())
                {
                    String product = Request["product"];
                    var records = db.Data.AsQueryable();
                    records = records.Where(x => x.Product == product);
                    var v = records.ToList();
                    return View(v);
                }
            }
            else
            {
                return View();
            }


        }
        public ActionResult Region(string id)
        {
            ViewBag.identity = id;
            return View();
        }
        public ActionResult RegionalReport(string id1)
        {
            if (id1 == "1")
            {
                using (Database1Entities1 db = new Database1Entities1())
                {
                    String m = Request["month"];
                    String y = Request["year"];
                    String r = Request["region"];
                    ViewBag.regionname = r;
                    int mon = data();
                    if (r.Equals("South"))
                    {
                        int[] values = getData(mon, y, r);
                        ViewBag.values = values;
                        return View();

                    }
                    else if (r.Equals("South_West"))
                    {
                        int[] values = getData(mon, y, r);
                        ViewBag.values = values;
                        return View();
                    }
                    else if (r.Equals("North"))
                    {
                        int[] values = getData(mon, y, r);
                        ViewBag.values = values;
                        return View();
                    }
                    else if (r.Equals("Central"))
                    {
                        int[] values = getData(mon, y, r);
                        ViewBag.values = values;
                        return View();
                    }
                    else
                    {
                        return View();
                    }
                }

            }
            else if (id1 == "2")
            {
                using (Database1Entities1 db = new Database1Entities1())
                {
                    String y = Request["year"];

                    String r = Request["region"];
                    ViewBag.regionname = r;
                    if (r.Equals("South"))
                    {
                        int[] values = getData(y, r);
                        ViewBag.values = values;
                        return View();

                    }
                    else if (r.Equals("South_West"))
                    {
                        int[] values = getData(y, r);
                        ViewBag.values = values;
                        return View();
                    }
                    else if (r.Equals("North"))
                    {
                        int[] values = getData(y, r);
                        ViewBag.values = values;
                        return View();
                    }
                    else if (r.Equals("Central"))
                    {
                        int[] values = getData(y, r);
                        ViewBag.values = values;
                        return View();
                    }
                    else
                    {
                        return View();
                    }
                }
            }
            else if (id1 == "3")
            {
                using (Database1Entities1 db = new Database1Entities1())
                {
                    String r = Request["region"];
                    ViewBag.regionname = r;
                    if (r.Equals("South"))
                    {
                        int[] values = getData(r);
                        ViewBag.values = values;
                        return View();

                    }
                    else if (r.Equals("South_West"))
                    {
                        int[] values = getData(r);
                        ViewBag.values = values;
                        return View();
                    }
                    else if (r.Equals("North"))
                    {
                        int[] values = getData(r);
                        ViewBag.values = values;
                        return View();
                    }
                    else if (r.Equals("Central"))
                    {
                        int[] values = getData(r);
                        ViewBag.values = values;
                        return View();
                    }
                    else
                    {
                        return View();
                    }
                }
            }
            else
            {
                return View();
            }
        }
    }
}