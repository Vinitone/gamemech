﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class SanityController : MonoBehaviour
{
    [SerializeField]
    public GameObject postProcessing;

    private PostProcessProfile _postProcessProfile;
    private Vignette _vignette;

    private bool _enabled;
    
    [Range(0f,100f)]
    public float _sanity = 100;
    
    private float _lastKnowSanity = 100f;

    [Range(0f,1f)]
    public float minimalShade;
    
    [Range(0f,1f)]
    public float maximalShade;

    private float _shadeModifier;
    
    
    // Start is called before the first frame update
    void Start()
    {
        PostProcessVolume volume = this.postProcessing.GetComponent<PostProcessVolume>();
        
        this._postProcessProfile = volume.profile;

        if (this._postProcessProfile == null)
        {
            this._enabled = false;
            return;
        }

        this._enabled = this._postProcessProfile.TryGetSettings<Vignette>(out _vignette);

        if (this._enabled)
        {
            this._vignette.intensity.value = this.minimalShade;

            float totalShadeAmmount = this.maximalShade - this.minimalShade;
            this._shadeModifier = totalShadeAmmount / 100;
        }
    }

    // Update is called once per framewwww
    void Update()
    {
        if (!this._enabled)
        {
            return;
        }

        if (this._lastKnowSanity == this._sanity)
        {
            return;
        }
        
        this._vignette.intensity.value = this._shadeModifier * (100f - this._sanity);

        this._lastKnowSanity = this._sanity;
    }
}
