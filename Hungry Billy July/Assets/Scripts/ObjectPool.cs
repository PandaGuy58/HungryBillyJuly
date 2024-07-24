using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [HideInInspector] public GameObject prefab;

    public List<GameObject> allObjects = new List<GameObject>();
    public List<GameObject> availableObjects = new List<GameObject>();
    public void InitialisePool(GameObject targetPrefab)
    {
        prefab = targetPrefab;
    }

    public GameObject RequestObject()
    {
        if(availableObjects.Count == 0)
        {
            GameObject newObject = Instantiate(prefab, Vector3.zero, Quaternion.identity);
            allObjects.Add(newObject);
            return newObject;
        }
        else
        {
            GameObject gameObject = availableObjects[0];
            gameObject.SetActive(true);
            availableObjects.RemoveAt(0);
            return gameObject;
        }
    }

    public void ResetPool()
    {
        availableObjects = new (allObjects);
        for(int i = 0; i < availableObjects.Count; i++)
        {
            availableObjects[i].transform.parent = transform;
            availableObjects[i].SetActive(false);
        }
    }

}
