using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftBoxLabel : MonoBehaviour
{
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        changeLabel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void changeLabel()
    {
        anim.SetInteger("option", Random.Range(1, 4));
    }
}
