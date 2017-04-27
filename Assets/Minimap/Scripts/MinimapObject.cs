using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SideMiniMap
{
    public class MinimapObject : MonoBehaviour
    {
        public TYPE objectType;
        public Transform targetTransform;
        public MinimapMarker marker;
        public MinimapManager minimapManager;
        private bool _init = false;

        public void OnEnable()
        {
            if(minimapManager==null)
            {
                minimapManager = FindObjectOfType<MinimapManager>();
            }
            if(!_init && marker!=null)
            {
                marker = Instantiate(marker);
                marker.Initialize(targetTransform);
                minimapManager.AddNewMarker(marker, objectType);
                _init = true;
            }
        }
    }
}
