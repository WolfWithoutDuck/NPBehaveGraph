using GraphProcessor;
using NPBehave;

namespace Plugins.NodeEditor
{
    [NodeMenuItem("NPBehave行为树/Composite/Parallel", typeof(NPBehaveGraph))]
    public class NP_ParallelNode : NP_CompositeNodeBase
    {
        public override string name => "并行节点";

        public NP_ParallelNodeData NpParallelNodeData = new NP_ParallelNodeData();

        public override NP_NodeDataBase NP_GetNodeData()
        {
            return NpParallelNodeData;
        }
    }
}