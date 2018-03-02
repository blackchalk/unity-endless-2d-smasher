using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	
    public PlayerController player;
    private Vector3 lastPlayerPosition;
    private float distanceToMove = 0.01f;
	
    // Use this for initialization
    void Start () {
        lastPlayerPosition = player.transform.position;
    }
	
    // Update is called once per frame
    void Update () {
        distanceToMove = player.transform.position.x - lastPlayerPosition.x;
        transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);
        lastPlayerPosition = player.transform.position;
    }

    //public Transform target;
    //public float smoothTime = 0.3F;
    //private Vector3 velocity = Vector3.zero;
    //void Update()
    //{
    //    //Vector3 targetPosition = target.TransformPoint(new Vector3(0, 5, -10));
    //    transform.position = Vector3.SmoothDamp(transform.position, target.position, ref velocity, smoothTime);
    //}
}