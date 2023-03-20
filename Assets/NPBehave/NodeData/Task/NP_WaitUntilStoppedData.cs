using MainCore;

namespace NPBehave
{
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