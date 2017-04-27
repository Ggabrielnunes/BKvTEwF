using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCamera : MonoBehaviour {

    private Camera _camera;
    public void MInitialize(LayerMask p_layerMask)
    {
        _camera = GetComponent<Camera>();
        _camera.cullingMask = p_layerMask;
    }

    public void ApplyRenderTexture(RenderTexture p_texture)
    {
        _camera.targetTexture = p_texture;
    }
}
