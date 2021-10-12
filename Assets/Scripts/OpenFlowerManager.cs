using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OpenFlowerManager : MonoBehaviour
{
    public GameObject Prefab;
    private int _count;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var _ in Enumerable.Range(0,30))
        {
            Create();
        }   
    }

    // Update is called once per frame
    void Update()
    {
        _count++;
        if (_count >= 5)
        {
            Create();
            _count = 0;
        }

    }

    private void Create()
    {
        var rangeMax = 4f;
        var position = new Vector3(Random.Range(-rangeMax, rangeMax), Random.Range(-rangeMax, rangeMax),
            0);
        var o = Instantiate(Prefab);
        o.transform.position = position;
        o.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }
}
