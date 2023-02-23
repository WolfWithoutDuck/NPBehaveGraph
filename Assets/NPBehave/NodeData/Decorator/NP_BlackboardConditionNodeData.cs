using MainCore;

namespace NPBehave
{
    public class NP_BlackboardConditionNodeData : NP_NodeDataBase
    {
        private BlackboardCondition m_BlackboardConditionNode;

        public Operator Ope = Operator.IS_EQUAL;

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