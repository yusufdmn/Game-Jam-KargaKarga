using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GlowEffect : MonoBehaviour
{
    [SerializeField] Light2D light2D;
    int multiplier;
    void Start()
    {
        light2D = GetComponent<Light2D>();
        light2D.pointLightOuterRadius = 0.5f;
    }

    void Update()
    {   
        light2D.pointLightOuterRadius += (Time.deltaTime * multiplier);
        
        if(light2D.pointLightOuterRadius > 0.9f ){
            multiplier = -1;
        }
        else if(light2D.pointLightOuterRadius <= 0.5f){
            multiplier = 1;
        }
    }
}