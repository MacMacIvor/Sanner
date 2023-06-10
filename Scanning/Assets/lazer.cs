using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazer : MonoBehaviour
{
    public GameObject _player;
    public GameObject _playerGun;
    private LineRenderer _lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        _lineRenderer.SetPosition(0, _playerGun.transform.position);
        RaycastHit hit;
        if (Physics.Raycast(_playerGun.transform.position, (_player.transform.forward), out hit))
        {
            _lineRenderer.SetPosition(1, hit.point);


            Renderer renderer = hit.collider.gameObject.GetComponent<Renderer>();  
            if (renderer != null)
            {
                try
                {
                    hit.collider.GetComponent<LazerHit>().gotHit(hit);
                }
                catch (System.Exception e)
                {
                    ;
                }
                //hit.collider.GetComponent<shaderObjInt>().hitPoint(hit);
                //Material mat = renderer.material;
                //Vector3 localHitPoint = hit.collider.transform.InverseTransformDirection(hit.point);
                //Vector2 uv = new Vector2(localHitPoint.x, localHitPoint.y);
                //uv = new Vector2(uv.x, uv.y);
                //mat.SetVector("_HitPoint", new Vector4(uv.x, uv.y, 0, 0));
            }
            
        }
        else
        {
            _lineRenderer.SetPosition(1, (_playerGun.transform.position + _player.transform.forward * 100));
        }
    }
}
