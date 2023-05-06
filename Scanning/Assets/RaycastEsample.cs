using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastEsample : MonoBehaviour
{
    public Shader shader;
    public Color color;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Renderer renderer = hit.collider.GetComponent<Renderer>();
                if (renderer != null)
                {
                    Material material = renderer.material;
                    material.shader = shader;
                    material.SetColor("_Color", color);
                    material.SetVector("_HitPosition", hit.point);
                }
            }
        }
    }
}
