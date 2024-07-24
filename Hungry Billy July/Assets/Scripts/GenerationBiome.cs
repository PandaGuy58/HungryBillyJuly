using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GenerationBiome
{                                   // serializable class to allow dynamic expansion for future biomes
    public string biomeName;
    public GameObject primaryTerrain;
    public List<GameObject> plants;

    public ObjectPool targetObjectPool;

}
