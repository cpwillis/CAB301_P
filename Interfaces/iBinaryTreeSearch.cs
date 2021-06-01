// Lecture 5 Demo: BTree Interface, Maolin Tang (24/3/06)

using Tools;

namespace Interfaces
{
    public interface iBinaryTreeSearch
    {
        //checks if tree is empty
        bool IsEmpty();

        //add item
        void Add(Member item);

        //remove item
        void Delete(Member item);

        //checks if item exists
        bool Search(Member item);

        //traverse inorder (Left, Root, Right)
        void InOrder();

        //traverse preorder (Root, Left, Right)
        void PreOrder();

        //traverse postorder (Left, Right, Root)
        void PostOrder();

        //empty tree
        void Empty();
    }
}
