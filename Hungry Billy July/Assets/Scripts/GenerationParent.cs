using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenerationParent : MonoBehaviour
{                                                               // base class for generation
    [HideInInspector] public string generationTemplateName;     // name
    [HideInInspector] public ObjectPool waterPool;              // key pool to get objects

    [HideInInspector] public int size = 10;                          // key function to override by children
    public virtual void GenerateMap(ObjectPool primaryTerrainPool, ObjectPool roadPool)    
    {

    }

    public virtual void Initialise(ObjectPool targetWaterPool)      // reference to water
    {
        waterPool = targetWaterPool;
    }

}
