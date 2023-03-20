using GraphProcessor;
using NPBehave;

namespace Plugins.NodeEditor
{
    [NodeMenuItem("NPBehave行为树/Decorator/BlackboardCondition", typeof(NPBehaveGraph))]
    public class NP_BlackboardConditionNode : NP_DecoratorNodeBase
    {
        public override string name => "黑板条件节点";

        public NP_BlackboardConditionNodeData NpBlackboardConditionNodeData =
            new NP_BlackboardConditionNodeData() { NodeDesc = "黑板条件节点" };

        public override NP_NodeDataBase NP_GetNodeData()
        {
            return NpBlackboardConditionNodeData;
        }
    }
}