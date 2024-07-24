using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using UnityEngine.UI;

public class Generation : MonoBehaviour
{

    public List<GenerationParent> availableGenerationTemplates;     // different generation classes/functions
    public TMP_Dropdown templateDropdown;                           // UI to choose different generation

    public List<GenerationBiome> availableBiomes;                   // biomes to choose from
    public TMP_Dropdown biomeDropdown;

    public GameObject water;                                        // water prefab + pool
    public ObjectPool waterPool;

    public GameObject road;                                         // road prefab + pool
    public ObjectPool roadPool;

    int generationTemplateIndex = -1;                               // player choice updated through UI
    int generationBiomeIndex = -1;

    ObjectPool targetTerrainPool;                                   // recently selected biome
    public GameObject startGame;                                    // ui 
    public GameObject generationPanel;

    public GameObject startGameButton;


    void Awake()
    {                       
        List<string> generationTemplateNames = new List<string>();      // ui list
        for(int i = 0; i < availableGenerationTemplates.Count; i++)         // iterate through generation classes
        {
            GenerationParent targetGenerationTemplate = availableGenerationTemplates[i];    // initialise generation classes
            targetGenerationTemplate.Initialise(waterPool);
            generationTemplateNames.Add(targetGenerationTemplate.generationTemplateName);
        }

        templateDropdown.AddOptions(generationTemplateNames);           // update ui

        List<string> biomeTemplateNames = new List<string>();           // ui list    
        for(int i = 0; i < availableBiomes.Count; i++)
        {
            GenerationBiome targetBiome = availableBiomes[i];
            biomeTemplateNames.Add(targetBiome.biomeName);

            targetBiome.targetObjectPool.InitialisePool(targetBiome.primaryTerrain);    
        }

        biomeDropdown.AddOptions(biomeTemplateNames);           // update ui

        waterPool.InitialisePool(water);                    // initialise pool
        roadPool.InitialisePool(road);

        UIChanged();
    }


    public void UIChanged()                     // activated by dropdowns
    {
        generationTemplateIndex = templateDropdown.value;
        generationBiomeIndex = biomeDropdown.value;
    }

    public void GenerateMap()               // map generation code
    {
        if (targetTerrainPool != null)          // reset object pools
        {
            targetTerrainPool.ResetPool();
            waterPool.ResetPool();
            roadPool.ResetPool();
        }

        targetTerrainPool = availableBiomes[generationBiomeIndex].targetObjectPool;     // selected the biome class
        GenerationParent targetGenerationTemplate = availableGenerationTemplates[generationTemplateIndex];      // select the generation class

        targetGenerationTemplate.GenerateMap(targetTerrainPool, roadPool);      // execute generation
      //  startGame.SetActive(true);

        startGameButton.SetActive(true);

    }

    public void StartGame()
    {
        generationPanel.SetActive(false);
        startGameButton.SetActive(false);
    }

}


