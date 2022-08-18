using System.Collections.Generic;
using UnityEngine;

public class SlotCollider : MonoBehaviour
{
    [SerializeField] SlotCollider otherSlot;
    private Vector3 slotPos;
    [SerializeField] bool isEmpty = true;
    [SerializeField] GameObject[] prefabs;
    [SerializeField] GameObject productSlot;
    public ProductSlot productSlotScript;
    private int _prefabInd;
    public static List<GameObject> reactants = new List<GameObject>();
    private void Start()
    {
        productSlotScript = productSlot.GetComponent<ProductSlot>();
        slotPos = transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (isEmpty)
        {
            other.GetComponent<DragObject>().isPositionOkay = true;
            isEmpty = false;
            other.transform.position = slotPos;
            reactants.Add(other.gameObject);
        }
        if (reactants.Count == 2)
        {
            if (CheckReactants())
            {
                StartReaction(_prefabInd);
            }
            else
            {
                GameManager.instance.AddScore(-10);
                DestroyReactants();
            }
        }
    }
    bool CheckReactants()
    {
        if (reactants[0].CompareTag("Hydrogen") && reactants[1].CompareTag("Oxygen"))
        {
            _prefabInd = 0;
            return true;
        }
        else if (reactants[0].CompareTag("Oxygen") && reactants[1].CompareTag("Hydrogen"))
        {
            _prefabInd = 0;
            return true;
        }
        else if (reactants[0].CompareTag("Na") && reactants[1].CompareTag("Cl"))
        {
            _prefabInd = 1;
            return true;
        }
        else if (reactants[0].CompareTag("Cl") && reactants[1].CompareTag("Na"))
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
        prefabs[prefabIndex].SetActive(true);
        DestroyReactants();
        FinishOrder(prefabs[prefabIndex]);
    }

    void DestroyReactants()
    {
        isEmpty = true;
        otherSlot.isEmpty = true;
        reactants[0].SetActive(false);
        reactants[1].SetActive(false);
        reactants.Clear();
    }

    void FinishOrder(GameObject go)
    {
        productSlotScript.GetActiveOrders();
        if (go.CompareTag("Water"))
        {
            productSlotScript.FinishWaterOrder();
        }
        else
        {
            productSlotScript.FinishSaltOrder();
        }
        productSlotScript.ClearAll();
    }

}