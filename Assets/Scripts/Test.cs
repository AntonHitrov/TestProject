using UnityEngine;
using System.Collections;
using System.Linq;
using Data;
using System.IO;
using UnityEditor;

public class Test : MonoBehaviour
{

#if UNITY_EDITOR
    [MenuItem("Tools/Write OUT")]
    static void WriteOUT()
    {
        TextAsset IN = Resources.Load<TextAsset>("IN");
        var json = Geo.Serialise(Geo.GetGeoData(IN.text).features.Select(value => new OutData(value)).ToList());
        string path = "Assets/Resources/OUT.txt";
        StreamWriter writer = new StreamWriter(path, false);
        writer.Write(json);
        writer.Close();
        AssetDatabase.ImportAsset(path);
    }
#endif
}
