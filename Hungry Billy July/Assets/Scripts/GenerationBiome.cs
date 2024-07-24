using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GenerationBiome
{
    public string biomeName;
    public GameObject primaryTerrain;
    public List<GameObject> plants;

    public ObjectPool targetObjectPool;
}
