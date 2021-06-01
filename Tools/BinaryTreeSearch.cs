// Lecture 5 Demo: Implementation of BTree, Maolin Tang (24/3/06)

using Interfaces;
using System;
using System.Collections.Generic;

namespace Tools
{
    public class BTreeNode
    {
        private Member item;
        private BTreeNode lchild;
        private BTreeNode rchild;

        public BTreeNode(Member item)
        {
            this.item = item;
            lchild = null;
            rchild = null;
        }

        public Member Item { get { return item; } set { item = value; } }

        public BTreeNode LChild { get { return lchild; } set { lchild = value; } }

        public BTreeNode RChild { get { return rchild; } set { rchild = value; } }
    }

    public class BinaryTreeSearch : iBinaryTreeSearch
    {
        private BTreeNode root;
        private List<Member> itemList;

        public BinaryTreeSearch() { root = null; }

        public Member[] ItemArray { get { InOrder(); return itemList.ToArray(); } }

        public bool IsEmpty() { return root == null; }

        public bool Search(Member item) { return Search(item, root); }

        private bool Search(Member item, BTreeNode r)
        {
            if (r != null)
            {
                if (item.Compare(r.Item) == 0) return true;
                else if (item.Compare(r.Item) < 0) return Search(item, r.LChild);
                else return Search(item, r.RChild);
            }
            else return false;
        }

        public void Add(Member item)
        {
            if (root == null) root = new BTreeNode(item);
            else Insert(item, root);
            InOrder();
        }

        private void Insert(Member item, BTreeNode ptr)
        {
            if (item.Compare(ptr.Item) < 0)
            {
                if (ptr.LChild == null) ptr.LChild = new BTreeNode(item);
                else Insert(item, ptr.LChild);
            }
            else
            {
                if (ptr.RChild == null) ptr.RChild = new BTreeNode(item);
                else Insert(item, ptr.RChild);
            }
        }

        public void Delete(Member item)
        {
            BTreeNode ptr = root;
            BTreeNode parent = null;
            while ((ptr != null) && (item.Compare(ptr.Item) != 0))
            {
                parent = ptr;
                if (item.Compare(ptr.Item) < 0)
                    ptr = ptr.LChild;
                else ptr = ptr.RChild;
            }

            if (ptr != null)
            {
                if ((ptr.LChild != null) && (ptr.RChild != null))
                {
                    if (ptr.LChild.RChild == null)
                    {
                        ptr.Item = ptr.LChild.Item;
                        ptr.LChild = ptr.LChild.LChild;
                    }
                    else
                    {
                        BTreeNode p = ptr.LChild;
                        BTreeNode pp = ptr;
                        while (p.RChild != null) { pp = p; p = p.RChild; }
                        ptr.Item = p.Item;
                        pp.RChild = p.LChild;
                    }
                }
                else
                {
                    BTreeNode c;
                    if (ptr.LChild != null) c = ptr.LChild;
                    else c = ptr.RChild;

                    if (ptr == root)
                        root = c;
                    else
                    {
                        if (ptr == parent.LChild) parent.LChild = c;
                        else parent.RChild = c;
                    }
                }

            }
        }

        public void PreOrder()
        {
            Console.Write("PreOrder: ");
            PreOrderTraverse(root);
            Console.WriteLine();
        }

        private void PreOrderTraverse(BTreeNode root)
        {
            if (root != null)
            {
                Console.Write(root.Item);
                PreOrderTraverse(root.LChild);
                PreOrderTraverse(root.RChild);
            }
        }

        public void InOrder()
        {
            itemList = new List<Member>();
            InOrderTraverse(root);
        }

        private void InOrderTraverse(BTreeNode root)
        {
            if (root != null)
            {
                itemList.Add(root.Item);
                InOrderTraverse(root.LChild);
                InOrderTraverse(root.RChild);
            }
        }

        public void PostOrder()
        {
            Console.Write("PostOrder: ");
            PostOrderTraverse(root);
            Console.WriteLine();
        }

        private void PostOrderTraverse(BTreeNode root)
        {
            if (root != null)
            {
                PostOrderTraverse(root.LChild);
                PostOrderTraverse(root.RChild);
                Console.Write(root.Item);
            }
        }

        public void Empty() { root = null; }
    }
}
