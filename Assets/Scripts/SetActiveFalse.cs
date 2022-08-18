using UnityEngine;

public class SetActiveFalse : MonoBehaviour
{
    void OnEnable()
    {
        Invoke("ActiveFalse", 1);
    }

    private void ActiveFalse()
    {
        gameObject.SetActive(false);
    }
}
