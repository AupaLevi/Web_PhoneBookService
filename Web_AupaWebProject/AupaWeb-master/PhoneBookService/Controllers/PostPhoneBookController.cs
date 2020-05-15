using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.WebPages;
using PhoneBookService.Models;

namespace PhoneBookService.Controllers
{
    public class PostPhoneBookController : Controller
    {
       
        public ActionResult AddNewPhoneBookPost()
        {
            PhoneBookSQLConnector phoneBookSQLConnector = new PhoneBookSQLConnector();
            List<PostDataPhoneBook> listPhoneBooks ;
            listPhoneBooks = phoneBookSQLConnector.getPostPhoneBookList();

            ViewBag.ListOfPhoneBookPost = listPhoneBooks;
            return View(listPhoneBooks);
        }

      
        public ActionResult CreatePhoneBookPost()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include ="zza02,zza03")]PostDataPhoneBook postDataPhoneBook)
        {
            PhoneBookSQLConnector phoneBookSQLConnector = new PhoneBookSQLConnector();
            List<PostDataPhoneBook> listPhoneBooks;
            listPhoneBooks = phoneBookSQLConnector.getPostPhoneBookList();

            String result = phoneBookSQLConnector.InsertPostData(postDataPhoneBook);
            return RedirectToAction("AddNewPhoneBookPost", "Post");
        }

        public ActionResult DeletePost(String postID)
        {
            String sqlCriteria = "";
            if (postID != null && !postID.IsEmpty())
            {
                if (postID.StartsWith("*"))
                {
                    postID = postID.Remove(1, 1);
                }
                if (postID.EndsWith("*"))
                {
                    postID = postID.Remove(postID.Length - 1, postID.Length);
                }
                sqlCriteria = "aaz01 LIKE '%" + postID + "%' ";
            }

            PhoneBookSQLConnector phoneBookSQLConnector = new PhoneBookSQLConnector();
            List<PostDataPhoneBook> listPhoneBooks;
            listPhoneBooks = phoneBookSQLConnector.getPostsListOnDemand(sqlCriteria);
            ViewBag.ListOfPosts = listPhoneBooks;
            return View("ConfirmDelete", listPhoneBooks);
        }//End of DeletePost

        [HttpPost, ActionName("ConfirmedDelete")]
        public ActionResult ConfirmedDeletePost(String postID)
        {
            PhoneBookSQLConnector phoneBookSQLConnector = new PhoneBookSQLConnector();
            List<PostDataPhoneBook>  listPhoneBooks = new List<PostDataPhoneBook>();
            String result = phoneBookSQLConnector.ConfirmedDelete(postID);
            if (result == "SUCCESS")
            {
                listPhoneBooks = phoneBookSQLConnector.getPostPhoneBookList();
            }
            ViewBag.ListOfPosts = listPhoneBooks;

            return RedirectToAction("AddNewPost", "Post");
        }// End of ConfirmedDeletePost

    }
}