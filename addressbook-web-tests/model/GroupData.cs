﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
        private string name;
        private string header = "";
        private string footer = "";

        public GroupData(string name)
        {
            this.name = name;
        }

        public GroupData(string name, string header, string footer)
        {
            this.name = name;
            this.header = header;
            this.footer = footer;
        }

        public string Name { get; set; }
        public string Header { get; set; }
        public string Footer { get; set; }
        public string Id { get; set; }

        public bool Equals(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Name == other.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
        public override string ToString()
        {
            return "name = " + Name + "\nheader = " + Header + "\nfooter = " + Footer;
        }

        public int CompareTo(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return Name.CompareTo(other.Name);
            }
            return 1;
        }
    }
}
