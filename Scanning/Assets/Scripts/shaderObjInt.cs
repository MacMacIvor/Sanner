using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shaderObjInt : MonoBehaviour
{
    public Camera _camera;
    public Shader _drawShader;

    private RenderTexture _splatMap;
    private Material _splatMaterial, _drawMaterial;
    // Start is called before the first frame update
    private RaycastHit _hit;
    bool _enabled = false;

    public void hitPoint(RaycastHit _impactPoints)
    {
        _hit = _impactPoints;
        _enabled = true;
    }
    void Start()
    {
        _drawMaterial = new Material(_drawShader);
        _drawMaterial.SetVector("_Color", Color.red);

        _splatMaterial = GetComponent<MeshRenderer>().material;
        _splatMap = new RenderTexture(1024, 1024, 0, RenderTextureFormat.ARGBFloat);
        _splatMaterial.SetTexture("_Splat", _splatMap);
    }

    // Update is called once per frame
    void Update()
    {
        if (_enabled)
        {
            _drawMaterial.SetVector("_Coordiante", new Vector4(_hit.point.x, _hit.point.y, 0, 0));
            RenderTexture temp = RenderTexture.GetTemporary(_splatMap.width, _splatMap.height, 0, RenderTextureFormat.ARGBFloat);
            Graphics.Blit(_splatMap, temp);
            Graphics.Blit(temp, _splatMap, _drawMaterial);
            RenderTexture.ReleaseTemporary(temp);

            
        }
    }


    private void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, 256, 256), _splatMap, ScaleMode.ScaleToFit, false, 1);
    }
}
