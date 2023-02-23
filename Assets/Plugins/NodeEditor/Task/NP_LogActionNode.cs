using GraphProcessor;

namespace Plugins.NodeEditor
{
    [NodeMenuItem("NPBehave行为树/Task/Log", typeof(NPBehaveGraph))]
    public class NP_LogActionNode : NP_TaskNodeBase
    {
        public override string name => "Log节点";
    }
}