using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator _animator;
    public bool walking;

    // Start is called before the first frame update
    void Start()
    {
        this._animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        this._animator.SetFloat("walking_speed",Input.GetAxis("Horizontal"));
        
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
        {
            this._animator.SetBool("running",true);
        }
        else
        {
            this._animator.SetBool("running",false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            this._animator.SetTrigger("jump");
        }
        
        if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.LeftShift))
        {
            this._animator.SetBool("glide",true);
        }
        else
        {
            this._animator.SetBool("glide",false);
        }

        
        if (Input.GetKeyUp(KeyCode.Space))
        {
            this._animator.SetTrigger("landing");
        }
    }
}
