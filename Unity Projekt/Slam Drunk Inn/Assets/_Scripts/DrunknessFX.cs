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

    float Random_Color1;
    float Random_Color2;
    float Random_Color3;

    float Timer = 0f;

    public AudioMixer Master;

    Color Random_Col;

    private void Start()
    {
        Random_Time = 5f;
        Random_TimeScale = 1f;
        Random_aperture = 3f;
        Random_bloom = 0f;
        Random_intensity = 0f;
        Random_Pitch = 100f;

    }

    void Update()
    {
        if(CamShakeSimple.CameraIsShaking == true)
        {
            Random_Color1 = Random.Range(-2f, 2f);
            Random_Color2 = Random.Range(-2f, 2f);
            Random_Color3 = Random.Range(-2f, 2f);
            ColorGrading();
        }
        else
        {
            Random_Color1 = 1;
            Random_Color2 = 0;
            Random_Color3 = 0;
            ColorGrading();
        }
        
        if(StaticHolder.TimeOver == false) //führe alles aus, solange die zeit abläuft
        {
            Timer += Time.deltaTime;
            if (Timer > Random_Time)
            {
                Random_intensity = Random.Range(0f, ((StaticHolder.DrunknessLevel) / 10f));
                Random_bloom = Random.Range(0f, (StaticHolder.DrunknessLevel));
                Random_aperture = Random.Range(Random_aperture - ((StaticHolder.DrunknessLevel) / 5f), Random_aperture);
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

    void ColorGrading()
    {
        var colgrad = Drunkness.colorGrading.settings;
        colgrad.channelMixer.red = new Vector3(Random_Color1, Random_Color2, Random_Color3);
        Drunkness.colorGrading.settings = colgrad;
    }

    public void SetPitch(float Pitch)
    {
        //Pitch = 0.5f;
        Master.SetFloat("MasterPitch", Random_TimeScale);
    }

    
}
