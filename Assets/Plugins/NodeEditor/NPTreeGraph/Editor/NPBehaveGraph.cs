using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GraphProcessor;
using NPBehave;
using UnityEditor;
using UnityEngine;
using Sirenix;
using Sirenix.Serialization;

namespace Plugins.NodeEditor
{
    public class NPBehaveGraph : BaseGraph
    {
        private NP_DataStoreSupport dataStoreSupport = new NP_DataStoreSupport();

        private List<NP_NodeBase> allNodes = new List<NP_NodeBase>();

        private int index = 0;


        /// <summary>
        /// 准备节点数据
        /// </summary>
        public void PrepareNodeInfo()
        {
            Debug.Log("对节点进行前置赋值行为 当前节点数量为：" + nodes.Count);
            // this.OnGraphEnable();
            allNodes.Clear();
            dataStoreSupport.NpNodeDataBasesDict.Clear();
            index = 0;
            NP_NodeBase rootNode = null;
            foreach (var node in nodes)
            {
                if (node is NP_NodeBase mNode)
                {
                    allNodes.Add(mNode);
                    if (mNode.IsRootNode())
                    {
                        //判断是根节点，初始化根节点ID
                        dataStoreSupport.RootNode = mNode.NP_GetNodeData();
                        dataStoreSupport.RootNode.id = 0;
                        rootNode = mNode;
                    }
                }
            }

            travers(rootNode);
            dataStoreSupport.ToStringFormat();
        }

        /// <summary>
        /// 把数据保存为二进制
        /// </summary>
        public void Save(NpTreeGraphGenData genInfo)
        {
            if (!Directory.Exists(genInfo.OutputBTBytesDir))
            {
                AssetDatabase.CreateFolder(genInfo.OutputBTBytesDir, "res");
            }

            // Debug.Log("Save As + "+ Path.Combine(genInfo.OutputBTBytesDir,this.name+genInfo.OutputBTBytesFilePosfix)); 
            string outputPath = Path.Combine(genInfo.OutputBTBytesDir, this.name + genInfo.OutputBTBytesFilePosfix);
            FileUtil.SerializeAndSaveToFile(dataStoreSupport, outputPath);
            CheckBinarySucc<NP_DataStoreSupport>(outputPath);
        }

        public void CheckBinarySucc<T>(string path)
        {
            T testData;
            byte[] bytes = File.ReadAllBytes(path);
            using (MemoryStream stream = new MemoryStream(bytes))
            {
                using (BinaryDataReader reader = new BinaryDataReader(stream, new DeserializationContext()))
                {
                    testData = SerializationUtility.DeserializeValue<T>(reader);
                }
            }

            var newBytes = SerializationUtility.SerializeValue(testData, DataFormat.Binary);
            Debug.Assert(newBytes.EqualsEx(bytes), "BehaviourTree Serialize Failed ");
        }

        /// <summary>
        /// 遍历节点
        /// </summary>
        /// <param name="node"></param>
        public void travers(NP_NodeBase node)
        {
            NP_NodeDataBase nodeDataBase = (node as NP_NodeBase)?.NP_GetNodeData();
            if (nodeDataBase == null)
            {
                return;
            }

            List<NP_NodeBase> levelNodes = new List<NP_NodeBase>();
            foreach (var childNode in node.GetOutputNodes())
            {
                levelNodes.Add(childNode as NP_NodeBase);
            }

            levelNodes.Sort(((a, b) => a.position.x.CompareTo(b.position.x)));
            node.NP_GetNodeData().LinkedIds.Clear();
            foreach (var childNode in levelNodes)
            {
                index++;
                childNode.NP_GetNodeData().id = index;
                node.NP_GetNodeData().LinkedIds.Add(childNode.NP_GetNodeData().id);
            }

            dataStoreSupport.NpNodeDataBasesDict.Add(nodeDataBase.id, nodeDataBase);
            // Debug.Log("travers id :  " + node.NP_GetNodeData().id + "child : " + node.NP_GetNodeData().LinkedIds.Count);
            // Debug.Log("node_outputNodes + : " + node.GetOutputNodes().Count());
            foreach (var childNode in levelNodes)
            {
                travers(childNode);
            }
        }
    }
}