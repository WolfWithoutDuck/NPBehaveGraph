using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEditor;
using GraphProcessor;
using NPBehave.AI;
using Plugins.NodeEditor;
using Sirenix.Serialization;
using UnityEngine.UIElements;
using FileUtil = Plugins.NodeEditor.FileUtil;

[CustomEditor(typeof(BaseGraph), true)]
public class GraphAssetInspector : GraphInspector
{
    private NpTreeGraphGenData treeGenData;
    static string path = "Assets/Res";
    static string filePath = Path.Combine(path, "GenBTTreeData.btbytes");

    protected override void OnEnable()
    {
        base.OnEnable();
        //自动序列化保存面板信息
        if (File.Exists(filePath))
        {
            byte[] bytes = File.ReadAllBytes(filePath);
            using (MemoryStream stream = new MemoryStream(bytes))
            {
                using (BinaryDataReader reader = new BinaryDataReader(stream, new DeserializationContext()))
                {
                    treeGenData = SerializationUtility.DeserializeValue<NpTreeGraphGenData>(reader);
                }
            }
        }
        else
        {
            treeGenData = new NpTreeGraphGenData();
            treeGenData.OutputBTBytesDir = "Assets/Resources/Configs";
            treeGenData.OutputBTBytesFilePosfix = ".btbytes";
        }
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        FileUtil.SerializeAndSaveToFile(treeGenData, filePath);
    }

    protected override void CreateInspector()
    {
        base.CreateInspector();

        //OutputBTBytesDir
        VisualElement groupOutByteDir = new VisualElement();
        var label = new Label("OutputBTBytesDir");
        var texeField = new TextField();
        if (treeGenData.OutputBTBytesDir != null)
        {
            texeField.value = treeGenData.OutputBTBytesDir;
        }

        texeField.RegisterValueChangedCallback(evt => treeGenData.OutputBTBytesDir = evt.newValue);
        groupOutByteDir.Add(label);
        groupOutByteDir.Add(texeField);
        root.Add(groupOutByteDir);

        root.Add(new Button(() => PrepareNode())
        {
            text = "行为树行为前置1"
        });

        root.Add(new Button(() => SaveNode())
        {
            text = "行为树序列化二进制"
        });

        root.Add(new Button((() => { NPBTFactory.GetOrCreateNPBehave("monster01"); }))
        {
            text = "测试反序列化"
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
            graph.Save(treeGenData);
        }
    }
}

[SerializeField]
public class NpTreeGraphGenData
{
    //行为树保存路径
    public string OutputBTBytesDir;

    //行为树保存后缀
    public string OutputBTBytesFilePosfix;
}