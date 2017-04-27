using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SideMiniMap { 

    public enum TYPE
    {
        PLAYER,
        ENEMY,
        ALLY
    }

    public class MinimapManager : MonoBehaviour
    {
        public GameObject player;
        public RenderTexture cameraTexture;
        public LayerMask minimapLayer;
        public MinimapCamera minimapCamera;
        public Sprite allySprite;
        public Sprite playerSprite;
        public Sprite enemySprite;
        private List<MinimapMarker> _markerList;

        void Awake()
        {
            _markerList = new List<MinimapMarker>();
            minimapCamera.MInitialize(minimapLayer);
            if (cameraTexture != null) minimapCamera.ApplyRenderTexture(cameraTexture);
        }
        
        void Update()
        {
            if(_markerList!=null)
            {
                foreach (MinimapMarker __marker in _markerList)
                {
                    if (__marker.isActiveAndEnabled)
                    {
                        __marker.MUpdate();
                    }
                }
            }
        }

        public void AddNewMarker(MinimapMarker p_marker, TYPE p_type)
        {
            if (!_markerList.Contains(p_marker))
            {
                switch (p_type)
                {
                    case TYPE.PLAYER:
                        p_marker.SetSprite(playerSprite);
                        break;
                    case TYPE.ALLY:
                        p_marker.SetSprite(allySprite);
                        break;
                    case TYPE.ENEMY:
                        p_marker.SetSprite(enemySprite);
                        break;
                }
                _markerList.Add(p_marker);               
            }
        }
    }
}
