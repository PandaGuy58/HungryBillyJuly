using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenerationParent : MonoBehaviour
{
    [HideInInspector] public string generationTemplateName;
    [HideInInspector] public ObjectPool waterPool;

    [HideInInspector] public int size = 10;
    public virtual void GenerateMap(ObjectPool primaryTerrainPool, ObjectPool roadPool)
    {

    }

    public virtual void Initialise(ObjectPool targetWaterPool)
    {
        waterPool = targetWaterPool;
    }

}
