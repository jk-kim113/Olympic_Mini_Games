using System;
using System.Collections.Generic;
using UnityEngine;

public class ResourcePoolManager : TSingleton<ResourcePoolManager>
{
    public enum eResourceKind
    {
        UI,

        max
    }

    Dictionary<eResourceKind, Dictionary<string, object>> _resourceData = new Dictionary<eResourceKind, Dictionary<string, object>>();

    protected override void Init()
    {
        base.Init();
    }

    public T GetObj<T>(eResourceKind kind, string name) where T : class
    {
        if (_resourceData.ContainsKey(kind))
        {
            if (_resourceData[kind].ContainsKey(name))
            {
                object o = _resourceData[kind][name];
                return (T)Convert.ChangeType(o, typeof(T));
            }
        }

        return null;
    }

    void LoadData<T>(eResourceKind kind, eTableType type) where T : class
    {
        Dictionary<string, object> tempDic = new Dictionary<string, object>();

        TableBase tb = TableManager._instance.Get(type);

        foreach(string key in tb._datas.Keys)
        {
            object o = Resources.Load(tb._datas[key]["Location"]);
            T obj = (T)Convert.ChangeType(o, typeof(T));
            tempDic.Add(tb._datas[key]["Name"], obj);
        }

        _resourceData.Add(kind, tempDic);
    }

    public void ResourceAllLoad()
    {
        LoadData<GameObject>(eResourceKind.UI, eTableType.UIData);
    }
}
