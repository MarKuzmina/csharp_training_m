using System;
using System.Xml.Linq;

namespace webAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string middlename = "";
        private string nickname = "";
        private string title = "";
        private string company = "компания";
        //private string address = "адрес проживания";
        //private string phoneHomeNumber = "999";
        //private string phoneMobileNumber = "888";
        //private string phoneWorkNumber = "777";
        private string phoneFaxNumber = "666";
        private string email = "test1@test.com";
        private string email2 = "test2@test.com";
        private string email3 = "test3@test.com";
        private string urlHomepage = "http://homepage.test";

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
            return "lastname = " + Lastname + ", fistname = " + Firstname;
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

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Address { get; set; }

        public string PhoneHomeNumber { get; set; }

        public string PhoneMobileNumber { get; set; }

        public string PhoneWorkNumber { get; set; }

        public string Middlename
        {
            get
            {
                return middlename;
            }
            set

            {
                middlename = value;
            }
        }

        public string Nickname
        {
            get
            {
                return nickname;
            }
            set

            {
                nickname = value;
            }
        }

        public string Title
        {
            get
            {
                return title;
            }
            set

            {
                title = value;
            }
        }

        public string Company
        {
            get
            {
                return company;
            }
            set

            {
                company = value;
            }
        }

        public string PhoneFaxNumber
        {
            get
            {
                return phoneFaxNumber;
            }
            set

            {
                phoneFaxNumber = value;
            }
        }

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

        public string Id { get; set; }

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

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\n";
        }
    }
}