using System.IO;
using Sirenix.Serialization;
using UnityEditor;

namespace Plugins.NodeEditor
{
    public class FileUtil
    {
        public static void SaveFile(string path, byte[] finalStr, bool isNeedLog = true)
        {
            var dir = Path.GetDirectoryName(path);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            if (File.Exists(path))
            {
                var rawContent = File.ReadAllBytes(path);
                if (finalStr.Length == rawContent.Length)
                {
                    bool isSame = true;
                    for (int i = 0; i < finalStr.Length; i++)
                    {
                        if (finalStr[i] != rawContent[i])
                        {
                            isSame = false;
                            break;
                        }
                    }

                    if (isSame)
                    {
                        // 相同的内容跳过，避免重新的导入  
#if UNITY_EDITOR
                        if (isNeedLog) UnityEngine.Debug.Log("Output Skip " + path);
#endif
                        return;
                    }
                }
            }

            File.WriteAllBytes(path, finalStr);
#if UNITY_EDITOR
            UnityEditor.AssetDatabase.ImportAsset(path);
            if (isNeedLog) UnityEngine.Debug.Log("Output  " + path);
#endif
        }

        public static void SerializeAndSaveToFile<T>(T obj, string filePath)
        {
            var bytes = SerializationUtility.SerializeValue(obj, DataFormat.Binary);
            var dir = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            // Debug.Log("path2 ++ "+filePath);
            FileUtil.SaveFile(filePath, bytes);
            AssetDatabase.Refresh();
        }
    }

    public static class ArrayExtention
    {
        public static bool EqualsEx(this byte[] arra, byte[] arrb)
        {
            if ((arra == null) != (arrb == null)) return false;
            if (arra == null)
            {
                return true;
            }

            var count = arra.Length;
            if (count != arrb.Length)
            {
                return false;
            }

            for (int i = 0; i < count; i++)
            {
                if (arra[i] != arrb[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool EqualsEx<T>(this T[] arra, T[] arrb) where T : class
        {
            if ((arra == null) != (arrb == null)) return false;
            if (arra == null)
            {
                return true;
            }

            var count = arra.Length;
            if (count != arrb.Length)
            {
                return false;
            }

            for (int i = 0; i < count; i++)
            {
                var a = arra[i];
                var b = arrb[i];
                if ((a == null) != (b == null)) return false;
                if (a == null)
                {
                    continue;
                }

                if (!a.Equals(b))
                {
                    return false;
                }
            }

            return true;
        }
    }
}