using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public float timer;
    public float destroyTimer;
    public float delaytimer = 1.0f;
    private float destroyDelayTimer = 30f;
    public GameObject[] bars;
    private List<GameObject> list;
    float yPos = -4f;
    int desNumber = 10;
    public CameraMovement cm;

    private void Start()
    {
        list = new List<GameObject>();
        timer = delaytimer;
        for(int i=0;i<100;i++)
        {
            Spawn();
        }
        destroyTimer = destroyDelayTimer;
    }
    void Update() {

        if (cm.startDeleteTile)
        {
            timer -= Time.deltaTime;
            destroyTimer -= Time.deltaTime;
        }


        if(timer<=0)
        {
            Spawn();
            timer = delaytimer;
        }
        if(destroyTimer<=0)
        {
            for(int i = 0; i < desNumber; i++)
            {
                deletelist();
                destroyTimer = destroyDelayTimer;
            }
            if (desNumber < 50)
            {
                desNumber += 10;
            }
        }
    }


    void Spawn()
    {
        int randIndex = Random.Range(0, 100);
       // Debug.Log(randIndex);
        float range = Random.Range(-1.8f, 1.8f);
        yPos -= 1.5f;
        Vector2 pos = new Vector2(range, yPos);
        GameObject go = Instantiate(bars[randIndex], pos, Quaternion.identity);
        list.Add(go);
        

    }
    void deletelist()
    {
        DestroyObject(list[0]);
        list.RemoveAt(0);
    }
}
