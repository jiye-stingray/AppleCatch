using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI를 사용할 때는 잊지 않도록 주의 한다.

public class GameDirector : MonoBehaviour
{
    GameObject timeText;
    GameObject pointText;
    float time = 30.0f;
    int point = 0;
    GameObject generator;

    public void GetApple()
    {
        point += 100;
    }

    public void GetBomb()
    {
        point /= 2;
    }
    void Start()
    {
        generator = GameObject.Find("ItemGenerator");
        timeText = GameObject.Find("Time");
        pointText = GameObject.Find("Point");
    }

    void Update()
    {
        time -= Time.deltaTime;

        if (time<0)
        {
            time = 0;
            generator.GetComponent<ItemGenerator>().SetParameter(10000.0f,0,0);
        }
        else if (0 <= time && time < 5)
        {
            generator.GetComponent<ItemGenerator>().SetParameter(0.7f, -0.04f, 3);
        }
        else if (5 <= time && time < 12)
        {
            generator.GetComponent<ItemGenerator>().SetParameter(0.8f, -0.05f, 6);
        }
        else if (12 <= time && time < 23)
        {
            generator.GetComponent<ItemGenerator>().SetParameter(0.8f, -0.04f, 4);
        }
        else if (23 <= time && time < 30)
        {
            generator.GetComponent<ItemGenerator>().SetParameter(1.0f, -0.03f, 2);
        }

        timeText.GetComponent<Text>().text = time.ToString("F1");
        pointText.GetComponent<Text>().text = point.ToString() + " point";
    }
}
