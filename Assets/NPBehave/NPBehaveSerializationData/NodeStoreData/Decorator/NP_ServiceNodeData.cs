using System;
using MainCore;
using Sirenix.OdinInspector;

namespace NPBehave
{

  
    public class NP_ServiceNodeData : NP_NodeDataBase
    {
        [HideInEditorMode]
        public Service m_Service;
        
        [LabelText("委托执行时间间隔")]
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