using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Generation : MonoBehaviour
{
    //  public List<GameObject> primaryTerrains;
    // Start is called before the first frame update
   // public List<GenerationBiome> generationBiomes = new List<GenerationBiome>();
    //List<string> generationChoices = new List<string>() { "River", "Island", "Lake" };
  //  public list


    public List<GenerationParent> availableGenerationTemplates;
    public TMP_Dropdown templateDropdown;

    public List<GenerationBiome> availableBiomes;
    public TMP_Dropdown biomeDropdown;

    public GameObject water;
    public ObjectPool waterPool;

    int generationTemplateIndex = 0;
    int generationBiomeIndex = 0;

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
        }

        biomeDropdown.AddOptions(biomeTemplateNames);
    }


    public void UIChanged()
    {
        generationTemplateIndex = templateDropdown.value;
        generationBiomeIndex = biomeDropdown.value;
    }
}


