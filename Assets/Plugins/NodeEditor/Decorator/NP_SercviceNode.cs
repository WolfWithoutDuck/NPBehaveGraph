using GraphProcessor;
using NPBehave;

namespace Plugins.NodeEditor
{
    [NodeMenuItem("NPBehave行为树/Decorator/ServiceNode", typeof(NPBehaveGraph))]
    public class NP_SercviceNode : NP_DecoratorNodeBase
    {
        public override string name => "服务节点";

        public NP_ServiceNodeData NpServiceNodeData = new NP_ServiceNodeData();

        public override NP_NodeDataBase NP_GetNodeData()
        {
            return NpServiceNodeData;
        }
    }
}