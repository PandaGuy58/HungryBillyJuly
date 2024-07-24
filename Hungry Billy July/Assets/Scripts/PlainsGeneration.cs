using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlainsGeneration : GenerationParent
{
    public override void Initialise(ObjectPool targetWaterPool)
    {
        base.Initialise(targetWaterPool);
        generationTemplateName = "Plains";
    }

    public override void GenerateMap(ObjectPool primaryTerrainPool)
    {

    }

}
