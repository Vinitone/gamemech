using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class SanityController : MonoBehaviour
{
    [SerializeField]
    private GameObject _postProcessing;

    private PostProcessProfile _postProcessProfile;
    private Vignette _vignette;
    
    private int _sanity = 100;
    
    // Start is called before the first frame update
    void Start()
    {
        var volume = this._postProcessing.GetComponent<PostProcessVolume>();
        
        this._postProcessProfile = volume.profile;
        this._vignette = this._postProcessProfile.GetSetting<Vignette>();
    }

    // Update is called once per frame
    void Update()
    {
        this._vignette.intensity.SetValue()
      
        Debug.Log("test");
    }
}
