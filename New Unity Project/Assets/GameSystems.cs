using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystems : MonoBehaviour {

    private Dictionary<string, object> systemTable = new Dictionary<string, object>();
	 public void Register(object systemInstance, string systemName = null)
    {
        if(string.IsNullOrEmpty(systemName))
        {
            systemName = systemInstance.GetType().Name;
        }
        systemTable[systemName] = systemInstance;
    }

    public T Get<T>(string systemName)
    {
        if(string.IsNullOrEmpty(systemName))
        {
            systemName = typeof(T).Name;
        }

        object systemInstance;

        if(systemTable.TryGetValue(systemName, out systemInstance))
        {
            return (T)systemInstance;
        }
        return default(T);
    }
}
