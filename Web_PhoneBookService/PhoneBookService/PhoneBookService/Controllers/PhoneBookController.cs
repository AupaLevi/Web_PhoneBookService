using System;
using PhoneBookService.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.WebPages;
using System.IO;
using System.Linq;

namespace PhoneBookService.Controllers
{
    public class PhoneBookController : Controller
    {

        public ActionResult PhoneBookIndex()
        {
            PhonebookSQLConnector phoneBookSQLConnector = new PhonebookSQLConnector();
            //PageBean pageBean = new PageBean();
            List<RecordDataObject> listRecords;
            List<PageBean> pageNumberList;
            //listRecords = phoneBookSQLConnector.GetListAllRecord();
            int pageTotalCount = phoneBookSQLConnector.GetTotalCount();
            //ViewBag.ListOfRecord = listRecords;

            PageOperation pageOperation = new PageOperation(pageTotalCount);
            int currentPage = 1;
            pageNumberList = pageOperation.GetPageNumberList();
            int pageCount = pageOperation.GetPageCount();
            int startPageNum = pageOperation.GetStartNumber(currentPage);
            int endPageNum = pageOperation.GetEndNumber();
            int previousPageNumber = 1;
            int nextPageNumber = previousPageNumber + 1;
            listRecords = phoneBookSQLConnector.GetLimitPostsList("0", "10");

            RecordDataViewModel recordDataViewModel = new RecordDataViewModel();
            recordDataViewModel.RecordDataList = listRecords;
            recordDataViewModel.PageNumberList = pageNumberList;
            recordDataViewModel.PageCount = pageCount;
            recordDataViewModel.CurrentPage = currentPage;
            recordDataViewModel.StrPageNum = startPageNum;
            recordDataViewModel.EndPageNum = endPageNum;
            recordDataViewModel.PreviousPageNumber = previousPageNumber;
            recordDataViewModel.NextPageNumber = nextPageNumber;
            recordDataViewModel.FirstPage = true;
            recordDataViewModel.LastPage = false;

            recordDataViewModel.SelectListItems = phoneBookSQLConnector.getJobItem();

            return View(recordDataViewModel);
        }

        public ActionResult ToPage(String postID)
        {
            PhonebookSQLConnector phoneBookSQLConnector = new PhonebookSQLConnector();
            //PageBean pageBean = new PageBean();
            List<RecordDataObject> listRecords;
            List<PageBean> pageNumberList;
            //listPosts = sqlServerConnector.GetPostsList();
            int pageTotalCount = phoneBookSQLConnector.GetTotalCount();

            PageOperation pageOperation = new PageOperation(pageTotalCount);
            int currentPage = int.Parse(postID);
            pageNumberList = pageOperation.GetPageNumberList();
            int pageCount = pageOperation.GetPageCount();
            int startPageNum = pageOperation.GetStartNumber(currentPage);
            int endPageNum = pageOperation.GetEndNumber();
            int previousPageNumber = 1;
            int nextPageNumber = previousPageNumber + int.Parse(postID);
            if (currentPage == 1)
            {
                startPageNum = 0;
            }
            listRecords = phoneBookSQLConnector.GetLimitPostsList(startPageNum.ToString(), "10");

            RecordDataViewModel recordDataViewModel = new RecordDataViewModel();
            recordDataViewModel.RecordDataList = listRecords;
            recordDataViewModel.PageNumberList = pageNumberList;
            recordDataViewModel.PageCount = pageCount;
            recordDataViewModel.CurrentPage = currentPage;
            recordDataViewModel.StrPageNum = startPageNum;
            recordDataViewModel.EndPageNum = endPageNum;
            recordDataViewModel.PreviousPageNumber = previousPageNumber;
            recordDataViewModel.NextPageNumber = nextPageNumber;
            if (startPageNum == 0)
            {
                recordDataViewModel.FirstPage = true;
            }
            else
            {
                recordDataViewModel.FirstPage = false;
            }
            if (currentPage == pageNumberList.Count)
            {
                recordDataViewModel.LastPage = true;
            }
            else
            {
                recordDataViewModel.LastPage = false;
            }


            TempData["recordDataViewModel"] = recordDataViewModel;

            return Redirect("BackToPhoneBookIndex");
        }

        public ActionResult BackToPhoneBookIndex()
        {
            RecordDataViewModel recordDataViewModel = (RecordDataViewModel)TempData["recordDataViewModel"];
            return View("PhoneBookIndex", recordDataViewModel);
        }

        public ActionResult AddPhoneBookRecord()
        {
            PhonebookSQLConnector phoneBookSQLConnector = new PhonebookSQLConnector();
            RecordDataViewModel recordDataViewModel = new RecordDataViewModel();
            recordDataViewModel.SelectListItems = phoneBookSQLConnector.getJobItem();
            return View(recordDataViewModel);
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "zza01,zza02,zza03,zza04,zza06,zza07,zza05,zza08,zza09 ")] RecordDataObject recordDataObject)
        {
            PhonebookSQLConnector phoneBookSQLConnector = new PhonebookSQLConnector();
            //List<RecordDataObject> listRecords;
            //listRecords = phoneBookSQLConnector.GetListAllRecord();

            RecordDataViewModel recordDataViewModel = new RecordDataViewModel();
            recordDataViewModel.SelectListItems = phoneBookSQLConnector.getJobItem();

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
            RecordDataViewModel recordDataViewModel = new RecordDataViewModel();
            recordDataViewModel.SelectListItems = phoneBookSQLConnector.getJobItem();
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