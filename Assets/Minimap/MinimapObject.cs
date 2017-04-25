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
        private bool _init = false;

        public void OnEnable()
        {
            if(!_init && marker!=null)
            {
                marker = Instantiate(marker, targetTransform);

                _init = true;
            }
        }
    }
}
