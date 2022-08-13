using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMe : MonoBehaviour
{
    private int destroyTime = 25;
    private float XMax;
    private void Start()
    {
        Invoke(nameof(DestroyObject),destroyTime);
    }

    void DestroyObject()
    {
        if (gameObject.transform.position.x > XMax)
        {
            Destroy(gameObject);
        }
        CancelInvoke(nameof(DestroyObject));
    }
}
