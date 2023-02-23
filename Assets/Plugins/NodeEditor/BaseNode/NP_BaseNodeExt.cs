using GraphProcessor;

namespace Plugins.NodeEditor
{
    public partial class NP_CompositeNodeBase
    {
        [Input("NpBehave_PreNode"), Vertical] public NP_NodeBase PreNode;

        [Input("NPBehave_NextNode"), Vertical] public NP_NodeBase NextNode;
    }

    public partial class NP_DecoratorNodeBase
    {
        [Input("NpBehave_PreNode"), Vertical] public NP_NodeBase PreNode;

        [Input("NPBehave_NextNode"), Vertical] public NP_NodeBase NextNode;
    }

    public partial class NP_TaskNodeBase
    {
        [Input("NpBehave_PreNode"), Vertical] public NP_NodeBase PreNode;
    }
}