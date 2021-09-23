using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Prefab;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 60; i++)
        {
            var rangeMax = 4f;
            var o = Instantiate(Prefab,
                new Vector3(Random.Range(-rangeMax, rangeMax), Random.Range(-rangeMax, rangeMax),
                    Random.Range(-rangeMax, rangeMax)),
                Quaternion.identity);
            var size = Random.Range(0.5f, 1f);
            o.transform.localScale =
                new Vector3(size, size, size);
            o.GetComponent<Renderer>().material.color= Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}