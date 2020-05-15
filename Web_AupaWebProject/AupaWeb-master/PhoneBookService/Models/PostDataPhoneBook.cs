using System;
using System.Web;

namespace PhoneBookService.Models
{
    public class PostDataPhoneBook 
    {
        private string zza01;   //EmployeeNo
        private string zza02;   //FirstName
        private string zza03;   //LastName
        private string zza04;   //EMail 
        private string zza05;   //OfficeCode
        private string zza06;   //Extension
        private string zza07;   //JobTitle
        private string zza08;   //Role
        private string zza09;

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
