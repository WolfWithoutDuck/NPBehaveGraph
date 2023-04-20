using MainCore;
using UnityEngine;

namespace NPBehave
{
    public class NP_RuntimeTree
    {
        /// <summary>
        /// 行为树根节点
        /// </summary>
        private Root m_RootNode;

        /// <summary>
        /// 行为树的数据块
        /// </summary>
        public NP_DataStoreSupport NpDataStoreSupport;

        /// <summary>
        /// 行为树归属的Unit
        /// </summary>
        public Unit Unit;


        public Clock GetClock()
        {
            return UnityContext.GetClock();
        }

        /// <summary>
        /// 设置根结点
        /// </summary>
        /// <param name="rootNode"></param>
        public void SetRootNode(Root rootNode)
        {
            this.m_RootNode = rootNode;
        }

        /// <summary>
        /// 获取黑板
        /// </summary>
        /// <returns></returns>
        public Blackboard GetBlackboard()
        {
            // if (m_RootNode == null)
            // {
            //     Log.Error($"行为树{this.Id}的根节点为空");
            // }
            //
            // if (m_RootNode.blackboard == null)
            // {
            //     Debug.LogError($"行为树{this.Id}的黑板实例为空");
            // }

            return this.m_RootNode.Blackboard;
        }

        /// <summary>
        /// 开始运行行为树
        /// </summary>
        public void Start()
        {
            this.m_RootNode.Start();
        }
        
        /// <summary>
        /// 终止行为树
        /// </summary>
        public void Finish()
        {
            this.m_RootNode.CancelWithoutReturnResult();
            this.m_RootNode = null;
        }
    }
}