using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using System.Linq;

public class ObjectPoolingManager : MonoBehaviour
{
    public static List<objectPoolInfo> objectpools = new List<objectPoolInfo>();

    public static GameObject SpawnGameObject(GameObject obj , Vector3 startPosition , quaternion startRotation)
    {
        objectPoolInfo pool = objectpools.Find(p => p.lockUpString == obj.name);

        if (pool == null)
        {
            pool = new objectPoolInfo() { lockUpString = obj.name };
            objectpools.Add(pool);
        }

        GameObject spwanObject = pool.inactiveGameObject.FirstOrDefault();

        if (spwanObject == null)
        {
            spwanObject =  Instantiate(obj , startPosition , startRotation);
        }
        else
        {
            spwanObject.transform.position = startPosition;
            spwanObject.transform.rotation = startRotation;
            pool.inactiveGameObject.Remove(spwanObject);
            spwanObject.SetActive(true);
        }

        return obj;
    }

    public static void ReturnGameObjectToPool(GameObject obj)
    {
        string goName = obj.name.Substring(0, obj.name.Length - 7);
        objectPoolInfo pool = objectpools.Find(p => p.lockUpString == goName);
        if(pool == null)
        {
            Debug.Log("Warning you are trying to acsess a non exist object");
        }
        else
        {
            obj.SetActive(false);
            pool.inactiveGameObject.Add(obj);
        }
    }
}

public class objectPoolInfo
{
    public string lockUpString;
    public List<GameObject> inactiveGameObject = new List<GameObject>();
}
