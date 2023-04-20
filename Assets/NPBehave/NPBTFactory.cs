using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MainCore;
using Sirenix.Serialization;
using UnityEngine;

namespace NPBehave.AI
{
    public class NPBTFactory
    {
        public enum NodeType
        {
            Composite,
            Decorator,
            Task,
        }

        public static Dictionary<Type, NodeType> NPNodeRegister = new Dictionary<Type, NodeType>()
        {
            { typeof(NP_RootNodeData), NodeType.Decorator },
            { typeof(NP_ParallelNodeData), NodeType.Composite },
            { typeof(NP_SelectorNodeData), NodeType.Composite },
            { typeof(NP_SequenceNodeData), NodeType.Composite },

            { typeof(NP_BlackboardConditionNodeData), NodeType.Decorator },
            // { typeof(NP_BlackboardMultipleConditionsNodeData), NodeType.Decorator },
            { typeof(NP_RepeaterNodeData), NodeType.Decorator },
            { typeof(NP_ServiceNodeData), NodeType.Decorator },

            { typeof(NP_ActionNodeData), NodeType.Task },
            { typeof(NP_WaitNodeData), NodeType.Task },
            { typeof(NP_WaitUntilStoppedData), NodeType.Task },
        };


        public static NP_RuntimeTree GetOrCreateNPBehave(string resourceName)
        {
            Unit unit = new Unit();
            NP_RuntimeTree runtimeTree = new NP_RuntimeTree();

            NP_DataStoreSupport treeData;
            //Todo 加载先临时直接放resource文件夹
            string path = $"Assets/Res/{resourceName}.btbytes";
            Dictionary<long, Node> nodeList = new Dictionary<long, Node>();
            byte[] bytes = File.ReadAllBytes(path);
            using (MemoryStream stream = new MemoryStream(bytes))
            {
                using (BinaryDataReader reader = new BinaryDataReader(stream, new DeserializationContext()))
                {
                    treeData = SerializationUtility.DeserializeValue<NP_DataStoreSupport>(reader);
                    // treeData.ToStringFormat();
                }
            }

            foreach (var node_data in treeData.NpNodeDataBasesDict.OrderByDescending(x => x.Key))
            {
                // nodeList[node_data.Key] = node_data.Value.NP_GetNode();
                // Debug.Log("node_data_type : "+ node_data.Value.GetType()); 
                switch (NPNodeRegister[node_data.Value.GetType()])
                {
                    case NodeType.Task:
                        node_data.Value.CreateTaks(unit, runtimeTree);
                        break;
                    case NodeType.Decorator:
                        node_data.Value.CreateDecoratorNode(unit, runtimeTree,
                            treeData.NpNodeDataBasesDict[node_data.Value.LinkedIds[0]].NP_GetNode());
                        break;
                    case NodeType.Composite:
                        List<Node> temp = new List<Node>();
                        foreach (var linkedId in node_data.Value.LinkedIds)
                        {
                            temp.Add(treeData.NpNodeDataBasesDict[linkedId].NP_GetNode());
                        }
                        node_data.Value.CreateComposite(temp.ToArray());
                        break;
                }
            }
        
            runtimeTree.SetRootNode(treeData.RootNode.NP_GetNode() as Root);
            runtimeTree.Start();
            return runtimeTree;
        }
    }
}