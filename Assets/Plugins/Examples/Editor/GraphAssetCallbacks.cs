
using UnityEngine;
using UnityEditor;
using GraphProcessor;
using Plugins.NodeEditor;
using UnityEditor.Callbacks;



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

    // [OnOpenAsset(0)]
    // public static bool OnBaseGraphOpened(int instanceID, int line)
    // {
    //     var asset = EditorUtility.InstanceIDToObject(instanceID) as BaseGraph;
    //
    //     NPBehaveGraph asset2 = EditorUtility.InstanceIDToObject(instanceID) as NPBehaveGraph;
    //     if (asset2 != null)
    //     {
    //         EditorWindow.GetWindow<BTGraphWindow>().InitializeGraph(asset2 as BaseGraph);
    //         return true;
    //     }
    //     
    //     if (asset != null && AssetDatabase.GetAssetPath(asset).Contains("Examples"))
    //     {
    //         EditorWindow.GetWindow<AllGraphWindow>().InitializeGraph(asset as BaseGraph);
    //         return true;
    //     }
    //     return false;
    // }
    
    [OnOpenAsset(0)]
    public static bool OnBaseGraphOpened(int instanceID, int line)
    {
        var baseGraph = EditorUtility.InstanceIDToObject(instanceID) as BaseGraph;
        return InitializeGraph(baseGraph);
    }

    public static bool InitializeGraph(BaseGraph baseGraph)
    {
        if (baseGraph == null) return false;

        switch (baseGraph)
        {
            case NPBehaveGraph npBehaveGraph:
                EditorWindow.CreateWindow<BTGraphWindow>().InitializeGraph(npBehaveGraph);
                break;
            default:
                EditorWindow.CreateWindow<AllGraphWindow>().InitializeGraph(baseGraph);
                break;
        }

        return true;
    }
}