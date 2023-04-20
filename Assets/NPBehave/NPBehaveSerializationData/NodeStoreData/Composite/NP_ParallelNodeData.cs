using System;
using System.Collections.Generic;

using Sirenix.Utilities;

namespace NPBehave
{
    [Serializable]
    public class NP_ParallelNodeData : NP_NodeDataBase
    {
        private Parallel m_ParallelNode;
        public Parallel.Policy SuccessPolicy = Parallel.Policy.ALL;
        public Parallel.Policy FailurePolicy = Parallel.Policy.ALL;
        private Dictionary<string, bool> memo = new Dictionary<string, bool>();
        private List<int> trace = new List<int>();
        private List<IList<int>> res = new List<IList<int>>();

        public override Composite CreateComposite(Node[] nodes)
        {
            // memo.ContainsKey()
            // trace.RemoveAt(trace.Count);
            // res.Add(new List<int>(trace));
            // int[] nums = new []{1,2,3};
            // nums.Sort((a,b)=>a-b);

            this.m_ParallelNode = new Parallel(SuccessPolicy, FailurePolicy, nodes);
            return this.m_ParallelNode;
        }

        public override Node NP_GetNode()
        {
            return this.m_ParallelNode; 
        }
    }
}