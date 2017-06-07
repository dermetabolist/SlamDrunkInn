using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.PostProcessing;

[RequireComponent(typeof(PostProcessingBehaviour))]
public class DrunknessFX : MonoBehaviour {

    public PostProcessingProfile Drunkness;

    float Random_intensity;
    float Random_aperture;
    float Random_bloom;
    float Random_Time;
    float Random_TimeScale;
    float Random_Pitch;

    float Timer = 0f;

    public AudioMixer Master;

    private void Start()
    {
        Random_Time = 5f;
        Random_TimeScale = 1f;
        Random_aperture = 2f;
        Random_bloom = 0f;
        Random_intensity = 0f;
        Random_Pitch = 100f;

    }

    void Update()
    {
        
        if(StaticHolder.TimeOver == false) //führe alles aus, solange die zeit abläuft
        {
            Timer += Time.deltaTime;
            if (Timer > Random_Time)
            {
                Random_intensity = Random.Range(0f, ((StaticHolder.DrunknessLevel) / 10f));
                Random_bloom = Random.Range(0f, (StaticHolder.DrunknessLevel));
                Random_aperture = Random.Range(2f - ((StaticHolder.DrunknessLevel) / 5f), 2f);
                Random_Time = Random.Range(1f, 10f - (StaticHolder.DrunknessLevel));
                Random_TimeScale = Random.Range(1f - ((StaticHolder.DrunknessLevel) / 10f), 1f + ((StaticHolder.DrunknessLevel) / 10f));
                Random_Pitch = ((Random_TimeScale));
                Timer = 0f;
            } 
        }

        else //normalisiere alle werte
        {
            Time.timeScale = 1f;
            Random_TimeScale = 1;
            Random_intensity = 0;
            Random_aperture = 2;
            Random_bloom = 0f;
        }

        ChromaticAbberation();
        DepthOfField();
        TimeScale();
        SetPitch(1);


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

    void TimeScale()
    {
        Time.timeScale = Random_TimeScale;
    }

    public void SetPitch(float Pitch)
    {
        //Pitch = 0.5f;
        Master.SetFloat("MasterPitch", Random_TimeScale);
    }

    
}
