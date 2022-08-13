using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotCollider : MonoBehaviour
{
    [SerializeField] SlotCollider otherSlot;
    private Vector3 slotPos;
    [SerializeField] bool isEmpty = true;
    private GameManager gameManager;
    [SerializeField] GameObject[] prefabs;
    [SerializeField] GameObject productSlot;
    private int _prefabInd;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        slotPos = transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (isEmpty)
        {
            other.GetComponent<DragObject>().isPositionOkay = true;
            isEmpty = false;
            other.transform.position = slotPos;
            gameManager.reactants.Add(other.gameObject);
        }
        if(gameManager.reactants.Count == 2)
        {
            if(CheckReactants())
            {
                StartReaction(_prefabInd);
            }
            else
            {
                DestroyReactants();
            }
        }
    }
    bool CheckReactants()
    {
        if (gameManager.reactants[0].CompareTag("Hydrogen") && gameManager.reactants[1].CompareTag("Oxygen"))
        {
            _prefabInd = 0;
            return true;
        }
        else if(gameManager.reactants[0].CompareTag("Oxygen") && gameManager.reactants[1].CompareTag("Hydrogen"))
        {
            _prefabInd = 0;
            return true;
        }
        else if (gameManager.reactants[0].CompareTag("Na") && gameManager.reactants[1].CompareTag("Cl"))
        {
            _prefabInd = 1;
            return true;
        }
        else if (gameManager.reactants[0].CompareTag("Cl") && gameManager.reactants[1].CompareTag("Na"))
        {
            _prefabInd = 1;
            return true;
        }
        else
        {
            return false;
        }
    }

    void StartReaction(int prefabIndex)
    {
        Instantiate(prefabs[prefabIndex],productSlot.transform.position, prefabs[prefabIndex].transform.rotation);
        DestroyReactants();
    }

    void DestroyReactants()
    {
        isEmpty = true;
        otherSlot.isEmpty = true;
        Destroy(gameManager.reactants[0]);
        Destroy(gameManager.reactants[1]);
        gameManager.reactants.Clear();
    }
}