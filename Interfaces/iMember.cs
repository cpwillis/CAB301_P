//Provided Interface by Project

using Tools;

namespace Interfaces
{
    interface iMember
    {
        //member's firstname
        string FirstName { get; set; }

        //member's lastname
        string LastName { get; set; }

        //member's contact number
        string ContactNumber { get; set; }

        //member's password
        string PIN { get; set; }

        //member's current holds
        Tool[] Tools { get; }

        //add hold to member
        void AddTool(Tool aTool);

        //remove hold from member
        void DeleteTool(Tool aTool);

        //return first, last and contact for member
        string ToString();

        //compare first/last name of members
        int Compare([System.Diagnostics.CodeAnalysis.AllowNull] Member inpt);
    }
}
