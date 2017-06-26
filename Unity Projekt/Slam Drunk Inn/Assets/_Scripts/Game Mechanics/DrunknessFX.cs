using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.PostProcessing;

[RequireComponent(typeof(PostProcessingBehaviour))]
public class DrunknessFX : MonoBehaviour {

    public PostProcessingProfile Drunkness;

    float Random_chromaticAbberation_intensity;

    //float Random_aperture;
    //float Random_frameBleeding;
    //float Random_bloom;
    float Random_Saturation;
    //float Random_grain;
    //float Random_vignette;

    float Random_Time1;
    //float Random_Time2;
    //float Random_Time3;
    float Random_Time4;
    //float Random_Time5;

    float Random_TimeScale;
    float Random_Pitch;

    float Random_Color1;
    float Random_Color2;
    float Random_Color3;

    float Timer1 = 0f;
    //float Timer2 = 0f;
    //float Timer3 = 0f;
    float Timer4 = 0f;
    //float Timer5 = 0f;

    public AudioMixer Master;

    Color Random_Col;

    void OnEnable()
    {
        var behaviour = GetComponent<PostProcessingBehaviour>();

        if (behaviour.profile == null)
        {
            enabled = false;
            return;
        }

        Drunkness = Instantiate(behaviour.profile);
        behaviour.profile = Drunkness;
    }


    private void Start()
    {
        Random_Time1 = 5f;
        //Random_Time2 = 5f;
        //Random_Time3 = 5f;
        Random_Time4 = 5f;
        //Random_Time5 = 5f;

        Random_TimeScale = 1f;
        //Random_aperture = 12f;
        //Random_bloom = 0f;
        Random_chromaticAbberation_intensity = 0f;
        Random_Saturation = 1;

        Random_Pitch = 100f;
    }

    void Update()
    {
        if(CamShakeSimple.CameraIsShaking == true)
        {
            Random_Color1 = UnityEngine.Random.Range(-2f, 2f);
            Random_Color2 = UnityEngine.Random.Range(-2f, 2f);
            Random_Color3 = UnityEngine.Random.Range(-2f, 2f);
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
            Timer1 += Time.deltaTime;
            //Timer2 += Time.deltaTime;
            //Timer3 += Time.deltaTime;
            Timer4 += Time.deltaTime;
            //Timer5 += Time.deltaTime;

            if (Timer1 > Random_Time1)
            {
                Random_Time1 = UnityEngine.Random.Range(1f, 10f - (StaticHolder.DrunknessLevel)); //Zufällige Zeit zwischen 1 & 10 - Drunk Level
                Random_chromaticAbberation_intensity = UnityEngine.Random.Range(0f, ((StaticHolder.DrunknessLevel) / 10f)); 
                //Random_frameBleeding = StaticHolder.DrunknessLevel*0.1f;
                //Random_grain = StaticHolder.DrunknessLevel * 0.1f;   
                Random_TimeScale = UnityEngine.Random.Range(1f - ((StaticHolder.DrunknessLevel) / 10f), 1f + ((StaticHolder.DrunknessLevel) / 20f));
                Random_Pitch = ((Random_TimeScale));
                Timer1 = 0f;
            }
            //if (Timer2 > Random_Time2)
            //{
            //    Random_Time2 = UnityEngine.Random.Range(1f, 10f - (StaticHolder.DrunknessLevel));
            //    //Random_aperture = UnityEngine.Random.Range(12, 12 - StaticHolder.DrunknessLevel / 2f);
            //    Timer2 = 0f;
            //}
            //if (Timer3 > Random_Time3)
            //{
            //    Random_Time3 = UnityEngine.Random.Range(1f, 10f - (StaticHolder.DrunknessLevel));
            //    //Random_bloom = UnityEngine.Random.Range(0f, (StaticHolder.DrunknessLevel / 4f));
            //    Timer3 = 0f;
            //}
            if (Timer4 > Random_Time4)
            {
                Random_Time4 = UnityEngine.Random.Range(1f, 10f - (StaticHolder.DrunknessLevel));
                Random_Saturation = UnityEngine.Random.Range(1 - (StaticHolder.DrunknessLevel * 0.1f), 1 + (StaticHolder.DrunknessLevel * 0.1f));
                Timer4 = 0f;
            }
            //if (Timer5 > Random_Time5)
            //{
            //    Random_Time5 = UnityEngine.Random.Range(1f, 10f - (StaticHolder.DrunknessLevel));
            //    //Random_vignette = UnityEngine.Random.Range(0, StaticHolder.DrunknessLevel * 0.05f);
            //    Timer5 = 0f;
            //}
        }

        if (StaticHolder.TimeOver == true || StaticHolder.GameWon == true) //normalisiere alle werte
        {
            Time.timeScale = 1f;
            Random_TimeScale = 1;
            Random_chromaticAbberation_intensity = 0;
            //Random_aperture = 12;
            //Random_bloom = 0f;
            //Random_grain = 0f;
            //Random_vignette = 0;
            Random_Saturation = 1;
        }

        //MotionBlur();
        //Grain();

        if (StaticHolder.DrunknessLevel > 0)
        {
            ChromaticAbberation();
            
        }
        if (StaticHolder.DrunknessLevel > 1)
        {
            //DepthOfField();
            TimeScale();
            SetPitch(1);
        }
        if (StaticHolder.DrunknessLevel > 2)
        {
            //Bloom();
            Saturation();
            //Vignette();
        }                      
    }


    void ChromaticAbberation()
    {
        var chromaberration = Drunkness.chromaticAberration.settings;
        chromaberration.intensity = 0f + Random_chromaticAbberation_intensity;
        Drunkness.chromaticAberration.settings = chromaberration;
    }

    //void DepthOfField()
    //{
    //    var DepthOfField = Drunkness.depthOfField.settings;
    //    DepthOfField.aperture = Random_aperture;
    //    Drunkness.depthOfField.settings = DepthOfField;
    //}

    //private void MotionBlur()
    //{
    //    var MotionBlur = Drunkness.motionBlur.settings;
    //    MotionBlur.frameBlending = Random_frameBleeding;
    //    Drunkness.motionBlur.settings = MotionBlur;
    //}

    //void Bloom()
    //{
    //    var Bloom = Drunkness.bloom.settings;
    //    Bloom.bloom.intensity = Random_bloom;
    //    Drunkness.bloom.settings = Bloom;
    //}

    void Saturation()
    {
        var saturation = Drunkness.colorGrading.settings;
        saturation.basic.saturation = Random_Saturation;
        Drunkness.colorGrading.settings = saturation;
    }

    //void Grain()
    //{
    //    var grain = Drunkness.grain.settings;
    //    grain.intensity = Random_grain;
    //    Drunkness.grain.settings = grain;
    //}

    //private void Vignette()
    //{
    //    var vignette = Drunkness.vignette.settings;
    //    vignette.intensity = Random_vignette;
    //    Drunkness.vignette.settings = vignette;
    //}

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
