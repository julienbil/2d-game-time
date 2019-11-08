﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenThing : MonoBehaviour
{
    public GameObject panel;
    public Material materialIdle, materialHover;
    MeshRenderer mr;
    Behaviour halo;

    // Start is called before the first frame update
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        halo = (Behaviour)GetComponent("Halo");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        panel.SetActive(true);
    }

    private void OnMouseEnter()
    {
        //mr.material = materialHover;
        //halo.enabled = true;
        mr.material.color = new Color32(200, 255, 255, 255);
    }

    private void OnMouseExit()
    {
        //mr.material = materialIdle;
        //halo.enabled = false;
        mr.material.color = new Color32(200, 200, 200, 255);
    }
}
