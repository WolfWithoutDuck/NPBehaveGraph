using GraphProcessor;
using NPBehave;

namespace Plugins.NodeEditor
{
    [NodeMenuItem("NPBehave行为树/Decorator/RepeaterNode", typeof(NPBehaveGraph))]
    public class NP_RepeaterNode : NP_DecoratorNodeBase
    {
        public override string name => "重复执行节点";

        public NP_RepeaterNodeData NpRepeaterNodeData = new NP_RepeaterNodeData() { NodeDesc = "重复执行节点数据" };

        public override NP_NodeDataBase NP_GetNodeData()
        {
            return NpRepeaterNodeData;
        }
    }
}