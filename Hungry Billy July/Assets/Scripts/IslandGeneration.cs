using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandGeneration : GenerationParent
{
    public override void Initialise(ObjectPool targetWaterPool)
    {
        base.Initialise(targetWaterPool);
        generationTemplateName = "Island";
    }

    public override void GenerateMap(ObjectPool primaryTerrainPool)
    {

    }

}
