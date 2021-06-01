using Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace Tools
{
    public class Member : iMember
    {
        //member's loans
        private ToolCollection tmp = new ToolCollection();

        //vars for get/set
        private string fst, lst, phn, psk;

        //member's firstname
        public string FirstName { get { return fst; } set { fst = value; } }

        //member's lastname
        public string LastName { get { return lst; } set { lst = value; } }

        //member's contact number
        public string ContactNumber { get { return phn; } set { phn = value; } }

        //member's password
        public string PIN { get { return psk; } set { psk = value; } }

        //member's current holds
        public Tool[] Tools { get { return tmp.ToArray(); } }

        //add hold to member
        public void AddTool(Tool aTool) { tmp.Add(aTool); }

        //remove hold from member
        public void DeleteTool(Tool aTool) { tmp.Delete(aTool); }

        //return first, last and contact for member
        public override string ToString() { return $"{FirstName} {LastName}: {ContactNumber}"; }

        //compare first/last name of members
        public int Compare([AllowNull] Member inpt)
        {
            Member member = inpt;
            int outpt = LastName.CompareTo(member.LastName);
            if (outpt == 0) return FirstName.CompareTo(member.FirstName);
            else return outpt;
        }
    }
}
