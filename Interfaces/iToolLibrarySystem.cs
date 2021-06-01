//Provided Interface by Project

using Tools;

namespace Interfaces
{
    interface iToolLibrarySystem
    {
        //add new tool
        void Add(Tool aTool);

        //add pieces of existing tool
        void Add(Tool aTool, int quantity);

        //delete tool
        void Delete(Tool aTool);

        //delete pieces of existing tool
        void Delete(Tool aTool, int quantity);

        //add member
        void Add(Member aMember);

        //delete member
        void Delete(Member aMember);

        //displays tools on hold by member
        void DisplayBorrowingTools(Member aMember);

        //displays tool types on hold by member
        void DisplayTools(string aToolType);

        //add hold to member
        void BorrowTool(Member aMember, Tool aTool);

        //delete hold from member
        void ReturnTool(Member aMember, Tool aTool);

        //get list of tools on hold by member
        string[] ListTools(Member aMember);

        //display top 3 most frequently borrowed tools (descending order)
        void DisplayTopThree();
    }
}
