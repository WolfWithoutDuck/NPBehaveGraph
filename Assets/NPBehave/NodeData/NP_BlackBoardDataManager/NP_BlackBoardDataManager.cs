using System.Collections.Generic;

namespace NPBehave
{
    /// <summary>
    /// 单个Canvas数据处理器
    /// </summary>
    public class NP_BlackBoardDataManager
    {
        public Dictionary<string, object> BBValues = new Dictionary<string, object>();

        public List<string> EventValue = new List<string>();

        public Dictionary<string, long> Ids = new Dictionary<string, long>();

#if UNITY_EDITOR
        public static NP_BlackBoardDataManager CurrentEditedNP_BlackBoardDataManager;
#endif
    }
}