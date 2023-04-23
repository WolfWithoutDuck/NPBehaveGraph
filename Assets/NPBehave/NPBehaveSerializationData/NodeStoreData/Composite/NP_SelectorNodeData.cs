﻿using System;
using UnityEngine;


namespace NPBehave
{

    [Serializable]
    public class NP_SelectorNodeData : NP_NodeDataBase
    {
        [HideInInspector]
       private Selector m_SelectorNode;

        public override Composite CreateComposite(Node[] nodes)
        {
            this.m_SelectorNode = new Selector(nodes);
            return this.m_SelectorNode;
        }

        public override Node NP_GetNode()
        {
            return this.m_SelectorNode;
        }
    }
}