using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LakeGeneration : GenerationParent
{
    public override void Initialise(ObjectPool targetWaterPool)
    {
        base.Initialise(targetWaterPool);
        generationTemplateName = "Lake";
    }

    public override void GenerateMap(ObjectPool primaryTerrainPool)
    {

    }
}
