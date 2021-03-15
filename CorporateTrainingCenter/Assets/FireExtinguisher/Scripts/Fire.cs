using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DigitalRuby.PyroParticles;
using System;

public class Fire : MonoBehaviour
{
    [Flags]
    public enum Class
    {
        none = 0,
        A = 1 << 1,
        B = 1 << 2,
        C = 1 << 3,
        D = 1 << 4,
        K = 1 << 5,        
    }
    [SerializeField] Fire.Class _class;

    public Fire.Class SharedClass
    {
        get
        {
            return _class;
        }
    }

    public float startSize = 10;

    public float scaleFactor = 0.01f;

    private float currentSize;

    bool putOut = false;

    public UnityEvent OnExtinguish;
    public float Size
    {
        get
        {
            return currentSize;
        }
    }


    [SerializeField]
    private AudioSource fireSound;

    [SerializeField]
    private Transform fireTransform;

    [SerializeField]
    private FireLightScript fireLightScript;

    [SerializeField]
    private Light fireLight;

    public UnityEvent OnVerified;

    void OnEnable()
    {
        currentSize = startSize;
    }

    // Update is called once per frame
    void Update()
    {
        float scaleMod = scaleFactor * currentSize;
        fireTransform.localPosition = currentSize / startSize * Vector3.up * scaleMod;
        fireTransform.localScale = currentSize / startSize * Vector3.one * scaleMod;
        fireSound.volume = currentSize / startSize;
        fireLightScript.IntensityModifier = currentSize / startSize;
        fireLight.enabled = !IsOut();
    }

    public void PutOut(float amount)
    {
        currentSize = Mathf.Max(0, currentSize - amount);
        if(Size == 0 && !putOut)
        {
            OnExtinguish?.Invoke();
            putOut = true;
            this.gameObject.SetActive(false);
        }
    }


    public bool IsOut()
    {
        return currentSize == 0;
    }

    
}
