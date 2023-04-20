using System;

using UnityEngine;

namespace NPBehave
{
    [Serializable]
    public class NP_LogAction : NP_ClassForStoreAction
    {
        [SerializeField]
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