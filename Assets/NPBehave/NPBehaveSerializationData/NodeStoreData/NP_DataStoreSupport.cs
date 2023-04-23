using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace NPBehave
{
    /// <summary>
    /// 技能配置数据载体
    /// </summary>
    [HideLabel]
    public class NP_DataStoreSupport
    {
        [LabelText("此行为树Id，也是根节点Id")]
        public long NPBehaveTreeRootID;

        public NP_NodeDataBase RootNode;

        /// <summary>
        /// 单个行为树所有节点数据
        /// </summary>
        [LabelText("单个行为树所有结点")]
        public Dictionary<long, NP_NodeDataBase> NpNodeDataBasesDict = new Dictionary<long, NP_NodeDataBase>();

        /// <summary>
        /// 黑板数据
        /// </summary>
        [LabelText("黑板数据")]
        public Dictionary<string, object> NP_BBManager = new Dictionary<string, object>();


        public void ToStringFormat()
        {
            Debug.Log($"valueCount: {NpNodeDataBasesDict.Values.Count}");

            if (NpNodeDataBasesDict.Values.Count > 0)
            {
                foreach (var node in NpNodeDataBasesDict.Values)
                {
                    Debug.Log("----------------------------------------");
                    Debug.Log($"节点ID是{node.id}");
                    Debug.Log($"节点子节点数量是{node.LinkedIds.Count}");
                    foreach (int id in node.LinkedIds)
                    {
                        Debug.Log($"节点子节点为{id}");
                    }

                    Debug.Log("----------------------------------------");
                }
            }
        }
    }
}