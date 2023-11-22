using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject PlayerToFollow;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - PlayerToFollow.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(PlayerToFollow != null) transform.position = PlayerToFollow.transform.position + offset;
    }
}
