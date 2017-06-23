using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollows : MonoBehaviour
{
    [SerializeField]
    private GameObject objectToFollow;

    private Vector3 distacne;
    // Use this for initialization
    void Start()
    {
        distacne = this.transform.position - objectToFollow.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = distacne + objectToFollow.transform.position;

    }
}