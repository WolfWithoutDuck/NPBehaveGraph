using System.Collections;
using System.Collections.Generic;
using GraphProcessor;
using NPTreeGraph;
using UnityEngine;
using UnityEngine.UIElements;

public class BTGraphWindow : BaseGraphWindow
{
    public VisualTreeAsset behaviourTreeXml;
    public VisualTreeAsset nodeXml;


    protected override void InitializeWindow(BaseGraph graph)
    {
        titleContent = new GUIContent("BT Graph");

        if (graphView == null)
        {
            graphView = new BTGraphView(this);
            graphView.Add(new MiniMapView(graphView));
            graphView.Add(new BTTreeToolBarView(graphView));
        }

        rootView.Add(graphView);
    }
}