using System;
using System.Collections.Generic;
using UnityEngine;

namespace NPBehave
{
    [Serializable]
    public class NP_DataStoreSupport
    {
        public long NPBehaveTreeRootID;

        public NP_NodeDataBase RootNode;

        /// <summary>
        /// 单个行为树所有节点数据
        /// </summary>
        public Dictionary<long, NP_NodeDataBase> NpNodeDataBasesDict = new Dictionary<long, NP_NodeDataBase>();

        /// <summary>
        /// 黑板数据
        /// </summary>
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