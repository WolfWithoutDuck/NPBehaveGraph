using GraphProcessor;
using UnityEngine;

namespace Plugins.NodeEditor
{
    public partial class NP_CompositeNodeBase
    {
        [HideInInspector]
        [Input("NpBehave_PreNode"), Vertical] public NP_NodeBase PreNode;
        [HideInInspector]
        [Output("NPBehave_NextNode"), Vertical] public NP_NodeBase NextNode;
    }

    public partial class NP_DecoratorNodeBase
    {
        [HideInInspector]
        [Input("NpBehave_PreNode"), Vertical] public NP_NodeBase PreNode;
    
        [HideInInspector]
        [Output("NPBehave_NextNode"), Vertical] public NP_NodeBase NextNode;
    }

    public partial class NP_TaskNodeBase
    {
        [HideInInspector]
        [Input("NpBehave_PreNode"), Vertical] public NP_NodeBase PreNode;
    }
}