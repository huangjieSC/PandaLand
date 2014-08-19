﻿using UnityEngine;
using System.Collections;
[RequireComponent (typeof (AudioSource))]
public class CoconutThrower : MonoBehaviour {
	public AudioClip throwSound;
	public Rigidbody coconutPrefab;
	public float throwSpeed;
	public static bool canThrow = false;
void Update () {
		if(Input.GetButtonDown("Fire1") && canThrow){
			audio.PlayOneShot(throwSound);
			Rigidbody newCoconut = Instantiate(coconutPrefab, transform.position, transform.rotation) as Rigidbody;
			newCoconut.name = "coconut";
			newCoconut.rigidbody.velocity = transform.forward * throwSpeed;
			Physics.IgnoreCollision(transform.root.collider, newCoconut.collider, true);
		}
	}
	

}