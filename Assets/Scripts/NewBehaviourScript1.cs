﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NewBehaviourScript1 : MonoBehaviour, IPointerClickHandler
{

  
        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("Clicked" + gameObject.name);
        }
 
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
