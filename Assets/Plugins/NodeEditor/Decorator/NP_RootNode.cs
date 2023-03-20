using GraphProcessor;
using NPBehave;
using UnityEngine;

namespace Plugins.NodeEditor
{
    [NodeMenuItem("NPBehave行为树/Decorator/RootNode", typeof(NPBehaveGraph))]
    public class NP_RootNode : NP_NodeBase
    {
        public override string name => "行为树根节点";

        public override Color color => Color.cyan;

        [Output("NPBehave_NextNode"), Vertical] [HideInInspector]
        public NP_NodeBase NextNode;
        
        public NP_RootNodeData MRootNodeData = new NP_RootNodeData { };

        public override NP_NodeDataBase NP_GetNodeData()
        {
            return this.MRootNodeData;
        }

        public override bool IsRootNode()
        {
            return true;
        }
    }
}