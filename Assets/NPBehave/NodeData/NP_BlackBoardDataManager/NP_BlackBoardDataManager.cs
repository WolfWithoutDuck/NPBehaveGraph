using System.Collections.Generic;

namespace NPBehave
{
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