using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverGeneration : GenerationParent
{
    public override void Initialise(ObjectPool targetWaterPool)
    {
        base.Initialise(targetWaterPool);
        generationTemplateName = "River";
    }

    public override void GenerateMap(ObjectPool primaryTerrainPool)
    {

    }
}
