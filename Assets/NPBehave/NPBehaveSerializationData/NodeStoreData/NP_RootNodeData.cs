using MainCore;
using Sirenix.OdinInspector;

namespace NPBehave
{
    public class NP_RootNodeData : NP_NodeDataBase
    {
        [HideInEditorMode]
        public Root m_Root;

        public override Decorator CreateDecoratorNode(Unit unit, NP_RuntimeTree runtimeTree, Node node)
        {
            m_Root = new Root(node, runtimeTree.GetClock());
            return m_Root;
        }


        public override Node NP_GetNode()
        {
            return m_Root;
        }
    }
}