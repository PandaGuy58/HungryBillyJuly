using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [HideInInspector] public GameObject prefab;     // object to pool

    public List<GameObject> allObjects = new List<GameObject>();        // all objects in the pool
    public List<GameObject> availableObjects = new List<GameObject>();      // objects not in use
    public void InitialisePool(GameObject targetPrefab)
    {
        prefab = targetPrefab;
    }

    public GameObject RequestObject()           // when no object in pool  >  instantiate new
    {
        if(availableObjects.Count == 0)
        {
            GameObject newObject = Instantiate(prefab, Vector3.zero, Quaternion.identity);
            allObjects.Add(newObject);
            return newObject;
        }
        else                                        // otherwise select object  +  remove from pool
        {
            GameObject gameObject = availableObjects[0];        
            gameObject.SetActive(true);
            availableObjects.RemoveAt(0);
            return gameObject;
        }
    }

    public void ResetPool()                             // all objects made available and deactivated
    {
        availableObjects = new (allObjects);
        for(int i = 0; i < availableObjects.Count; i++)
        {
            availableObjects[i].transform.parent = transform;
            availableObjects[i].SetActive(false);
        }
    }

}
