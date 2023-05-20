using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateTest : MonoBehaviour
{
    private Animator mAnimator;

    void Start()
    {
        mAnimator = GetComponent<Animator>();
    }
    public void Update()
    {
        if (mAnimator != null)
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                mAnimator.SetTrigger("openTrigger");
            }
            if (Input.GetKeyDown(KeyCode.O))
            {
                mAnimator.SetTrigger("closeTrigger");
            }
        }
    }

}
