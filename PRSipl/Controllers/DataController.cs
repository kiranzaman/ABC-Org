using System;
using ClosedXML.Excel;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PRSipl.Models;
using PagedList;
using System.IO;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web.Helpers;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;
using LinqToExcel;
using System.Data.Entity.Validation;
using System.Text.RegularExpressions;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Threading.Tasks;
using System.ComponentModel;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PRSipl.Models;
using PagedList;
using System.IO;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;
using OfficeOpenXml.Core.ExcelPackage;

namespace PRSipl.Controllers
{
    public class DataController : Controller
    {
        private Database1Entities1 db = new Database1Entities1();

        // GET: Data
        public ActionResult Index()
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            return View(db.Data.ToList());
        }

        // GET: Data/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Datum datum = db.Data.Find(id);
            if (datum == null)
            {
                return HttpNotFound();
            }
            return View(datum);
        }
        
        // GET: Data/Create
        public ActionResult Create()
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            
            return View();
        }

        // POST: Data/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Serial_Number,Company,Address,City,First_Name,Last_Name,Mobile_Number,Landline,Email,Sector,Lead_Source,Region,Product,Principal,Designation,Date,Expected_Date,Services,Fax,Status, Probability,Duration,Remarks")] Datum datum)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            if (ModelState.IsValid)
            {
                db.Data.Add(datum);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(datum);
        }

        // GET: Data/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Datum datum = db.Data.Find(id);
            if (datum == null)
            {
                return HttpNotFound();
            }
            return View(datum);
        }

        // POST: Data/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Serial_Number, Company, Address, City, First_Name, Last_Name, Mobile_Number, Landline, Email, Sector, Lead_Source, Region, Product, Principal, Designation, Date, Expected_Date, Services, Fax, Status, Probability, Duration, Remarks")] Datum datum)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            if (ModelState.IsValid)
            {
                db.Entry(datum).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(datum);
        }

        // GET: Data/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Datum datum = db.Data.Find(id);
            if (datum == null)
            {
                return HttpNotFound();
            }
            return View(datum);
        }

        // POST: Data/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            Datum datum = db.Data.Find(id);
            db.Data.Remove(datum);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Search(string option, string search, int? pageNumber, string sort)
        {
            ViewBag.SortByCompany = string.IsNullOrEmpty(sort) ? "descending company" : "";
            //if the sort value is gender then we are initializing the value as descending gender  
            ViewBag.SortByProbability = sort == "Probability" ? "descending probability" : "Probability";
            var records = db.Data.AsQueryable();
            if (option == "Company")
            {
                //Index action method will return a view with a student records based on what a user specify the value in textbox  
                records = records.Where(x => x.Company == search || search == null);
            }
            else if (option == "City")
            {
                records = records.Where(x => x.City == search || search == null);
            }
            else if (option == "First Name")
            {
                records = records.Where(x => x.First_Name == search || search == null);
            }
            else if (option == "Last Name")
            {
                records = records.Where(x => x.Last_Name == search || search == null);
            }
            else if (option == "Sector")
            {
                records = db.Data.Where(x => x.Sector == search || search == null);
            }
            else if (option == "Lead Source")
            {
                //Index action method will return a view with a student records based on what a user specify the value in textbox  
                records = db.Data.Where(x => x.Lead_Source == search || search == null);
            }
            else if (option == "Region")
            {
                records = db.Data.Where(x => x.Region == search || search == null);
            }
            else if (option == "Product")
            {
                records = db.Data.Where(x => x.Product == search || search == null);
            }
            else if (option == "Status")
            {
                //Index action method will return a view with a student records based on what a user specify the value in textbox  
                records = db.Data.Where(x => x.Status == search || search == null);
            }
            else if (option == "Probability")
            {
                records = db.Data.Where(x => x.Probability == search || search == null);
            }
            else if (option == "Date")
            {
                records = records.Where(x => x.Date.ToString() == search || search == null);
            }
            else if (option == "Services")
            {
                records = db.Data.Where(x => x.Services == search || search == null);
            }
            else if (option == "Principal")
            {
                records = db.Data.Where(x => x.Principal == search || search == null);
            }
            else
            {
                records = db.Data.Where(x => x.Company.StartsWith(search) || search == null);
            }
            switch (sort)
            {

                case "descending company":
                    records = records.OrderByDescending(x => x.Company);
                    break;

                case "descending probaility":
                    records = records.OrderByDescending(x => x.Probability);
                    break;

                case "Probability":
                    records = records.OrderBy(x => x.Probability);
                    break;

                default:
                    records = records.OrderBy(x => x.City);
                    break;

            }
            return View(records.ToPagedList(pageNumber ?? 1, 1000));

        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //excel thing
        public IQueryable<Datum> GetDataList(int serialnumber)
        {
            var productList = db.Data
                .Where(p => p.Serial_Number == serialnumber)
                .Select(e =>
                    new Datum
                    {
                        Serial_Number = e.Serial_Number,
                        Company = e.Company,
                        Address = e.Address,
                        City = e.City,
                        First_Name = e.First_Name,
                        Last_Name = e.Last_Name,
                        Mobile_Number = e.Mobile_Number,
                        Landline = e.Landline,
                        Email = e.Email,
                        Sector = e.Sector,
                        Lead_Source = e.Lead_Source,
                        Region = e.Region,
                        Product = e.Product,
                        Principal = e.Principal,
                        Designation = e.Designation,
                        Status = e.Status,
                        Date = e.Date,
                        Expected_Date = e.Expected_Date,
                        Duration = e.Duration,

                        Probability = e.Probability,
                        Services = e.Services,
                        Fax = e.Fax,
                        Remarks = e.Remarks
                    })
                .ToList()
                .AsQueryable(); // actually it's not useful after "ToList()" :D

            return productList;
        }
        //public IList<Datum> GetDataList()
        //{
        //    Database1Entities1 db = new Database1Entities1();

        //    List<Datum> dataList = db.Data.Select(e => new Datum
        //    {
        //        Serial_Number = e.Serial_Number,
        //        Company = e.Company,
        //        Address = e.Address,
        //        City = e.City,
        //        First_Name = e.First_Name,
        //        Last_Name = e.Last_Name,
        //        Mobile_Number = e.Mobile_Number,
        //        Landline = e.Landline,
        //        Email = e.Email,
        //        Sector = e.Sector,
        //        Lead_Source = e.Lead_Source,
        //        Region = e.Region,
        //        Product = e.Product,
        //        Principal = e.Principal,
        //        Designation = e.Designation,
        //        Status = e.Status,
        //        Date = e.Date,
        //        Expected_Date = e.Expected_Date,
        //        Duration = e.Duration,

        //        Probability = e.Probability,
        //        Services = e.Services,
        //        Fax = e.Fax,
        //        Remarks = e.Remarks

        //    }).ToList();

        //    return dataList;
        //}
        public void ExportListUsingEPPlus()
        {
            var data = db.Data.ToList();

            OfficeOpenXml.ExcelPackage excel = new OfficeOpenXml.ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("Sheet1");
            workSheet.Cells[1, 1].LoadFromCollection(data, true);
            using (var memoryStream = new MemoryStream())
            {
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;  filename=data.xlsx");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }


        [HttpPost]
        public JsonResult UploadExcel(Datum datum, HttpPostedFileBase FileUpload)
        {

            List<string> data = new List<string>();
            if (FileUpload != null)
            {
                // tdata.ExecuteCommand("truncate table OtherCompanyAssets");  
                if (FileUpload.ContentType == "application/vnd.ms-excel" || FileUpload.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                {

                    Console.WriteLine("sdofjs");
                    string filename = FileUpload.FileName;
                    string targetpath = Server.MapPath("~/Content/");
                    FileUpload.SaveAs(targetpath + filename);
                    string pathToExcelFile = targetpath + filename;
                    var connectionString = "";
                    if (filename.EndsWith(".xls"))
                    {
                        connectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0; data source={0}; Extended Properties=Excel 8.0;", pathToExcelFile);
                    }
                    else if (filename.EndsWith(".xlsx"))
                    {
                        connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\";", pathToExcelFile);
                    }

                    var adapter = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", connectionString);
                    var ds = new DataSet();

                    adapter.Fill(ds, "ExcelTable");

                    DataTable dtable = ds.Tables["ExcelTable"];

                    string sheetName = "Sheet1";

                    var excelFile = new ExcelQueryFactory(pathToExcelFile);
                    var artistAlbums = from a in excelFile.Worksheet<Datum>(sheetName) select a;

                    foreach (var a in artistAlbums)
                    {
                        try
                        {
                            if (a.Company != "" && a.Address != "" && a.City != "" && a.First_Name != "" && a.Last_Name != "")
                            {

                                Datum TU = new Datum();
                                TU.Company = a.Company;
                                TU.Address = a.Address;
                                TU.City = a.City;
                                TU.First_Name = a.First_Name;
                                TU.Last_Name = a.Last_Name;
                                TU.Mobile_Number = a.Mobile_Number;
                                TU.Landline = a.Landline;
                                TU.Email = a.Email;
                                TU.Sector = a.Sector;
                                TU.Lead_Source = a.Lead_Source;
                                TU.Region = a.Region;
                                TU.Product = a.Product;
                                TU.Principal = a.Principal;
                                TU.Designation = a.Designation;
                                TU.Status = a.Status;
                                TU.Date = a.Date;
                                TU.Expected_Date = a.Expected_Date;
                                TU.Duration = a.Duration;
                                TU.Probability = a.Probability;
                                TU.Services = a.Services;
                                TU.Fax = a.Fax;
                                TU.Remarks = a.Remarks;
                                db.Data.Add(TU);

                                db.SaveChanges();
                                Response.Write("in try =>");


                            }
                            else
                            {
                                data.Add("<ul>");
                                if (a.Company == "" || a.Company == null) data.Add("<li> Company is required</li>");
                                if (a.Address == "" || a.Address == null) data.Add("<li> Address is required</li>");
                                if (a.City == "" || a.City == null) data.Add("<li>City is required</li>");
                                if (a.First_Name == "" || a.First_Name == null) data.Add("<li> First Name is required</li>");
                                if (a.Last_Name == "" || a.Last_Name == null) data.Add("<li> Last Name is required</li>");
                                if (a.Email == "" || a.Email == null) data.Add("<li>Email is required</li>");
                                data.Add("</ul>");
                                data.ToArray();
                                return Json(data, JsonRequestBehavior.AllowGet);
                            }
                        }

                        catch (DbEntityValidationException ex)
                        {
                            Response.Write("in Catch =>");
                            foreach (var entityValidationErrors in ex.EntityValidationErrors)
                            {

                                foreach (var validationError in entityValidationErrors.ValidationErrors)
                                {

                                    Response.Write("QProperty: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);

                                }

                            }
                        }
                    }
                    //deleting excel file from folder  
                    if ((System.IO.File.Exists(pathToExcelFile)))
                    {
                        System.IO.File.Delete(pathToExcelFile);
                    }
                    return Json("success", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    //alert message for invalid file format  
                    data.Add("<ul>");
                    data.Add("<li>Only Excel file format is allowed</li>");
                    data.Add("</ul>");
                    data.ToArray();
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                data.Add("<ul>");
                if (FileUpload == null) data.Add("<li>Please choose Excel file</li>");
                data.Add("</ul>");
                data.ToArray();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }



    }
}
