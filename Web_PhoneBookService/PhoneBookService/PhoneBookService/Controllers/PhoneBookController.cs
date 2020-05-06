using System;
using PhoneBookService.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.WebPages;

namespace PhoneBookService.Controllers
{
    public class PhoneBookController : Controller
    {
        public ActionResult PhoneBookIndex()
        {
            PhonebookSQLConnector phoneBookSQLConnector = new PhonebookSQLConnector();
            List<RecordDataObject> listRecords;
            listRecords = phoneBookSQLConnector.GetListAllRecord();

            ViewBag.ListOfRecord = listRecords;

            return View(listRecords);
        }

        public ActionResult AddPhoneBookRecord()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "zza01,zza02,zza03,zza04,zza06,zza07,zza05,zza08,zza09 ")] RecordDataObject recordDataObject)
        {
            PhonebookSQLConnector phoneBookSQLConnector = new PhonebookSQLConnector();
            List<RecordDataObject> listRecords;
            listRecords = phoneBookSQLConnector.GetListAllRecord();



            String result = phoneBookSQLConnector.InsertPostData(recordDataObject);

            return RedirectToAction("PhoneBookIndex", "PhoneBook");
        }//Create

        public ActionResult DeletePost(String postID)
        {
            String sqlCriteria = "zza01 LIKE '%" + postID + "%' ";

            PhonebookSQLConnector phoneBookSQLConnector = new PhonebookSQLConnector();
            List<RecordDataObject> listRecords;
            listRecords = phoneBookSQLConnector.GetListAllRecordOnDemand(sqlCriteria);
            ViewBag.ListOfRecord = listRecords;
            return View("ConfirmDelete", listRecords);
        }//End of DeletePost

        [HttpPost, ActionName("ConfirmedDelete")]
        public ActionResult ConfirmedDeletePost(String postID)
        {
            PhonebookSQLConnector phoneBookSQLConnector = new PhonebookSQLConnector();
            List<RecordDataObject> listRecords = new List<RecordDataObject>();
            String result = phoneBookSQLConnector.ConfirmedDelete(postID);
            if (result == "SUCCESS")
            {
                listRecords = phoneBookSQLConnector.GetListAllRecord();
            }
            ViewBag.ListOfRecord = listRecords;

            return RedirectToAction("PhoneBookIndex", "PhoneBook");
        }// End of ConfirmedDeletePost

        public ActionResult EditPhoneBookRecord(String postID)
        {
            PhonebookSQLConnector phoneBookSQLConnector = new PhonebookSQLConnector();
            List<RecordDataObject> listRecords;
            RecordDataObject recordDataObjectForEdit;
            String sqlCriteria = "zza01 = '" + postID + "'";

            listRecords = phoneBookSQLConnector.GetListAllRecordOnDemand(sqlCriteria);

            recordDataObjectForEdit = listRecords[0];

            ViewBag.RecordDataForEdit = recordDataObjectForEdit;

            return View("EditPhoneBookRecord", recordDataObjectForEdit);
        }


        [HttpPost, ActionName("ConfirmedEdit")]
        public ActionResult UpdatePost([Bind(Include = "zza01,zza02,zza03,zza04,zza06,zza07,zza05,zza08,zza09 ")] RecordDataObject recordDataObject)
        {
            PhonebookSQLConnector phoneBookSQLConnector = new PhonebookSQLConnector();


            String result = phoneBookSQLConnector.ConfirmedEdit(recordDataObject);
            List<RecordDataObject> listRecords = new List<RecordDataObject>();
            if (result == "SUCCESS")
            {
                listRecords = phoneBookSQLConnector.GetListAllRecord();
            }

            ViewBag.ListOfRecord = listRecords;
            return RedirectToAction("PhoneBookIndex", "PhoneBook");
        }
    }
}