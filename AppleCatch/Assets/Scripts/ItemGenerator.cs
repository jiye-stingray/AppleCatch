using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject ApplePrefab;
    public GameObject BombPrefabs;
    float span = 1.0f; //프리팹이 생성되는 간격
    float delta = 0;
    int ratio = 2; //사과와 폭탄이 생성되는 비율
    float speed = -0.03f;
    public void SetParameter(float span,float speed, int ratio)
    {
        this.span = span;
        this.speed = speed;
        this.ratio = ratio;

    }
    void Update()
    {
        delta += Time.deltaTime;
        if (delta > span)
        {
            delta = 0;
            GameObject item;
            int dice = Random.Range(1, 11);
            if(dice <= ratio)
            {
                item = Instantiate(BombPrefabs) as GameObject;
            }
            else
            {
                item = Instantiate(ApplePrefab) as GameObject;
            }
            float x = Random.Range(-1, 2);
            float z = Random.Range(-1, 2);
            item.transform.position = new Vector3(x, 4, z);
            item.GetComponent<ItemController>().dropSpeed = speed;
        }
    }
}
