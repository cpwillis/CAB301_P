//Provided Interface by Project

using Tools;

namespace Interfaces
{
    interface iTool
    {
        //tool's name
        string Name { get; set; }

        //tool's quantity
        int Quantity { get; set; }

        //tool's avaible qauntity
        int AvailableQuantity { get; set; }

        //tool's borrowed quantity
        int NoBorrowings { get; set; }

        //member's borrowing
        MemberCollection GetBorrowers { get; }

        //add member to hold
        void AddBorrower(Member aMember);

        //remove member from hold
        void DeleteBorrower(Member aMember);

        //return name and available quantity
        string ToString();
    }
}
