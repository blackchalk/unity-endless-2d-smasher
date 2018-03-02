using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInstantiate : MonoBehaviour {

    public float InstantiationTimer = 2f;
    public GameObject goTarget;
    public Transform position;

    private void Awake()
    {
        position = this.transform;
    }

    void Update()
    {
        CreatePrefab();
    }

    void CreatePrefab()
    {
        InstantiationTimer -= Time.deltaTime;
        if (InstantiationTimer <= 0)
        {
            Instantiate(goTarget, transform.position, Quaternion.identity);
            InstantiationTimer = 2f;
        }
    }
}
