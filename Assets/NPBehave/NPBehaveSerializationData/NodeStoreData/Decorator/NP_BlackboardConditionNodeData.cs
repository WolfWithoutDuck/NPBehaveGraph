using System;
using MainCore;
using Sirenix.OdinInspector;

namespace NPBehave
{
    [BoxGroup("黑板条件节点配置"), GUIColor(0.961f, 0.902f, 0.788f, 1f)]
    [HideLabel]
    public class NP_BlackboardConditionNodeData : NP_NodeDataBase
    {
        [HideInEditorMode]
        private BlackboardCondition m_BlackboardConditionNode;

        [LabelText("运算符号")]
        public Operator Ope = Operator.IS_EQUAL;

        [LabelText("终止条件")]
        public Stops Stop = Stops.IMMEDIATE_RESTART;

        public NP_BlackBoardRelationData NpBlackBoardRelationData = new NP_BlackBoardRelationData()
            { WriteOrCompareToBB = true };

        public override Decorator CreateDecoratorNode(Unit unit, NP_RuntimeTree runtimeTree, Node node)
        {
            this.m_BlackboardConditionNode = new BlackboardCondition(NpBlackBoardRelationData.BBKey, this.Ope,
                NpBlackBoardRelationData.NP_BBValue, this.Stop, node);
            return this.m_BlackboardConditionNode;
        }

        public override Node NP_GetNode()
        {
            return this.m_BlackboardConditionNode;
        }
    }
}