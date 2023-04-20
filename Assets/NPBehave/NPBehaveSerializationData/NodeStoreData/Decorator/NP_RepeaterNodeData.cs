using System;
using MainCore;

namespace NPBehave
{

    [Serializable]
    public class NP_RepeaterNodeData : NP_NodeDataBase
    {
        public Repeater m_Repeater;

        public override Decorator CreateDecoratorNode(Unit unit, NP_RuntimeTree runtimeTree, Node node)
        {
            this.m_Repeater = new Repeater(node);
            return this.m_Repeater;
        }

        public override Node NP_GetNode()
        {
            return this.m_Repeater;
        }
    }
}