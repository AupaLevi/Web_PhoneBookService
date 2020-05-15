using AupaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AupaWeb.Controllers
{
    public class PhonebookController : Controller
    {
        // GET: Phonebook
        public ActionResult PhoneBookSearch()
        {
            PhoneBookSQLConnector phoneBookSQLConnector = new PhoneBookSQLConnector();
            PhoneBookViewModel phoneBookViewModel = new PhoneBookViewModel();
            phoneBookViewModel.SelectListItems = phoneBookSQLConnector.getOfficeItem();

            return View(phoneBookViewModel);
        }

        [HttpPost, ActionName("SearchPhoneBook")]
        [MultiButton("Search")]
        public ActionResult Search(PhoneBookViewModel viewModel)
        {
            string sqlWhereString;
            string sqlAndString;
            if (viewModel.ColValue == "" || viewModel.ColValue == null)
            {
                sqlWhereString = " 1= 1";
            }
            else
            {
                sqlWhereString = "zza04 LIKE '%" + viewModel.ColValue + "%' ";
            }
            if (viewModel.Zza06 == "" || viewModel.Zza06 == null)
            {
                sqlAndString = "";
            }
            else
            {
                sqlAndString = " zza06 = '" + viewModel.Zza06 + "' ";
            }



            PhoneBookSQLConnector phoneBookSQLConnector = new PhoneBookSQLConnector();

            PhoneBookViewModel phoneBookViewModel = new PhoneBookViewModel();
            phoneBookViewModel.UserBasicDataList = phoneBookSQLConnector.GetUserBasicDataByCriteria(sqlWhereString, sqlAndString);
            phoneBookViewModel.SelectListItems = phoneBookSQLConnector.getOfficeItem();

            TempData["phoneBookViewModel"] = phoneBookViewModel;

            return Redirect("BackToPhoneBookSearch"); 
        }

        [HttpPost, ActionName("SearchPhoneBook")]
        [MultiButton("Audit")]
        public ActionResult Audit(PhoneBookViewModel viewModel)
        {
            string sqlWhereString;
            string sqlAndString;

            if (viewModel.ColValue == "" || viewModel.ColValue == null)
            {
                sqlWhereString = " zza06 LIKE '%" + viewModel.Zza06 + "010000 ' ";
            }
            else
            {
                sqlWhereString = "zza04 LIKE '%" + viewModel.ColValue + "%' ";

            }
            if (viewModel.Zza06 == "" || viewModel.Zza06 == null)
            {
                sqlAndString = "";
            }
            else
            {
                sqlAndString = " zza06 = '" + viewModel.Zza06 + "' ";
            }



            PhoneBookSQLConnector phoneBookSQLConnector = new PhoneBookSQLConnector();

            PhoneBookViewModel phoneBookViewModel = new PhoneBookViewModel();
            phoneBookViewModel.UserBasicDataList = phoneBookSQLConnector.GetUserBasicDataByCriteria(sqlWhereString, sqlAndString);
            phoneBookViewModel.SelectListItems = phoneBookSQLConnector.getOfficeItem();

            TempData["phoneBookViewModel"] = phoneBookViewModel;

            return Redirect("BackToPhoneBookSearch");
        }

        [HttpPost, ActionName("SearchPhoneBook")]
        [MultiButton("TDD")]
        public ActionResult TDD(PhoneBookViewModel viewModel)
        {
            string sqlWhereString;
            string sqlAndString;

            if (viewModel.ColValue == "" || viewModel.ColValue == null)
            {
                sqlWhereString = " zza06 LIKE '%" + viewModel.Zza06 + "310000 ' ";
            }
            else
            {
                sqlWhereString = "zza04 LIKE '%" + viewModel.ColValue + "%' ";

            }
            if (viewModel.Zza06 == "" || viewModel.Zza06 == null)
            {
                sqlAndString = "";
            }
            else
            {
                sqlAndString = " zza06 = '" + viewModel.Zza06 + "' ";
            }



            PhoneBookSQLConnector phoneBookSQLConnector = new PhoneBookSQLConnector();

            PhoneBookViewModel phoneBookViewModel = new PhoneBookViewModel();
            phoneBookViewModel.UserBasicDataList = phoneBookSQLConnector.GetUserBasicDataByCriteria(sqlWhereString, sqlAndString);
            phoneBookViewModel.SelectListItems = phoneBookSQLConnector.getOfficeItem();

            TempData["phoneBookViewModel"] = phoneBookViewModel;

            return Redirect("BackToPhoneBookSearch");
        }

        [HttpPost, ActionName("SearchPhoneBook")]
        [MultiButton("TD")]
        public ActionResult TD(PhoneBookViewModel viewModel)
        {
            string sqlWhereString;
            string sqlAndString;

            if (viewModel.ColValue == "" || viewModel.ColValue == null)
            {
                sqlWhereString = " zza06 LIKE '%" + viewModel.Zza06 + "310100' ";
            }
            else
            {
                sqlWhereString = "zza04 LIKE '%" + viewModel.ColValue + "%' ";

            }
            if (viewModel.Zza06 == "" || viewModel.Zza06 == null)
            {
                sqlAndString = "";
            }
            else
            {
                sqlAndString = " zza06 = '" + viewModel.Zza06 + "' ";
            }



            PhoneBookSQLConnector phoneBookSQLConnector = new PhoneBookSQLConnector();

            PhoneBookViewModel phoneBookViewModel = new PhoneBookViewModel();
            phoneBookViewModel.UserBasicDataList = phoneBookSQLConnector.GetUserBasicDataByCriteria(sqlWhereString, sqlAndString);
            phoneBookViewModel.SelectListItems = phoneBookSQLConnector.getOfficeItem();

            TempData["phoneBookViewModel"] = phoneBookViewModel;

            return Redirect("BackToPhoneBookSearch");
        }

        [HttpPost, ActionName("SearchPhoneBook")]
        [MultiButton("ALS")]
        public ActionResult ALS(PhoneBookViewModel viewModel)
        {
            string sqlWhereString;
            string sqlAndString;

            if (viewModel.ColValue == "" || viewModel.ColValue == null)
            {
                sqlWhereString = " zza06 LIKE '%" + viewModel.Zza06 + "310200' ";
            }
            else
            {
                sqlWhereString = "zza04 LIKE '%" + viewModel.ColValue + "%' ";

            }
            if (viewModel.Zza06 == "" || viewModel.Zza06 == null)
            {
                sqlAndString = "";
            }
            else
            {
                sqlAndString = " zza06 = '" + viewModel.Zza06 + "' ";
            }



            PhoneBookSQLConnector phoneBookSQLConnector = new PhoneBookSQLConnector();

            PhoneBookViewModel phoneBookViewModel = new PhoneBookViewModel();
            phoneBookViewModel.UserBasicDataList = phoneBookSQLConnector.GetUserBasicDataByCriteria(sqlWhereString, sqlAndString);
            phoneBookViewModel.SelectListItems = phoneBookSQLConnector.getOfficeItem();

            TempData["phoneBookViewModel"] = phoneBookViewModel;

            return Redirect("BackToPhoneBookSearch");
        }
        [HttpPost, ActionName("SearchPhoneBook")]
        [MultiButton("TS")]
        public ActionResult TS(PhoneBookViewModel viewModel)
        {
            string sqlWhereString;
            string sqlAndString;

            if (viewModel.ColValue == "" || viewModel.ColValue == null)
            {
                sqlWhereString = " zza06 LIKE '%" + viewModel.Zza06 + "310300' ";
            }
            else
            {
                sqlWhereString = "zza04 LIKE '%" + viewModel.ColValue + "%' ";

            }
            if (viewModel.Zza06 == "" || viewModel.Zza06 == null)
            {
                sqlAndString = "";
            }
            else
            {
                sqlAndString = " zza06 = '" + viewModel.Zza06 + "' ";
            }



            PhoneBookSQLConnector phoneBookSQLConnector = new PhoneBookSQLConnector();

            PhoneBookViewModel phoneBookViewModel = new PhoneBookViewModel();
            phoneBookViewModel.UserBasicDataList = phoneBookSQLConnector.GetUserBasicDataByCriteria(sqlWhereString, sqlAndString);
            phoneBookViewModel.SelectListItems = phoneBookSQLConnector.getOfficeItem();

            TempData["phoneBookViewModel"] = phoneBookViewModel;

            return Redirect("BackToPhoneBookSearch");
        }

        [HttpPost, ActionName("SearchPhoneBook")]
        [MultiButton("IO")]
        public ActionResult IO(PhoneBookViewModel viewModel)
        {
            string sqlWhereString;
            string sqlAndString;

            if (viewModel.ColValue == "" || viewModel.ColValue == null)
            {
                sqlWhereString = " zza06 LIKE '%" + viewModel.Zza06 + "510000' ";
            }
            else
            {
                sqlWhereString = "zza04 LIKE '%" + viewModel.ColValue + "%' ";

            }
            if (viewModel.Zza06 == "" || viewModel.Zza06 == null)
            {
                sqlAndString = "";
            }
            else
            {
                sqlAndString = " zza06 = '" + viewModel.Zza06 + "' ";
            }



            PhoneBookSQLConnector phoneBookSQLConnector = new PhoneBookSQLConnector();

            PhoneBookViewModel phoneBookViewModel = new PhoneBookViewModel();
            phoneBookViewModel.UserBasicDataList = phoneBookSQLConnector.GetUserBasicDataByCriteria(sqlWhereString, sqlAndString);
            phoneBookViewModel.SelectListItems = phoneBookSQLConnector.getOfficeItem();

            TempData["phoneBookViewModel"] = phoneBookViewModel;

            return Redirect("BackToPhoneBookSearch");
        }

        [HttpPost, ActionName("SearchPhoneBook")]
        [MultiButton("IT")]
        public ActionResult IT(PhoneBookViewModel viewModel)
        {
            string sqlWhereString;
            string sqlAndString;

            if (viewModel.ColValue == "" || viewModel.ColValue == null)
            {
                sqlWhereString = " zza06 LIKE '%" + viewModel.Zza06 + "510100' ";
            }
            else
            {
                sqlWhereString = "zza04 LIKE '%" + viewModel.ColValue + "%' ";

            }
            if (viewModel.Zza06 == "" || viewModel.Zza06 == null)
            {
                sqlAndString = "";
            }
            else
            {
                sqlAndString = " zza06 = '" + viewModel.Zza06 + "' ";
            }



            PhoneBookSQLConnector phoneBookSQLConnector = new PhoneBookSQLConnector();

            PhoneBookViewModel phoneBookViewModel = new PhoneBookViewModel();
            phoneBookViewModel.UserBasicDataList = phoneBookSQLConnector.GetUserBasicDataByCriteria(sqlWhereString, sqlAndString);
            phoneBookViewModel.SelectListItems = phoneBookSQLConnector.getOfficeItem();

            TempData["phoneBookViewModel"] = phoneBookViewModel;

            return Redirect("BackToPhoneBookSearch");
        }

        [HttpPost, ActionName("SearchPhoneBook")]
        [MultiButton("BDO")]
        public ActionResult BDO(PhoneBookViewModel viewModel)
        {
            string sqlWhereString;
            string sqlAndString;

            if (viewModel.ColValue == "" || viewModel.ColValue == null)
            {
                sqlWhereString = " zza06 LIKE '%" + viewModel.Zza06 + "610000' ";
            }
            else
            {
                sqlWhereString = "zza04 LIKE '%" + viewModel.ColValue + "%' ";

            }
            if (viewModel.Zza06 == "" || viewModel.Zza06 == null)
            {
                sqlAndString = "";
            }
            else
            {
                sqlAndString = " zza06 = '" + viewModel.Zza06 + "' ";
            }



            PhoneBookSQLConnector phoneBookSQLConnector = new PhoneBookSQLConnector();

            PhoneBookViewModel phoneBookViewModel = new PhoneBookViewModel();
            phoneBookViewModel.UserBasicDataList = phoneBookSQLConnector.GetUserBasicDataByCriteria(sqlWhereString, sqlAndString);
            phoneBookViewModel.SelectListItems = phoneBookSQLConnector.getOfficeItem();

            TempData["phoneBookViewModel"] = phoneBookViewModel;

            return Redirect("BackToPhoneBookSearch");
        }

        [HttpPost, ActionName("SearchPhoneBook")]
        [MultiButton("BD")]
        public ActionResult BD(PhoneBookViewModel viewModel)
        {
            string sqlWhereString;
            string sqlAndString;

            if (viewModel.ColValue == "" || viewModel.ColValue == null)
            {
                sqlWhereString = " zza06 LIKE '%" + viewModel.Zza06 + "610100' ";
            }
            else
            {
                sqlWhereString = "zza04 LIKE '%" + viewModel.ColValue + "%' ";

            }
            if (viewModel.Zza06 == "" || viewModel.Zza06 == null)
            {
                sqlAndString = "";
            }
            else
            {
                sqlAndString = " zza06 = '" + viewModel.Zza06 + "' ";
            }



            PhoneBookSQLConnector phoneBookSQLConnector = new PhoneBookSQLConnector();

            PhoneBookViewModel phoneBookViewModel = new PhoneBookViewModel();
            phoneBookViewModel.UserBasicDataList = phoneBookSQLConnector.GetUserBasicDataByCriteria(sqlWhereString, sqlAndString);
            phoneBookViewModel.SelectListItems = phoneBookSQLConnector.getOfficeItem();

            TempData["phoneBookViewModel"] = phoneBookViewModel;

            return Redirect("BackToPhoneBookSearch");
        }

        [HttpPost, ActionName("SearchPhoneBook")]
        [MultiButton("FAO")]
        public ActionResult FAO(PhoneBookViewModel viewModel)
        {
            string sqlWhereString;
            string sqlAndString;

            if (viewModel.ColValue == "" || viewModel.ColValue == null)
            {
                sqlWhereString = " zza06 LIKE '%" + viewModel.Zza06 + "710000' ";
            }
            else
            {
                sqlWhereString = "zza04 LIKE '%" + viewModel.ColValue + "%' ";

            }
            if (viewModel.Zza06 == "" || viewModel.Zza06 == null)
            {
                sqlAndString = "";
            }
            else
            {
                sqlAndString = " zza06 = '" + viewModel.Zza06 + "' ";
            }



            PhoneBookSQLConnector phoneBookSQLConnector = new PhoneBookSQLConnector();

            PhoneBookViewModel phoneBookViewModel = new PhoneBookViewModel();
            phoneBookViewModel.UserBasicDataList = phoneBookSQLConnector.GetUserBasicDataByCriteria(sqlWhereString, sqlAndString);
            phoneBookViewModel.SelectListItems = phoneBookSQLConnector.getOfficeItem();

            TempData["phoneBookViewModel"] = phoneBookViewModel;

            return Redirect("BackToPhoneBookSearch");
        }

        [HttpPost, ActionName("SearchPhoneBook")]
        [MultiButton("FA")]
        public ActionResult FA(PhoneBookViewModel viewModel)
        {
            string sqlWhereString;
            string sqlAndString;

            if (viewModel.ColValue == "" || viewModel.ColValue == null)
            {
                sqlWhereString = " zza06 LIKE '%" + viewModel.Zza06 + "710100' ";
            }
            else
            {
                sqlWhereString = "zza04 LIKE '%" + viewModel.ColValue + "%' ";

            }
            if (viewModel.Zza06 == "" || viewModel.Zza06 == null)
            {
                sqlAndString = "";
            }
            else
            {
                sqlAndString = " zza06 = '" + viewModel.Zza06 + "' ";
            }



            PhoneBookSQLConnector phoneBookSQLConnector = new PhoneBookSQLConnector();

            PhoneBookViewModel phoneBookViewModel = new PhoneBookViewModel();
            phoneBookViewModel.UserBasicDataList = phoneBookSQLConnector.GetUserBasicDataByCriteria(sqlWhereString, sqlAndString);
            phoneBookViewModel.SelectListItems = phoneBookSQLConnector.getOfficeItem();

            TempData["phoneBookViewModel"] = phoneBookViewModel;

            return Redirect("BackToPhoneBookSearch");
        }

        [HttpPost, ActionName("SearchPhoneBook")]
        [MultiButton("MD")]
        public ActionResult MD(PhoneBookViewModel viewModel)
        {
            string sqlWhereString;
            string sqlAndString;

            if (viewModel.ColValue == "" || viewModel.ColValue == null)
            {
                sqlWhereString = " zza06 LIKE '%" + viewModel.Zza06 + "810000' ";
            }
            else
            {
                sqlWhereString = "zza04 LIKE '%" + viewModel.ColValue + "%' ";

            }
            if (viewModel.Zza06 == "" || viewModel.Zza06 == null)
            {
                sqlAndString = "";
            }
            else
            {
                sqlAndString = " zza06 = '" + viewModel.Zza06 + "' ";
            }



            PhoneBookSQLConnector phoneBookSQLConnector = new PhoneBookSQLConnector();

            PhoneBookViewModel phoneBookViewModel = new PhoneBookViewModel();
            phoneBookViewModel.UserBasicDataList = phoneBookSQLConnector.GetUserBasicDataByCriteria(sqlWhereString, sqlAndString);
            phoneBookViewModel.SelectListItems = phoneBookSQLConnector.getOfficeItem();

            TempData["phoneBookViewModel"] = phoneBookViewModel;

            return Redirect("BackToPhoneBookSearch");
        }

        [HttpPost, ActionName("SearchPhoneBook")]
        [MultiButton("PD")]
        public ActionResult PD(PhoneBookViewModel viewModel)
        {
            string sqlWhereString;
            string sqlAndString;

            if (viewModel.ColValue == "" || viewModel.ColValue == null)
            {
                sqlWhereString = " zza06 LIKE '%" + viewModel.Zza06 + "810100' ";
            }
            else
            {
                sqlWhereString = "zza04 LIKE '%" + viewModel.ColValue + "%' ";

            }
            if (viewModel.Zza06 == "" || viewModel.Zza06 == null)
            {
                sqlAndString = "";
            }
            else
            {
                sqlAndString = " zza06 = '" + viewModel.Zza06 + "' ";
            }



            PhoneBookSQLConnector phoneBookSQLConnector = new PhoneBookSQLConnector();

            PhoneBookViewModel phoneBookViewModel = new PhoneBookViewModel();
            phoneBookViewModel.UserBasicDataList = phoneBookSQLConnector.GetUserBasicDataByCriteria(sqlWhereString, sqlAndString);
            phoneBookViewModel.SelectListItems = phoneBookSQLConnector.getOfficeItem();

            TempData["phoneBookViewModel"] = phoneBookViewModel;

            return Redirect("BackToPhoneBookSearch");
        }

        [HttpPost, ActionName("SearchPhoneBook")]
        [MultiButton("PKG")]
        public ActionResult PKG(PhoneBookViewModel viewModel)
        {
            string sqlWhereString;
            string sqlAndString;

            if (viewModel.ColValue == "" || viewModel.ColValue == null)
            {
                sqlWhereString = " zza06 LIKE '%" + viewModel.Zza06 + "810130' ";
            }
            else
            {
                sqlWhereString = "zza04 LIKE '%" + viewModel.ColValue + "%' ";

            }
            if (viewModel.Zza06 == "" || viewModel.Zza06 == null)
            {
                sqlAndString = "";
            }
            else
            {
                sqlAndString = " zza06 = '" + viewModel.Zza06 + "' ";
            }



            PhoneBookSQLConnector phoneBookSQLConnector = new PhoneBookSQLConnector();

            PhoneBookViewModel phoneBookViewModel = new PhoneBookViewModel();
            phoneBookViewModel.UserBasicDataList = phoneBookSQLConnector.GetUserBasicDataByCriteria(sqlWhereString, sqlAndString);
            phoneBookViewModel.SelectListItems = phoneBookSQLConnector.getOfficeItem();

            TempData["phoneBookViewModel"] = phoneBookViewModel;

            return Redirect("BackToPhoneBookSearch");
        }

        [HttpPost, ActionName("SearchPhoneBook")]
        [MultiButton("PMA")]
        public ActionResult PMA(PhoneBookViewModel viewModel)
        {
            string sqlWhereString;
            string sqlAndString;

            if (viewModel.ColValue == "" || viewModel.ColValue == null)
            {
                sqlWhereString = " zza06 LIKE '%" + viewModel.Zza06 + "810140' ";
            }
            else
            {
                sqlWhereString = "zza04 LIKE '%" + viewModel.ColValue + "%' ";

            }
            if (viewModel.Zza06 == "" || viewModel.Zza06 == null)
            {
                sqlAndString = "";
            }
            else
            {
                sqlAndString = " zza06 = '" + viewModel.Zza06 + "' ";
            }



            PhoneBookSQLConnector phoneBookSQLConnector = new PhoneBookSQLConnector();

            PhoneBookViewModel phoneBookViewModel = new PhoneBookViewModel();
            phoneBookViewModel.UserBasicDataList = phoneBookSQLConnector.GetUserBasicDataByCriteria(sqlWhereString, sqlAndString);
            phoneBookViewModel.SelectListItems = phoneBookSQLConnector.getOfficeItem();

            TempData["phoneBookViewModel"] = phoneBookViewModel;

            return Redirect("BackToPhoneBookSearch");
        }

        [HttpPost, ActionName("SearchPhoneBook")]
        [MultiButton("ENG")]
        public ActionResult ENG(PhoneBookViewModel viewModel)
        {
            string sqlWhereString;
            string sqlAndString;

            if (viewModel.ColValue == "" || viewModel.ColValue == null)
            {
                sqlWhereString = " zza06 LIKE '%" + viewModel.Zza06 + "810300' ";
            }
            else
            {
                sqlWhereString = "zza04 LIKE '%" + viewModel.ColValue + "%' ";

            }
            if (viewModel.Zza06 == "" || viewModel.Zza06 == null)
            {
                sqlAndString = "";
            }
            else
            {
                sqlAndString = " zza06 = '" + viewModel.Zza06 + "' ";
            }



            PhoneBookSQLConnector phoneBookSQLConnector = new PhoneBookSQLConnector();

            PhoneBookViewModel phoneBookViewModel = new PhoneBookViewModel();
            phoneBookViewModel.UserBasicDataList = phoneBookSQLConnector.GetUserBasicDataByCriteria(sqlWhereString, sqlAndString);
            phoneBookViewModel.SelectListItems = phoneBookSQLConnector.getOfficeItem();

            TempData["phoneBookViewModel"] = phoneBookViewModel;

            return Redirect("BackToPhoneBookSearch");
        }

        [HttpPost, ActionName("SearchPhoneBook")]
        [MultiButton("QA")]
        public ActionResult QA(PhoneBookViewModel viewModel)
        {
            string sqlWhereString;
            string sqlAndString;

            if (viewModel.ColValue == "" || viewModel.ColValue == null)
            {
                sqlWhereString = " zza06 LIKE '%" + viewModel.Zza06 + "810600' ";
            }
            else
            {
                sqlWhereString = "zza04 LIKE '%" + viewModel.ColValue + "%' ";

            }
            if (viewModel.Zza06 == "" || viewModel.Zza06 == null)
            {
                sqlAndString = "";
            }
            else
            {
                sqlAndString = " zza06 = '" + viewModel.Zza06 + "' ";
            }



            PhoneBookSQLConnector phoneBookSQLConnector = new PhoneBookSQLConnector();

            PhoneBookViewModel phoneBookViewModel = new PhoneBookViewModel();
            phoneBookViewModel.UserBasicDataList = phoneBookSQLConnector.GetUserBasicDataByCriteria(sqlWhereString, sqlAndString);
            phoneBookViewModel.SelectListItems = phoneBookSQLConnector.getOfficeItem();

            TempData["phoneBookViewModel"] = phoneBookViewModel;

            return Redirect("BackToPhoneBookSearch");
        }

        [HttpPost, ActionName("SearchPhoneBook")]
        [MultiButton("QC")]
        public ActionResult QC(PhoneBookViewModel viewModel)
        {
            string sqlWhereString;
            string sqlAndString;

            if (viewModel.ColValue == "" || viewModel.ColValue == null)
            {
                sqlWhereString = " zza06 LIKE '%" + viewModel.Zza06 + "810700' ";
            }
            else
            {
                sqlWhereString = "zza04 LIKE '%" + viewModel.ColValue + "%' ";

            }
            if (viewModel.Zza06 == "" || viewModel.Zza06 == null)
            {
                sqlAndString = "";
            }
            else
            {
                sqlAndString = " zza06 = '" + viewModel.Zza06 + "' ";
            }



            PhoneBookSQLConnector phoneBookSQLConnector = new PhoneBookSQLConnector();

            PhoneBookViewModel phoneBookViewModel = new PhoneBookViewModel();
            phoneBookViewModel.UserBasicDataList = phoneBookSQLConnector.GetUserBasicDataByCriteria(sqlWhereString, sqlAndString);
            phoneBookViewModel.SelectListItems = phoneBookSQLConnector.getOfficeItem();

            TempData["phoneBookViewModel"] = phoneBookViewModel;

            return Redirect("BackToPhoneBookSearch");
        }

        [HttpPost, ActionName("SearchPhoneBook")]
        [MultiButton("PP")]
        public ActionResult PP(PhoneBookViewModel viewModel)
        {
            string sqlWhereString;
            string sqlAndString;

            if (viewModel.ColValue == "" || viewModel.ColValue == null)
            {
                sqlWhereString = " zza06 LIKE '%" + viewModel.Zza06 + "811000' ";
            }
            else
            {
                sqlWhereString = "zza04 LIKE '%" + viewModel.ColValue + "%' ";

            }
            if (viewModel.Zza06 == "" || viewModel.Zza06 == null)
            {
                sqlAndString = "";
            }
            else
            {
                sqlAndString = " zza06 = '" + viewModel.Zza06 + "' ";
            }



            PhoneBookSQLConnector phoneBookSQLConnector = new PhoneBookSQLConnector();

            PhoneBookViewModel phoneBookViewModel = new PhoneBookViewModel();
            phoneBookViewModel.UserBasicDataList = phoneBookSQLConnector.GetUserBasicDataByCriteria(sqlWhereString, sqlAndString);
            phoneBookViewModel.SelectListItems = phoneBookSQLConnector.getOfficeItem();

            TempData["phoneBookViewModel"] = phoneBookViewModel;

            return Redirect("BackToPhoneBookSearch");
        }

        [HttpPost, ActionName("SearchPhoneBook")]
        [MultiButton("WH")]
        public ActionResult WH(PhoneBookViewModel viewModel)
        {
            string sqlWhereString;
            string sqlAndString;

            if (viewModel.ColValue == "" || viewModel.ColValue == null)
            {
                sqlWhereString = " zza06 LIKE '%" + viewModel.Zza06 + "811100' ";
            }
            else
            {
                sqlWhereString = "zza04 LIKE '%" + viewModel.ColValue + "%' ";

            }
            if (viewModel.Zza06 == "" || viewModel.Zza06 == null)
            {
                sqlAndString = "";
            }
            else
            {
                sqlAndString = " zza06 = '" + viewModel.Zza06 + "' ";
            }



            PhoneBookSQLConnector phoneBookSQLConnector = new PhoneBookSQLConnector();

            PhoneBookViewModel phoneBookViewModel = new PhoneBookViewModel();
            phoneBookViewModel.UserBasicDataList = phoneBookSQLConnector.GetUserBasicDataByCriteria(sqlWhereString, sqlAndString);
            phoneBookViewModel.SelectListItems = phoneBookSQLConnector.getOfficeItem();

            TempData["phoneBookViewModel"] = phoneBookViewModel;

            return Redirect("BackToPhoneBookSearch");
        }

        [HttpPost, ActionName("SearchPhoneBook")]
        [MultiButton("QS")]
        public ActionResult QS(PhoneBookViewModel viewModel)
        {
            string sqlWhereString;
            string sqlAndString;

            if (viewModel.ColValue == "" || viewModel.ColValue == null)
            {
                sqlWhereString = " zza06 LIKE '%" + viewModel.Zza06 + "811400' ";
            }
            else
            {
                sqlWhereString = "zza04 LIKE '%" + viewModel.ColValue + "%' ";

            }
            if (viewModel.Zza06 == "" || viewModel.Zza06 == null)
            {
                sqlAndString = "";
            }
            else
            {
                sqlAndString = " zza06 = '" + viewModel.Zza06 + "' ";
            }



            PhoneBookSQLConnector phoneBookSQLConnector = new PhoneBookSQLConnector();

            PhoneBookViewModel phoneBookViewModel = new PhoneBookViewModel();
            phoneBookViewModel.UserBasicDataList = phoneBookSQLConnector.GetUserBasicDataByCriteria(sqlWhereString, sqlAndString);
            phoneBookViewModel.SelectListItems = phoneBookSQLConnector.getOfficeItem();

            TempData["phoneBookViewModel"] = phoneBookViewModel;

            return Redirect("BackToPhoneBookSearch");
        }

        [HttpPost, ActionName("SearchPhoneBook")]
        [MultiButton("AD")]
        public ActionResult AD(PhoneBookViewModel viewModel)
        {
            string sqlWhereString;
            string sqlAndString;

            if (viewModel.ColValue == "" || viewModel.ColValue == null)
            {
                sqlWhereString = " zza06 LIKE '%" + viewModel.Zza06 + "910100' ";
            }
            else
            {
                sqlWhereString = "zza04 LIKE '%" + viewModel.ColValue + "%' ";

            }
            if (viewModel.Zza06 == "" || viewModel.Zza06 == null)
            {
                sqlAndString = "";
            }
            else
            {
                sqlAndString = " zza06 = '" + viewModel.Zza06 + "' ";
            }



            PhoneBookSQLConnector phoneBookSQLConnector = new PhoneBookSQLConnector();

            PhoneBookViewModel phoneBookViewModel = new PhoneBookViewModel();
            phoneBookViewModel.UserBasicDataList = phoneBookSQLConnector.GetUserBasicDataByCriteria(sqlWhereString, sqlAndString);
            phoneBookViewModel.SelectListItems = phoneBookSQLConnector.getOfficeItem();

            TempData["phoneBookViewModel"] = phoneBookViewModel;

            return Redirect("BackToPhoneBookSearch");
        }

        [HttpPost, ActionName("SearchPhoneBook")]
        [MultiButton("HR")]
        public ActionResult HR(PhoneBookViewModel viewModel)
        {
            string sqlWhereString;
            string sqlAndString;

            if (viewModel.ColValue == "" || viewModel.ColValue == null)
            {
                sqlWhereString = " zza06 LIKE '%" + viewModel.Zza06 + "910100' ";
            }
            else
            {
                sqlWhereString = "zza04 LIKE '%" + viewModel.ColValue + "%' ";

            }
            if (viewModel.Zza06 == "" || viewModel.Zza06 == null)
            {
                sqlAndString = "";
            }
            else
            {
                sqlAndString = " zza06 = '" + viewModel.Zza06 + "' ";
            }



            PhoneBookSQLConnector phoneBookSQLConnector = new PhoneBookSQLConnector();

            PhoneBookViewModel phoneBookViewModel = new PhoneBookViewModel();
            phoneBookViewModel.UserBasicDataList = phoneBookSQLConnector.GetUserBasicDataByCriteria(sqlWhereString, sqlAndString);
            phoneBookViewModel.SelectListItems = phoneBookSQLConnector.getOfficeItem();

            TempData["phoneBookViewModel"] = phoneBookViewModel;

            return Redirect("BackToPhoneBookSearch");
        }

        [HttpPost, ActionName("SearchPhoneBook")]
        [MultiButton("PUR")]
        public ActionResult PUR(PhoneBookViewModel viewModel)
        {
            string sqlWhereString;
            string sqlAndString;

            if (viewModel.ColValue == "" || viewModel.ColValue == null)
            {
                sqlWhereString = " zza06 LIKE '%" + viewModel.Zza06 + "910300' ";
            }
            else
            {
                sqlWhereString = "zza04 LIKE '%" + viewModel.ColValue + "%' ";

            }
            if (viewModel.Zza06 == "" || viewModel.Zza06 == null)
            {
                sqlAndString = "";
            }
            else
            {
                sqlAndString = " zza06 = '" + viewModel.Zza06 + "' ";
            }



            PhoneBookSQLConnector phoneBookSQLConnector = new PhoneBookSQLConnector();

            PhoneBookViewModel phoneBookViewModel = new PhoneBookViewModel();
            phoneBookViewModel.UserBasicDataList = phoneBookSQLConnector.GetUserBasicDataByCriteria(sqlWhereString, sqlAndString);
            phoneBookViewModel.SelectListItems = phoneBookSQLConnector.getOfficeItem();

            TempData["phoneBookViewModel"] = phoneBookViewModel;

            return Redirect("BackToPhoneBookSearch");
        }

        public class MultiButtonAttribute : ActionNameSelectorAttribute
        {
            public string Name { get; set; }
            public MultiButtonAttribute(string name)
            {
                this.Name = name;
            }
            public override bool IsValidName(ControllerContext controllerContext,
                string actionName, System.Reflection.MethodInfo methodInfo)
            {
                if (string.IsNullOrEmpty(this.Name))
                {
                    return false;
                }
                return controllerContext.HttpContext.Request.Form.AllKeys.Contains(this.Name);
            }
        }

        public ActionResult BackToPhoneBookSearch()
        {
            PhoneBookViewModel phoneBookViewModel = (PhoneBookViewModel)TempData["phoneBookViewModel"];
            return View("PhoneBookSearch", phoneBookViewModel);
        }

    }
}
