using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using GraphProcessor;
using UnityEditor.Callbacks;
using System.IO;
using Plugins.NodeEditor;

public class GraphAssetCallbacks
{
    [MenuItem("Assets/Create/NodeGraph/GraphProcessor", false, 10)]
    public static void CreateGraphPorcessor()
    {
        var graph = ScriptableObject.CreateInstance<BaseGraph>();
        ProjectWindowUtil.CreateAsset(graph, "GraphProcessor.asset");
    }

    [MenuItem("Assets/Create/NodeGraph/BTGraphProcessor", false, 10)]
    public static void CreateBTGraphPorcessor()
    {
        var graph = ScriptableObject.CreateInstance<NPBehaveGraph>();
        ProjectWindowUtil.CreateAsset(graph, "BTGraphProcessor.asset");
    }

    [OnOpenAsset(0)]
    public static bool OnBaseGraphOpened(int instanceID, int line)
    {
        var asset = EditorUtility.InstanceIDToObject(instanceID) as BaseGraph;

        NPBehaveGraph asset2 = EditorUtility.InstanceIDToObject(instanceID) as NPBehaveGraph;
        if (asset2 != null)
        {
            EditorWindow.GetWindow<BTGraphWindow>().InitializeGraph(asset2 as BaseGraph);
            return true;
        }
        
        if (asset != null && AssetDatabase.GetAssetPath(asset).Contains("Examples"))
        {
            EditorWindow.GetWindow<AllGraphWindow>().InitializeGraph(asset as BaseGraph);
            return true;
        }


        return false;
    }
}