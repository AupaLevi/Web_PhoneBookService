using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneBookService.Models
{
    public class RecordDataViewModel
    {
        private int currentPage;
        private int strPageNum;
        private int endPageNum;
        private int previousPageNumber;
        private int nextPageNumber;
        private bool firstPage;
        private bool lastPage;

        private string zzc01;
        private string zzc02;
        private string zzc03;

        private string zza01;
        private string zza02;
        private string zza03;
        private string zza04;
        private string zza05;
        private string zza06;
        private string zza07;
        private string zza08;
        private string zza09;

        List<SelectListItem> selectListItems = new List<SelectListItem>();
        List<RecordDataObject> recordDataList = new List<RecordDataObject>();

        public List<SelectListItem> SelectListItems { get => selectListItems; set => selectListItems = value; }

        public List<RecordDataObject> RecordDataList { get => recordDataList; set => recordDataList = value; }
        //public IEnumerable<RecordDataObject> PostDataList { get; set; }
        public IEnumerable<PageBean> PageNumberList { get; set; }
        public int PageCount { get; set; }
        public int CurrentPage { get => currentPage; set => currentPage = value; }
        public int StrPageNum { get => strPageNum; set => strPageNum = value; }
        public int EndPageNum { get => endPageNum; set => endPageNum = value; }
        public int PreviousPageNumber { get => previousPageNumber; set => previousPageNumber = value; }
        public int NextPageNumber { get => nextPageNumber; set => nextPageNumber = value; }
        public bool LastPage { get => lastPage; set => lastPage = value; }
        public bool FirstPage { get => firstPage; set => firstPage = value; }

        public string Zzc01 { get => zzc01; set => zzc01 = value; }
        public string Zzc02 { get => zzc02; set => zzc02 = value; }
        public string Zzc03 { get => zzc03; set => zzc03 = value; }

        public string Zza01 { get => zza01; set => zza01 = value; }
        public string Zza02 { get => zza02; set => zza02 = value; }
        public string Zza03 { get => zza03; set => zza03 = value; }

        public string Zza04 { get => zza04; set => zza04 = value; }
        public string Zza05 { get => zza05; set => zza05 = value; }
        public string Zza06 { get => zza06; set => zza06 = value; }
        public string Zza07 { get => zza07; set => zza07 = value; }
        public string Zza08 { get => zza08; set => zza08 = value; }

        public string Zza09 { get => zza09; set => zza09 = value; }
    }
}