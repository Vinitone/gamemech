using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoulScore : MonoBehaviour
{
    Text text;
    private int soulAmount = 0;

    private static SoulScore instance = null;
     
     // Game Instance Singleton
     public static SoulScore Instance
     {
         get
         { 
             return instance; 
         }
     }
     
     private void Awake()
     {
         // if the singleton hasn't been initialized yet
         if (instance != null && instance != this) 
         {
             Destroy(this.gameObject);
         }
 
         instance = this;
         DontDestroyOnLoad( this.gameObject );
     }
    public int SoulAmount
    {
        
        get{
            return soulAmount;
        } 
        set{
            soulAmount = value;
        }
    }
    void Start()
    {
        text = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = soulAmount.ToString();
    }
}
