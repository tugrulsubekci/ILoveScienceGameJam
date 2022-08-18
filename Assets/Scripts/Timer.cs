using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private TextMeshProUGUI timerText;
    private TextMeshProUGUI orderText;
    public int _time;
    private OrderGenerator orderGenerator;
    // Start is called before the first frame update
    void Start()
    {
        orderGenerator = FindObjectOfType<OrderGenerator>();
        timerText = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        if (timerText.text == "25s")
        {
            _time = 25;
        }
        else
        {
            _time = 30;
        }
        InvokeRepeating("DecreaseTime", 1, 1);
    }
    private void OrderFailedText()
    {
        orderText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        orderText.text = "ORDER FAILED";
        orderText.color = Color.red;
        orderText.fontSize = 18;
        orderText.fontStyle = FontStyles.Bold;
    }
    void DecreaseTime()
    {
        if (_time == 0 && !GameManager.instance.isGameOver)
        {
            OrderFailedText();
            GameManager.instance.GameOver();
            Destroy(gameObject,1.5f);
            orderGenerator.activeOrders.Remove(1);
            CancelInvoke("DecreaseTime");
        }
        else
        {
            _time--;
            timerText.text = $"{_time}s";
        }
    }


}
