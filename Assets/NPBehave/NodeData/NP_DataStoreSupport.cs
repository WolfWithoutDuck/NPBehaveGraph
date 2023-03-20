using System;
using System.Collections.Generic;
using MessagePack;
using UnityEngine;

namespace NPBehave
{

   
    [MessagePackObject]
    [Serializable]
    public class NP_DataStoreSupport
    {
        [Key(1)] public long NPBehaveTreeRootID;

        [Key(2)] public NP_NodeDataBase RootNode;

        /// <summary>
        /// 单个行为树所有节点数据
        /// </summary>
        [Key(3)] public Dictionary<long, NP_NodeDataBase> NpNodeDataBasesDict = new Dictionary<long, NP_NodeDataBase>();

        /// <summary>
        /// 黑板数据
        /// </summary>
        [Key(4)] public Dictionary<string, object> NP_BBManager = new Dictionary<string, object>();


        public void ToStringFormat()
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