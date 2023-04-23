using System;
using MainCore;
using Sirenix.OdinInspector;

namespace NPBehave
{

    [BoxGroup("行为结点数据")]
    [HideLabel]
    public class NP_ActionNodeData : NP_NodeDataBase
    {
        [HideInEditorMode]
        private Action m_ActionNode;
        
     
        public NP_ClassForStoreAction NpClassForStoreAction;

        public override Task CreateTaks(Unit unit, NP_RuntimeTree runtimeTree)
        {
            this.NpClassForStoreAction.BelongToUnit = unit;
            this.NpClassForStoreAction.BelongRuntimeTree = runtimeTree;
            this.m_ActionNode = NpClassForStoreAction._CreateNPBehaveAction();
            return this.m_ActionNode;
        }

        public override Node NP_GetNode()
        {
            return m_ActionNode;
        }
    }
}