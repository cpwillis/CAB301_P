using Interfaces;

namespace Tools
{
    public class Tool : iTool
    {
        //members borrowing
        private MemberCollection tmp = new MemberCollection();

        //vars for get/set
        private string name = "Null";
        private int amnt = 1;
        private int availAmnt = 1;
        private int borrowCnt = 0;

        //tool's name
        public string Name { get { return name; } set { name = value; } }

        //tool's quantity
        public int Quantity { get { return amnt; } set { int borrowedNum = amnt - availAmnt; amnt = value; availAmnt = amnt - borrowedNum; } }

        //tool's avaible qauntity
        public int AvailableQuantity { get { return availAmnt; } set { availAmnt = value; } }

        //tool's borrowed quantity
        public int NoBorrowings { get { return borrowCnt; } set { borrowCnt = value; } }

        //member's borrowing
        public MemberCollection GetBorrowers { get { return tmp; } }

        //add member to hold
        public void AddBorrower(Member aMember) { tmp.Add(aMember); }

        //remove member from hold
        public void DeleteBorrower(Member aMember) { tmp.Delete(aMember); }

        //return name and available quantity
        public override string ToString() { return $"Name: {Name} | Available: {AvailableQuantity}"; }
    }
}
