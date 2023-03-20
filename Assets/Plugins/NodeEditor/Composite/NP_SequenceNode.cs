using GraphProcessor;
using NPBehave;

namespace Plugins.NodeEditor
{
    [NodeMenuItem("NPBehave行为树/Composite/SequenceNode", typeof(NPBehaveGraph))]
    public class NP_SequenceNode : NP_CompositeNodeBase
    {
        public override string name => "序列节点";

        public NP_SequenceNodeData NpSequenceNodeData = new NP_SequenceNodeData();

        public override NP_NodeDataBase NP_GetNodeData()
        {
            return NpSequenceNodeData;
        }
    }
}