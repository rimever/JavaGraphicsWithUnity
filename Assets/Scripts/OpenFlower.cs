using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenFlower : MonoBehaviour
{
    private float _size;

    // Start is called before the first frame update
    void Start()
    {
        _size = Random.Range(0.5f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        var nowSize = transform.localScale.x;
        if (nowSize > _size)
        {
            Destroy(gameObject, 1.0f);
            return;
        }

        nowSize = nowSize + _size / 10f;
        transform.localScale = new Vector3(nowSize, nowSize, nowSize);
    }
}