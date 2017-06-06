using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

[RequireComponent(typeof(PostProcessingBehaviour))]
public class DrunknessFX : MonoBehaviour {

    public PostProcessingProfile Drunkness;

    float Random_intensity;
    float Random_aperture;
    float Random_bloom;
    float Random_Time;

    float Timer = 0f;

    private void Start()
    {
        Random_Time = 5f;
        Random_aperture = 2f;
        Random_bloom = 0f;
        Random_intensity = 0f;
    }

    void Update()
    {
        print("intensity:" + " " + Drunkness.chromaticAberration.settings.intensity);

        Timer += Time.deltaTime;
        if(Timer > Random_Time)
        {
            Random_intensity = Random.Range(0f, ((StaticHolder.DrunknessLevel) / 10f));
            Random_bloom = Random.Range(0f, (StaticHolder.DrunknessLevel));
            Random_aperture = Random.Range(2f - ((StaticHolder.DrunknessLevel) / 5f), 2f);
            Random_Time = Random.Range(1f, 10f - (StaticHolder.DrunknessLevel));
            Timer = 0f;
        }
        
        

        ChromaticAbberation();
        DepthOfField();
    }

    void ChromaticAbberation()
    {
        var chromaberration = Drunkness.chromaticAberration.settings;
        chromaberration.intensity = 0f + Random_intensity;
        Drunkness.chromaticAberration.settings = chromaberration;
    }

    void DepthOfField()
    {
        var DepthOfField = Drunkness.depthOfField.settings;
        DepthOfField.aperture = 0 + Random_aperture;
        Drunkness.depthOfField.settings = DepthOfField;
    }

    void Bloom()
    {
        var Bloom = Drunkness.bloom.settings;
        Bloom.bloom.intensity = 0 + Random_intensity;
        Drunkness.bloom.settings = Bloom;
    }
}
