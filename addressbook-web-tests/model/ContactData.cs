﻿using System;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;

namespace webAddressbookTests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        private string fullName;
        //private string middlename = "";
        //private string nickname = "";
        //private string title = "";
        //private string company = "компания";
        //private string address = "адрес проживания";
        //private string phoneHomeNumber = "999";
        //private string phoneMobileNumber = "888";
        //private string phoneWorkNumber = "777";
        //private string phoneFaxNumber = "666";
        private string email = "test1@test.com";
        private string email2 = "test2@test.com";
        private string email3 = "test3@test.com";
        private string urlHomepage = "http://homepage.test";

        public ContactData()
        {
        }

        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return (Firstname == other.Firstname) && (Lastname == other.Lastname);
        }

        public override int GetHashCode()
        {

            return Firstname.GetHashCode() ^ Lastname.GetHashCode();
        }

        public override string ToString()
        {
            return "lastname = " + Lastname
                + "\nfistname = " + Firstname
                + "\nmiddlename = " + Middlename
                + "\naddress = " + Address
                + "\nemail = " + Email
                + "\nemail2 = " + Email2
                + "\nemail3 = " + Email3
                + "\nhomepage = " + UrlHomepage;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            if (Lastname == other.Lastname)
            {
                return Firstname.CompareTo(other.Firstname);
            }

            return Lastname.CompareTo(other.Lastname);
        }

        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts select c).ToList();
            }
        }

        [Column(Name = "id"), PrimaryKey]
        public string Id { get; set; }

        [Column(Name = "firstname")]
        public string Firstname { get; set; }

        [Column(Name = "lastname")]
        public string Lastname { get; set; }

        public string Address { get; set; }

        public string PhoneHomeNumber { get; set; }

        public string PhoneMobileNumber { get; set; }

        public string PhoneWorkNumber { get; set; }

        public string Middlename { get; set; }
        
        public string Nickname { get; set; }

        public string Title { get; set; }
        
        public string Company { get; set; }
        
        public string PhoneFaxNumber { get; set; }

        public string Email
        {
            get
            {
                return email;
            }
            set

            {
                email = value;
            }
        }

        public string Email2
        {
            get
            {
                return email2;
            }
            set

            {
                email2 = value;
            }
        }

        public string Email3
        {
            get
            {
                return email3;
            }
            set

            {
                email3 = value;
            }
        }

        public string UrlHomepage
        {
            get
            {
                return urlHomepage;
            }
            set

            {
                urlHomepage = value;
            }
        }

        public string FullName
        {
            get
            {
                if (fullName != null)
                {
                    return fullName;
                }
                else
                {
                    return (Firstname + " " + Middlename + " " + Lastname).Trim();
                }
            }
            set
            {
                fullName = value;
            }
        }

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(PhoneHomeNumber) + CleanUp(PhoneMobileNumber) + CleanUp(PhoneWorkNumber)).Trim();
                }
            }
            set

            {
                allPhones = value;
            }
        }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (Email + "\n" + Email2 + "\n" + Email3 + "\n").Trim();
                }
            }
            set

            {
                allEmails = value;
            }
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ \\-()]", "") + "\n";
        }

        public List<GroupData> GetGroups()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from g in db.Groups
                        from gcr in db.GCR.Where(p => p.ContactId == Id && p.GroupId == g.Id)
                        select g).Distinct().ToList();
            }
        }

        public static ContactData GetContactNotInGroup()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts
                        where !(from gcr in db.GCR select gcr.ContactId).Contains(c.Id)
                        select c).FirstOrDefault();
            }
        }
    }
}