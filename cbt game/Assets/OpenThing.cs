﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenThing : MonoBehaviour
{
    public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        panel.SetActive(true);
    }
}
