using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class ProductSlot : MonoBehaviour
{
    [SerializeField] GameObject content;
    private int numberOfChilds;
    private int numberOfOrders;
    private int minValue;
    private int minValueIndex;
    private List<GameObject> waterOrders = new List<GameObject>();
    private List<GameObject> saltOrders = new List<GameObject>();
    private TextMeshProUGUI orderText;
    [SerializeField] OrderGenerator orderGenerator;
    public void GetActiveOrders()
    {
        numberOfChilds = content.transform.childCount;

        for (int i = 1; i < numberOfChilds; i++)
        {
            if (content.transform.GetChild(i).CompareTag("Water"))
            {
                waterOrders.Add(content.transform.GetChild(i).gameObject);
            }
            else
            {
                saltOrders.Add(content.transform.GetChild(i).gameObject);
            }
        }
    }
    public void FinishWaterOrder()
    {
        numberOfOrders = waterOrders.Count;
        if (numberOfOrders > 0)
        {
            int[] _times = new int[numberOfOrders];
            for (int i = 0; i < numberOfOrders; i++)
            {
                _times[i] = waterOrders[i].GetComponent<Timer>()._time;
            }
            minValue = _times.Min();
            minValueIndex = _times.ToList().IndexOf(minValue);
            OrderCompletedText(true,minValueIndex);
            Destroy(waterOrders[minValueIndex],1.5f);
            orderGenerator.activeOrders.Remove(1);
            GameManager.instance.AddScore(1);
        }
        else
        {
            Debug.Log("There is no water order");
        }

    }
    public void FinishSaltOrder()
    {
        numberOfOrders = saltOrders.Count;
        if (numberOfOrders > 0)
        {
            int[] _times = new int[numberOfOrders];
            for (int i = 0; i < numberOfOrders; i++)
            {
                _times[i] = saltOrders[i].GetComponent<Timer>()._time;
                _times[i] = saltOrders[i].GetComponent<Timer>()._time;
            }
            minValue = _times.Min();
            minValueIndex = _times.ToList().IndexOf(minValue);
            OrderCompletedText(false,minValueIndex);

            Destroy(saltOrders[minValueIndex],1.5f);
            orderGenerator.activeOrders.Remove(1);
            GameManager.instance.AddScore(1);
        }
        else
        {
            Debug.Log("There is no salt order");
        }
    }
    private void OrderCompletedText(bool isWaterOrder,int Index)
    {
        if(isWaterOrder)
        {
            orderText = waterOrders[Index].transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        }
        else
        {
            orderText = saltOrders[Index].transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        }
        orderText.text = "ORDER COMPLETED";
        orderText.color = Color.green;
        orderText.fontSize = 17;
        orderText.fontStyle = FontStyles.Bold;
    }

    public void ClearAll()
    {
        waterOrders.Clear();
        saltOrders.Clear();
    }
}
