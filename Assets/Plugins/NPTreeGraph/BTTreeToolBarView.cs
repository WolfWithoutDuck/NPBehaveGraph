using GraphProcessor;
using UnityEditor;
using UnityEngine;

namespace NPTreeGraph
{
    public class BTTreeToolBarView : ToolbarView
    {
        public BTTreeToolBarView(BaseGraphView graphView) : base(graphView)
        {
        }

        protected override void AddButtons()
        {
            AddButton("Hello !", () => Debug.Log("Hello World"), left: false);
            AddButton("Show In Project", () => EditorGUIUtility.PingObject(graphView.graph), false);
            // base.AddButtons();
        }
    }
}