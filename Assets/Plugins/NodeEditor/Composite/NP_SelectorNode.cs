using GraphProcessor;
using NPBehave;

namespace Plugins.NodeEditor
{
    [NodeMenuItem("NPBehave行为树/Composite/SelectorNode", typeof(NPBehaveGraph))]
    public class NP_SelectorNode : NP_CompositeNodeBase
    {
        public override string name => "选择节点";
    
        [ShowInInspector]
        public NP_SelectorNodeData NpSelectorNodeData = new NP_SelectorNodeData();

        public override NP_NodeDataBase NP_GetNodeData()
        {
            return NpSelectorNodeData;
        }
    }
}