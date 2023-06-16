using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class People : Props
{
    private Animator[] anim;

    private void OnEnable()
    {
        anim = GetComponentsInChildren<Animator>();    
    }

    private void Update()
    {
        foreach (var a in anim)
        {
            a.SetBool("isPlace", isGrounded);
        }
    }
}
