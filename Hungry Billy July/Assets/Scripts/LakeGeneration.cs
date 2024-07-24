using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LakeGeneration : GenerationParent
{
    List<Vector2> possibleNextLocation = new List<Vector2>();
    public override void Initialise(ObjectPool targetWaterPool)
    {
        base.Initialise(targetWaterPool);
        generationTemplateName = "Lake";

        possibleNextLocation.Add(new Vector2(0, -1));       // allows the generation to choose next tile to turn into water
        possibleNextLocation.Add(new Vector2(0, 1));
        possibleNextLocation.Add(new Vector2(1, 0));
        possibleNextLocation.Add(new Vector2(-1, 0));
    }

    public override void GenerateMap(ObjectPool primaryTerrainPool, ObjectPool roadPool)
    {
        List<Vector2> waterLocations = new List<Vector2>();     // generates a list of target water locations
        int xCoordinate = Random.Range(2, 7);
        int zCoordinate = Random.Range(2, 7);
        waterLocations.Add(new Vector2(xCoordinate, zCoordinate));

        Vector2 currentLocation = waterLocations[0];
        Vector2 nextLocation;

        while(waterLocations.Count != 10)                       // looped until 10 water locations are designates
        {
            nextLocation = currentLocation + possibleNextLocation[Random.Range(0, possibleNextLocation.Count)];
            if((nextLocation.x > 1 && nextLocation.x < 8) && (nextLocation.y > 1 && nextLocation.y < 8))        // prevents to reach the edges
            {
                currentLocation = nextLocation;
                if(!waterLocations.Contains(currentLocation))       // if location is not used  >  added to water location list
                {
                    waterLocations.Add(currentLocation);
                }
            }
        }

        List<GameObject> freeLand = new List<GameObject>();
        for (int x = 0; x < size; x++)
        {
            for (int z = 0; z < size; z++)      // loop based on size
            {
                Vector2 checkWaterLocation = new Vector2(x, z);
                GameObject gameObject;

                if (waterLocations.Contains(checkWaterLocation))        // if in the water list  >  spawn water
                {
                    gameObject = waterPool.RequestObject();
                }
                else
                {
                    gameObject = primaryTerrainPool.RequestObject();        // otherwise spawn terrain
                    freeLand.Add(gameObject);
                }
                
                Vector3 targetPosition = new Vector3(x, 0, z);      // calculate coordinate
                gameObject.transform.position = targetPosition;
                gameObject.transform.parent = transform;
                gameObject.name = string.Format("{0}, {1}.{2}", primaryTerrainPool.prefab.name, x, z);


            }
        }

        GameObject targetLand = freeLand[Random.Range(0, freeLand.Count)];      // set a tile into road
        Vector3 targetCoordinate = targetLand.transform.position;
        targetLand.SetActive(false);

        GameObject road = roadPool.RequestObject();
        road.transform.position = targetCoordinate;
    }
}
