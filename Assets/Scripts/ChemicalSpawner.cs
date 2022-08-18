using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChemicalSpawner : MonoBehaviour
{
    [SerializeField] ObjectPooler objectPooler;
    private Vector3 goPosition;
    private Quaternion goRotation; 
    private int randomNumber;
    private void Start()
    {
        goPosition = transform.position;
        goRotation.eulerAngles.Set(0, 0, 0);
        InvokeRepeating("StartPool", 0, 2);
    }
    private void StartPool()
    {
        if(!GameManager.instance.isGameOver)
        {
            randomNumber = Random.Range(0, 4);
            switch (randomNumber)
            {
                case 0:
                    objectPooler.SpawnFromPool("H", goPosition, goRotation);
                    return;
                case 1:
                    objectPooler.SpawnFromPool("O", goPosition, goRotation);
                    return;
                case 2:
                    objectPooler.SpawnFromPool("Na", goPosition, goRotation);
                    return;
                case 3:
                    objectPooler.SpawnFromPool("Cl", goPosition, goRotation);
                    return;
                default:
                    return;
            }
        }
        else
        {
            CancelInvoke("StartPool");
        }

    }
}
