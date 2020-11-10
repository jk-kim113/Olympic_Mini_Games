using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TableBase : MonoBehaviour
{
    protected Dictionary<string, Dictionary<string, string>> _sheetData;

    public Dictionary<string, Dictionary<string, string>> _datas
    {
        get
        {
            return _sheetData;
        }
    }

    public abstract void LoadTable(string strJson);

    public void Add(string key, string subKey, string val)
    {
        if (!_sheetData.ContainsKey(key))
        {
            // Save
            _sheetData.Add(key, new Dictionary<string, string>());
        }

        if (!_sheetData[key].ContainsKey(subKey))
        {
            _sheetData[key].Add(subKey, val);
        }
    }

    string GetValue(int key, string subKey)
    {
        string strKey = key.ToString();
        string findVal = string.Empty;

        if (_sheetData.ContainsKey(strKey))
        {
            if (_sheetData[strKey].ContainsKey(subKey))
                findVal = _sheetData[strKey][subKey];
            else
                UnityEngine.Debug.LogWarning("Wrong SubKey : " + subKey);
        }
        else
            UnityEngine.Debug.LogWarning("Wrong Key : " + strKey);

        return findVal;
    }

    public string ToS(int key, string subKey)
    {
        return GetValue(key, subKey);
    }

    public int ToI(int key, string subKey)
    {
        int val = 0;
        int.TryParse(GetValue(key, subKey), out val);

        return val;
    }

    public float ToF(int key, string subKey)
    {
        float val = 0;
        float.TryParse(GetValue(key, subKey), out val);

        return val;
    }
}
