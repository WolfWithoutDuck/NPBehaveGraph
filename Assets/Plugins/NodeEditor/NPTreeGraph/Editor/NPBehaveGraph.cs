using System.Collections;
using System.Collections.Generic;
using System.IO;
using GraphProcessor;
using MessagePack;
using NPBehave;
using UnityEditor;
using UnityEngine;


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
            Debug.Log("对节点进行前置赋值行为");
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
        public void Save()
        {
            string savePath = Application.dataPath + "/res";
            if (!Directory.Exists(savePath))
            {
                AssetDatabase.CreateFolder(savePath, "res");
            }

            // byte[] bytes = MessagePackSerializer.Serialize(dataStoreSupport);
            //

            var lz4Options = MessagePackSerializerOptions.Standard.WithCompression(MessagePackCompression.Lz4Block);
            byte[] bytes = MessagePackSerializer.Serialize(dataStoreSupport, lz4Options);
            // File.WriteAllBytes(savePath,bytes);

            using (FileStream stream = new FileStream($"{savePath}/behaveTree.bytes", FileMode.OpenOrCreate))
            {
                stream.Write(bytes, 0, bytes.Length);
            }
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

            foreach (var childNode in levelNodes)
            {
                index++;
                childNode.NP_GetNodeData().id = index;
                node.NP_GetNodeData().LinkedIds.Add(childNode.NP_GetNodeData().id);
            }

            foreach (var childNode in levelNodes)
            {
                travers(childNode);
            }

            dataStoreSupport.NpNodeDataBasesDict.Add(nodeDataBase.id, nodeDataBase);
        }
    }
}