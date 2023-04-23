using GraphProcessor;
using NPBehave;
using Sirenix.OdinInspector;

namespace Plugins.NodeEditor
{
    [NodeMenuItem("NPBehave行为树/Composite/SequenceNode", typeof(NPBehaveGraph))]
    public class NP_SequenceNode : NP_CompositeNodeBase
    {
        public override string name => "序列节点";

        [BoxGroup("Sequence结点数据")]
        [HideReferenceObjectPicker]
        [HideLabel]
        public NP_SequenceNodeData NpSequenceNodeData = new NP_SequenceNodeData(){NodeDesc = "序列组合器"};

        public override NP_NodeDataBase NP_GetNodeData()
        {
            return NpSequenceNodeData;
        }
    }
}