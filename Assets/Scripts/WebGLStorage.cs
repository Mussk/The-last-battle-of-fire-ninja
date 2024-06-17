using System.Runtime.InteropServices;
using UnityEngine;


public class WebGLStorage : MonoBehaviour {


    [DllImport("__Internal")]
    private static extern void SaveData(string key, string value);

    [DllImport("__Internal")]
    private static extern string LoadData(string key);

    [DllImport("__Internal")]
    private static extern void EraseData(string key);

    public static void Save(string key, string value)
    {
        SaveData(key, value);
    }

    public static string Load(string key)
    {
        return LoadData(key);
    }

    public static void Erase(string key) 
    {

        EraseData(key);

    }
}
