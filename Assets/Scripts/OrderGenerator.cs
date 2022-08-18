using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class OrderGenerator : MonoBehaviour
{
    [System.Serializable]
    public class Order
    {
        public Sprite image;
        public int time;
    }
    [SerializeField] List<Order> Orders;
    private GameObject orderTemplate;
    public List<int> activeOrders = new List<int>();
    private GameObject g;
    [SerializeField] Transform content;
    private int randomIndex;
    private int orderNumber = 1;
    // Start is called before the first frame update
    void Start()
    {
        orderTemplate = content.GetChild(0).gameObject;
        InvokeRepeating("InstantiateOrder", 5, 5);
    }

    void InstantiateOrder()
    {
        if (activeOrders.Count < 6 || activeOrders == null && !GameManager.instance.isGameOver)
        {
            randomIndex = Random.Range(0, Orders.Count);
            g = Instantiate(orderTemplate, content);
            g.transform.GetChild(0).GetComponent<Image>().sprite = Orders[randomIndex].image;
            g.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = $"ORDER {orderNumber}";
            g.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = Orders[randomIndex].time.ToString() + "s";
            if (randomIndex == 0)
            {
                g.tag = "Water";
            }
            else
            {
                g.tag = "Salt";
            }
            
            orderNumber++;
            activeOrders.Add(1);
            g.SetActive(true);
        }
    }
}