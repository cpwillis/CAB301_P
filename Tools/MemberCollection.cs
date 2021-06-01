using Interfaces;

namespace Tools
{
    public class MemberCollection : iMemberCollection
    {
        //BST to store members
        private BinaryTreeSearch tmp = new BinaryTreeSearch();

        //member total
        private int cnt;

        //member count
        public int Number { get { return cnt; } }

        //add member
        public void Add(Member aMember) { tmp.Add(aMember); ++cnt; }

        //remove member
        public void Delete(Member aMember) { tmp.Delete(aMember); --cnt; }

        //check if member exists
        public bool Search(Member aMember)
        {
            for (int i = 0; i < Number; ++i)
                if (tmp.Search(aMember)) return true;
            return false;
        }

        //outputs members as array of iMember
        public Member[] ToArray() { return tmp.ItemArray; }
    }
}
