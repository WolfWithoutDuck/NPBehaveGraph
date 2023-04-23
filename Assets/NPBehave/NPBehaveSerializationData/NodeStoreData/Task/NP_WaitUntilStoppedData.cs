using System;
using MainCore;
using Sirenix.OdinInspector;

namespace NPBehave
{

    [BoxGroup("等待到停止节点数据")]
    [HideLabel]
    public class NP_WaitUntilStoppedData : NP_NodeDataBase
    {
  
        private WaitUntilStopped m_WaitUntilStopped;

        public override Task CreateTaks(Unit unit, NP_RuntimeTree runtimeTree)
        {
            m_WaitUntilStopped = new WaitUntilStopped();
            return m_WaitUntilStopped;
        }


        public override Node NP_GetNode()
        {
            return m_WaitUntilStopped;
        }
    }
}