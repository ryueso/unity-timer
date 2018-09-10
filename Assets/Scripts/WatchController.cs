using UnityEngine;
using UnityEngine.UI;

public class WatchController : MonoBehaviour
{
    private Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        text.text =
            System.DateTime.Now.Hour.ToString() + ':' +
            System.DateTime.Now.Minute.ToString("D2") + ':' +
            System.DateTime.Now.Second.ToString("D2");
    }
}