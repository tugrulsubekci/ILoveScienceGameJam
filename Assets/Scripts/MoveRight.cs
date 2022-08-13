using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : MonoBehaviour
{
    private Transform goTransform;
    private float moveSpeed = 0.5f;
    private void Start()
    {
        goTransform = GetComponent<Transform>();
    }
    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        goTransform.position += moveSpeed * Time.fixedDeltaTime * Vector3.right;
    }
}
