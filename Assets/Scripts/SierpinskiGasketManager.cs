using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SierpinskiGasketManager : MonoBehaviour
{
    void Start()
    {
        var startVertices = new List<Vector3>();
        float radius = 4f;
        for (int i = 0; i < 3; i++)
        {
            var x = -radius * Mathf.Sin(2 * Mathf.PI * i / 3);
            var y = radius * Mathf.Cos(2 * Mathf.PI * i / 3);
            startVertices.Add(new Vector3(x, y, 0));
        }

        DrawSierpinskiGasket(startVertices.ToArray(), 0, 10);
    }

    public GameObject Prefab;

    // Start is called before the first frame update

    private void DrawSierpinskiGasket(Vector3[] vertices, int currentIndex, int n)
    {
        if (currentIndex == 0)
        {
            DrawPolygon(vertices);
        }

        if (currentIndex < n)
        {
            var m = new Vector3[3];
            m[0] = (vertices[1] + vertices[2]) / 2;
            m[1] = (vertices[2] + vertices[0]) / 2;
            m[2] = (vertices[0] + vertices[1]) / 2;
            DrawPolygon(m);
            var pp = new Vector3[3];
            pp[0] = vertices[0];
            pp[1] = m[2];
            pp[2] = m[1];
            DrawSierpinskiGasket(pp, currentIndex + 1, n);
            pp[0] = m[2];
            pp[1] = vertices[1];
            pp[2] = m[0];
            DrawSierpinskiGasket(pp, currentIndex + 1, n);
            pp[0] = m[1];
            pp[1] = m[0];
            pp[2] = vertices[2];
            DrawSierpinskiGasket(pp, currentIndex + 1, n);
            
        }
    }

    private void DrawPolygon(Vector3[] vertices)
    {
        var o = Instantiate(Prefab);
        var lineRenderer = o.GetComponent<LineRenderer>();
        var v = new Vector3[vertices.Length + 1];
        vertices.CopyTo(v, 0);
        v[v.Length - 1] = vertices[0];
        lineRenderer.positionCount = v.Length;
        lineRenderer.SetPositions(v.ToArray());
    }


    public

        // Update is called once per frame
        void Update()
    {
    }
}