using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.EventSystems; 

public class ScreenClick : MonoBehaviour
{ 
    PlayerJump pj;

    void Awake() {
        pj = GameObject.Find("Player").GetComponent<PlayerJump>();
    }

    void Update() {
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began && !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)) {
                pj.isJumping = true;
            }

            if (touch.phase == TouchPhase.Ended) {
                pj.isJumping = false;
            }
        }
    }

}