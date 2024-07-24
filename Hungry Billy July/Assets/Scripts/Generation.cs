using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using UnityEngine.UI;

public class Generation : MonoBehaviour
{

    public List<GenerationParent> availableGenerationTemplates;
    public TMP_Dropdown templateDropdown;

    public List<GenerationBiome> availableBiomes;
    public TMP_Dropdown biomeDropdown;

    public GameObject water;
    public ObjectPool waterPool;

    public GameObject road;
    public ObjectPool roadPool;

    int generationTemplateIndex = -1;
    int generationBiomeIndex = -1;

    ObjectPool targetTerrainPool;
    public GameObject startGame;
    public GameObject generationPanel;

    public GameObject startGameButton;


    void Awake()
    {                     // initialise generation template
        List<string> generationTemplateNames = new List<string>();
        for(int i = 0; i < availableGenerationTemplates.Count; i++)
        {
            GenerationParent targetGenerationTemplate = availableGenerationTemplates[i];
            targetGenerationTemplate.Initialise(waterPool);
            generationTemplateNames.Add(targetGenerationTemplate.generationTemplateName);
        }

        templateDropdown.AddOptions(generationTemplateNames);

        List<string> biomeTemplateNames = new List<string>();
        for(int i = 0; i < availableBiomes.Count; i++)
        {
            GenerationBiome targetBiome = availableBiomes[i];
            biomeTemplateNames.Add(targetBiome.biomeName);

            targetBiome.targetObjectPool.InitialisePool(targetBiome.primaryTerrain);
        }

        biomeDropdown.AddOptions(biomeTemplateNames);

        waterPool.InitialisePool(water);
        roadPool.InitialisePool(road);

        UIChanged();
    }


    public void UIChanged()
    {
        generationTemplateIndex = templateDropdown.value;
        generationBiomeIndex = biomeDropdown.value;
    }

    public void GenerateMap()
    {
        if (targetTerrainPool != null)
        {
            targetTerrainPool.ResetPool();
            waterPool.ResetPool();
            roadPool.ResetPool();
        }

        targetTerrainPool = availableBiomes[generationBiomeIndex].targetObjectPool;
        GenerationParent targetGenerationTemplate = availableGenerationTemplates[generationTemplateIndex];

        targetGenerationTemplate.GenerateMap(targetTerrainPool, roadPool);
      //  startGame.SetActive(true);

        startGameButton.SetActive(true);

    }

    public void StartGame()
    {
        generationPanel.SetActive(false);
        startGameButton.SetActive(false);
    }

}


