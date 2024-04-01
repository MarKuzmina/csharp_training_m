using System;
using System.Xml.Linq;

namespace webAddressbookTests
{
	public class ContactData
	{
		private string firstname;
        private string lastname;
        private string middlename = "";
        private string nickname = "";
        private string title = "";
        private string company = "";
        private string address = "";
        private string phoneHomeNumber = "";
        private string phoneMobileNumber = "";
        private string phoneWorkNumber = "";
        private string phoneFaxNumber = "";
        private string email = "";
        private string email2 = "";
        private string email3 = "";
        private string urlHomepage = "";

        public ContactData(string firstname, string lastname)
		{
            this.firstname = firstname;
            this.lastname = lastname;
        }

        public string Firstname
        {
            get
            {
                return firstname;
            }
            set

            {
                firstname = value;
            }
        }

        public string Lastname
        {
            get
            {
                return lastname;
            }
            set

            {
                lastname = value;
            }
        }

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

        public string Address
        {
            get
            {
                return address;
            }
            set

            {
                address = value;
            }
        }

        public string PhoneHomeNumber
        {
            get
            {
                return phoneHomeNumber;
            }
            set

            {
                phoneHomeNumber = value;
            }
        }

        public string PhoneMobileNumber
        {
            get
            {
                return phoneMobileNumber;
            }
            set

            {
                phoneMobileNumber = value;
            }
        }

        public string PhoneWorkNumber
        {
            get
            {
                return phoneWorkNumber;
            }
            set

            {
                phoneWorkNumber = value;
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
    }
}