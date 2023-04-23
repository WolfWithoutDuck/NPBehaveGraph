using System;
using MainCore;
using Sirenix.OdinInspector;

namespace NPBehave
{

    [BoxGroup("等待结点数据")]
    [HideLabel]
    public class NP_WaitNodeData : NP_NodeDataBase
    {
        private Wait m_WaitNode;
        
        public NP_BlackBoardRelationData NpBlackBoardRelationData = new NP_BlackBoardRelationData();

        public override Task CreateTaks(Unit unit, NP_RuntimeTree runtimeTree)
        {
            this.m_WaitNode = new Wait(this.NpBlackBoardRelationData.BBKey);
            return m_WaitNode;
        }

        public override Node NP_GetNode()
        {
            return m_WaitNode;
        }
    }
}