using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunAnim : MonoBehaviour
{
    Animator m_animator;
    
    void Start()
    {
        m_animator = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            m_animator.SetTrigger("Shoot");
        }
    }
}
