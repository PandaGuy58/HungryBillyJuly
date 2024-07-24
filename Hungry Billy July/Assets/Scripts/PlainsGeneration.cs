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

    public override void GenerateMap(ObjectPool primaryTerrainPool, ObjectPool roadPool)
    {
        List<GameObject> freeLand = new List<GameObject>();         
        for(int x = 0; x < size; x++)           // loop based on the size of generation
        {
            for (int z = 0; z < size; z++)
            {
                GameObject gameObject = primaryTerrainPool.RequestObject();     // request object from pool
                Vector3 targetPosition = new Vector3(x, 0, z);      // calculate + change position
                gameObject.transform.position = targetPosition;
                gameObject.transform.parent = transform;
                gameObject.name = string.Format("{0}, {1}.{2}", primaryTerrainPool.prefab.name, x, z);

                freeLand.Add(gameObject);
            }

        }

        GameObject targetLand = freeLand[Random.Range(0, freeLand.Count)];      // change one of the tiles into road
        Vector3 targetCoordinate = targetLand.transform.position;
        targetLand.SetActive(false);
        
        GameObject road = roadPool.RequestObject();
        road.transform.position = targetCoordinate;
    }

}
