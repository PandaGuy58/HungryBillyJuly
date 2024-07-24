using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenerationParent : MonoBehaviour
{
    [HideInInspector] public string generationTemplateName;
    [HideInInspector] ObjectPool waterPool;
    public virtual void GenerateMap(ObjectPool primaryTerrainPool)
    {

    }

    public virtual void Initialise(ObjectPool targetWaterPool)
    {
        waterPool = targetWaterPool;
    }

}
