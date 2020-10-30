﻿using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerAttack : MonoBehaviour {
    Animator anim;

    public float intervaloDeAtaque;
    private float proximoAtaque;

    public AudioClip spinSound;
    private AudioSource audioS;
	// Use this for initialization
	void Start () {

        anim = gameObject.GetComponent<Animator>();
        audioS = gameObject.GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update () {
	
        if(Input.GetButtonDown("Fire1") && Time.time > proximoAtaque)
        //if(CrossPlatformInput.GetButtonDown("Fire1") && Time.time > proximoAtaque)
        {
            Atacando();
        }

	}

    void Atacando()
    {
        audioS.clip = spinSound;
        
        anim.SetTrigger("Ataque");
        audioS.Play();
        proximoAtaque = Time.time + intervaloDeAtaque;
    }
}
