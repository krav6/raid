using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    public Transform playerCharacterTransform;

    private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = new Vector3(-10, 8, -10);
	}
	
	// Update is called once per frame
	void Update () {
        transform.SetPositionAndRotation(playerCharacterTransform.position + offset, transform.rotation);
    }
}
