//Provided Interface by Project

using Tools;

namespace Interfaces
{
    interface iMemberCollection
    {
        //member count
        int Number { get; }

        //add member
        void Add(Member aMember);

        //remove member
        void Delete(Member aMember);

        //check if member exists
        bool Search(Member aMember);

        //outputs members as array of iMember
        Member[] ToArray();
    }
}
