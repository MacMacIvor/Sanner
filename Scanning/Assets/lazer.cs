using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazer : MonoBehaviour
{
    public GameObject player;
    private LineRenderer lineRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0, player.transform.position);
        RaycastHit hit;
        if (Physics.Raycast(player.transform.position, (player.transform.forward), out hit))
        {
            lineRenderer.SetPosition(1, hit.point);


            Renderer renderer = hit.collider.gameObject.GetComponent<Renderer>();  
            if (renderer != null)
            {
                Material mat = renderer.material;
                Vector3 localHitPoint = hit.collider.transform.InverseTransformDirection(hit.point);
                Vector2 uv = new Vector2(localHitPoint.x, localHitPoint.y);
                uv = new Vector2(uv.x, uv.y);
                mat.SetVector("_HitPoint", new Vector4(uv.x, uv.y, 0, 0));
            }
            
        }
        else
        {
            lineRenderer.SetPosition(1, (player.transform.position + player.transform.forward * 100));
        }
    }
}
