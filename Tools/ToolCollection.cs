using Interfaces;

namespace Tools
{
    public class ToolCollection : iToolCollection
    {
        //tools
        private Tool[] tmp = new Tool[30];

        //tool total
        private int cnt;

        //tool count
        public int Number { get { return cnt; } }

        //add tool
        public void Add(Tool aTool)
        {
            for (int i = 0; i < tmp.Length; ++i)
                if (tmp[i] == null) { tmp[i] = aTool; break; }
            ++cnt;
        }

        //delete tool
        public void Delete(Tool aTool)
        {
            for (int i = 0; i < tmp.Length; ++i)
                if (tmp[i] == aTool) { tmp[i] = null; break; }
            --cnt;
        }

        //check if tool exists
        public bool Search(Tool aTool)
        {
            for (int i = 0; i < Number; ++i)
                if (tmp[i].Equals(aTool)) return true;
            return false;
        }

        //outputs tools as array of iTool
        public Tool[] ToArray()
        {
            Tool[] arr = new Tool[Number];
            int tmp = 0;
            for (int i = 0; i < this.tmp.Length; ++i)
                if (this.tmp[i] != null) { arr[tmp] = this.tmp[i]; ++tmp; }
            return arr;
        }
    }
}
