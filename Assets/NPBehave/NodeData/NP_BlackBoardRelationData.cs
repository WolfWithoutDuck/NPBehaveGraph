using System.Collections.Generic;

namespace NPBehave
{
    public class NP_BlackBoardRelationData
    {
        public string BBKey;

        public bool WriteOrCompareToBB;

        public string NP_BBValueType;
        public object NP_BBValue;

#if UNITY_EDITOR
        private IEnumerable<string> GetBBKeys()
        {
            if (NP_BlackBoardDataManager.CurrentEditedNP_BlackBoardDataManager != null)
            {
                return NP_BlackBoardDataManager.CurrentEditedNP_BlackBoardDataManager.BBValues.Keys;
            }

            return null;
        }

        private void OnBBKeySelected()
        {
            if (NP_BlackBoardDataManager.CurrentEditedNP_BlackBoardDataManager != null)
            {
                foreach (var bbValues in NP_BlackBoardDataManager.CurrentEditedNP_BlackBoardDataManager.BBValues)
                {
                    if (bbValues.Key == this.BBKey)
                    {
                        //TODO 这里只是简单的复制，后面修改成肛少的深复制
                        NP_BBValue = bbValues.Value;
                        NP_BBValueType = NP_BBValue.GetType().ToString();
                    }
                }
            }
        }
#endif
        /// <summary>
        /// 根据Key获取黑板值
        /// </summary>
        /// <param name="blackboard"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetBlackBoardValue<T>(Blackboard blackboard)
        {
            return blackboard.Get<T>(this.BBKey);
        }

        /// <summary>
        /// 获取配置的BB值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetTheBBDataValue<T>()
        {
            return (T)NP_BBValue;
        }

        /// <summary>
        /// 自动根据预先设定的值设置值
        /// </summary>
        /// <param name="blackboard"></param>
        public void SetBlackBoardValue(Blackboard blackboard)
        {
            blackboard.Set(BBKey, NP_BBValue);
        }

        /// <summary>
        /// 自动根据传来的值设置值
        /// </summary>
        /// <param name="blackboard"></param>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        public void SetBlackBoardValue<T>(Blackboard blackboard, T value)
        {
            blackboard.Set(BBKey, value);
        }

        /// <summary>
        /// 自动将一个黑板的对应key的value设置到另一个黑板上
        /// </summary>
        /// <param name="oriBB">数据源黑板</param>
        /// <param name="desBB">目标黑板</param>
        public void SetBBValueFromThisBBValue(Blackboard oriBB, Blackboard desBB)
        {
            desBB.Set(BBKey, oriBB.Get(BBKey));
        }
    }
}