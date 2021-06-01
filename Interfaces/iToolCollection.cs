//Provided Interface by Project

using Tools;

namespace Interfaces
{
    interface iToolCollection
    {
        //tool count
        int Number { get; }

        //add tool
        void Add(Tool aTool);

        //delete tool
        void Delete(Tool aTool);

        //check if tool exists
        bool Search(Tool aTool);

        //outputs tools as array of iTool
        Tool[] ToArray();
    }
}
