using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;



namespace addressbook_web_tests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string firstName;
        private string lastName;
        private string mobileNumber;
        private string allPhones;
        private string allEmails;
        private string allContactInfo;
        private string fullName;

        public ContactData() { }

        public ContactData(string firstName)
        {
            this.FirstName = firstName;
        }

        public ContactData(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
        public ContactData(string firstName, string lastName, string mobileNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.MobileNumber = mobileNumber;
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
            return this.ToString() == other.ToString();
        }

        public override int GetHashCode()
        {
            return (this.ToString()).GetHashCode();
        }

        public override string ToString()
        {
            return "Firstname = " + FirstName + ", Lastname = " + LastName;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return this.ToString().CompareTo(other.ToString());
        }

        [Column(Name = "id"), PrimaryKey]
        public string Id { get; set; }
        [Column(Name = "firstname")]
        public string FirstName { get; set; }
        [Column(Name = "lastname")]
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
        public string MobilePhone { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string NickName { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Home { get; set; }
        public string Mobile { get; set; }
        public string Work { get; set; }
        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }


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
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
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
            return Regex.Replace(phone, "[ \\-()]", "") + "\r\n";
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
                    return (ClenupEmail(Email) + ClenupEmail(Email2) + ClenupEmail(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }
        private string ClenupEmail(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            return email.Replace(" ", "");
        }
        public string AllContactInfo
        {
            get
            {
                if (allContactInfo != null)
                {
                    return allContactInfo;
                }
                else
                {
                    return FullName
                        + CleanUpData(NickName)
                        + CleanUpData(Title)
                        + CleanUpData(Company)
                        + CleanUpData(Address)
                        + CleanUpDataPhones(HomePhone)
                        + CleanUpDataPhones(MobilePhone)
                        + CleanUpDataPhones(WorkPhone)
                        + AllEmails;
                }
            }
            set { allContactInfo = value; }
        }
        private string CleanUpData(string data)
        {
            if (data == null || data == "")
            {
                return "";
            }

            return data;
        }
        private string CleanUpDataPhones(string phone)
        {
            if (phone == null || phone == "")
            { 
                return "";
            }
            else
                if (phone == HomePhone)
                {
                    return "H: " + phone;
                }
                else if (phone == MobilePhone)
                {
                    return "M: " + phone;
                }
                else if (phone == WorkPhone)
                {
                    return "W: " + phone;
                }

            return phone;
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
                    return (firstName + " " + lastName).Trim();
                }
            }
            set
            {
                fullName = value;
            }
        }
        public static List<ContactData> GetAll()
        {
            using (AddresBookDB db = new AddresBookDB())
            {
                return (from c in db.contacts.Where(x => x.Deprecated == "00.00.0000 0:00:00") select c).ToList();
            }
        }
    }
}