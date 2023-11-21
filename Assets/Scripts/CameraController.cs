using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = target.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = new(transform.position.x, transform.position.y, target.position.z - offset.z);
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * 10);
    }
}
