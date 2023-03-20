using System.Collections.Generic;
using GraphProcessor;
using UnityEngine;

namespace Plugins.NodeEditor
{
    [NodeCustomEditor(typeof(NP_NodeBase))]
    public class NP_NodeView : BaseNodeView
    {
        [HideInInspector] public NP_NodeBase NpNodeBase;

        [HideInInspector] public NP_NodeView Parent;

        [HideInInspector] public List<NP_NodeView> Children = new List<NP_NodeView>();

        public int ChildCount
        {
            get
            {
                if (this.Children == null)
                {
                    return 0;
                }

                return this.Children.Count;
            }
        }

        /// <summary>
        /// 节点的Rect信息，由于UIElement的特性，当前帧赋值并不会修改到真正的Pos，要等它自己刷新才可以，所以我们逻辑层做一个结果缓存
        /// </summary>
        public Rect CachedPositionRect => m_curPositionRect;

        private Rect m_curPositionRect = Rect.zero;
        public Rect CachedSizeRect => this.GetPosition();

        public void SetPositionRect(Rect positionRect)
        {
            m_curPositionRect = positionRect;
        }

        public override void Enable()
        {
            NpNodeBase = this.nodeTarget as NP_NodeBase;
            m_curPositionRect = NpNodeBase.position;
            //TODO 增加节点数据类后去除注释
            // NP_NodeDataBase nodeDataBase = (this.nodeTarget as NP_NodeBase).NP_GetNodeData();
            // TextField textField = new TextField() { value = nodeDataBase.NodeDes };
            // textField.style.marginTop = 4;
            // textField.style.marginBottom = 4;
            // textField.RegisterValueChangedCallback((changedDes) => { nodeDataBase.NodeDes = changedDes.newValue; });
            // controlsContainer.Add(textField);
        }
    }
}