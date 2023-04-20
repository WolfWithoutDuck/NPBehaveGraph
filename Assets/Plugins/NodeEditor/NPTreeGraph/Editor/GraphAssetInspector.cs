using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using GraphProcessor;
using Plugins.NodeEditor;
using UnityEngine.UIElements;

[CustomEditor(typeof(BaseGraph), true)]
public class GraphAssetInspector : GraphInspector
{
    // protected override void CreateInspector()
    // {
    // }

    [Header("PureMode Configs")]
    public string OutputBTBytesDir = "Assets/Resources/Configs";
    public string OutputBTBytesFilePosfix = ".btbytes";
    
    protected override void CreateInspector()
    {
        base.CreateInspector();

        root.Add(new Button(() => PrepareNode())
        {
            text = "行为树行为前置1"
        });

        root.Add(new Button(() => SaveNode())
        {
            text = "行为树序列化二进制"
        });
        
        // root.Add(new Button(() => EditorWindow.GetWindow<CustomContextMenuGraphWindow>().InitializeGraph(target as BaseGraph))
        // {
        // 	text = "Open custom context menu graph window"
        // });
        // root.Add(new Button(() => EditorWindow.GetWindow<CustomToolbarGraphWindow>().InitializeGraph(target as BaseGraph))
        // {
        // 	text = "Open custom toolbar graph window"
        // });
        // root.Add(new Button(() => EditorWindow.GetWindow<ExposedPropertiesGraphWindow>().InitializeGraph(target as BaseGraph))
        // {
        // 	text = "Open exposed properties graph window"
        // });
    }


    public void PrepareNode()
    {
        NPBehaveGraph graph = target as NPBehaveGraph;
        if (graph != null)
        {
            graph.PrepareNodeInfo();
        }
    }

    public void SaveNode()
    {
        NPBehaveGraph graph = target as NPBehaveGraph;
        if (graph != null)
        {
            graph.Save();
        }
    }
}