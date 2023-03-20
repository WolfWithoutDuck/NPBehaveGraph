using UnityEngine;

namespace NPBehave
{
    public class NP_LogAction : NP_ClassForStoreAction
    {
        public string LogInfo = "123 ";

        public override System.Action GetActionToBeDone()
        {
            this.Action = this.TestLog;
            return this.Action;
        }

        public void TestLog()
        {
            Debug.Log(LogInfo);
        }
    }
}