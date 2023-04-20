using System;
using MainCore;

namespace NPBehave
{

    [Serializable]
    public class NP_ServiceNodeData : NP_NodeDataBase
    {
        public Service m_Service;
        public float interval;
        public NP_ClassForStoreAction NpClassForStoreAction;

        public override Node NP_GetNode()
        {
            return this.m_Service;
        }

        public override Decorator CreateDecoratorNode(Unit unit, NP_RuntimeTree runtimeTree, Node node)
        {
            this.NpClassForStoreAction.BelongToUnit = unit;
            this.NpClassForStoreAction.BelongRuntimeTree = runtimeTree;
            this.m_Service = new Service(interval, NpClassForStoreAction.GetActionToBeDone(), node);
            return m_Service;
        }
    }
}