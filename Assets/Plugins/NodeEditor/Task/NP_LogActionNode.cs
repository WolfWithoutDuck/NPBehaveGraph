using GraphProcessor;
using NPBehave;

namespace Plugins.NodeEditor
{
    [NodeMenuItem("NPBehave行为树/Task/Log", typeof(NPBehaveGraph))]
    public class NP_LogActionNode : NP_TaskNodeBase
    {
        public override string name => "Log节点";

        public NP_ActionNodeData NpActionNodeData = new NP_ActionNodeData()
            { NpClassForStoreAction = new NP_LogAction() };

        public override NP_NodeDataBase NP_GetNodeData()
        {
            return NpActionNodeData;
        }
    }
}