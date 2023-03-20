using System;
using System.Collections.Generic;
using MainCore;
using MessagePack;

namespace NPBehave
{
    [MessagePackObject]
    [Serializable]
    [Union(0, typeof(NP_NodeDataBase))]
    public abstract class NP_NodeDataBase
    {
        /// <summary>
        /// 自身节点ID
        /// </summary>
        [Key(0)]
        public long id;

        /// <summary>
        /// 相连的节点ID
        /// </summary>
        [Key(1)]
        public List<long> LinkedIds = new List<long>();

        [IgnoreMember]
        public string NodeDesc;

        public abstract Node NP_GetNode();

        /// <summary>
        /// 创建组合节点
        /// </summary>
        /// <param name="nodes"></param>
        /// <returns></returns>
        public virtual Composite CreateComposite(Node[] nodes)
        {
            return null;
        }

        /// <summary>
        /// 创建装饰节点
        /// </summary>
        /// <param name="unit">行为树归属Unit</param>
        /// <param name="runtimeTree">运行时归属的行为树</param>
        /// <param name="node">装饰的节点</param>
        /// <returns></returns>
        public virtual Decorator CreateDecoratorNode(Unit unit, NP_RuntimeTree runtimeTree, Node node)
        {
            return null;
        }

        /// <summary>
        /// 创建任务节点
        /// </summary>
        /// <param name="unit">行为树怪属的Unit</param>
        /// <param name="runtimeTree">运行时归属的行为树</param>
        /// <returns></returns>
        public virtual Task CreateTaks(Unit unit, NP_RuntimeTree runtimeTree)
        {
            return null;
        }
    }
}