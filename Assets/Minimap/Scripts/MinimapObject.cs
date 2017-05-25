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

        public void SetType(TYPE p_type)
        {
            objectType = p_type;
        }

        public void EnableMarker()
        {
            if(minimapManager==null)
            {
                minimapManager = FindObjectOfType<MinimapManager>();
            }
            if(marker!=null)
            {
                if(!_init)
                {
                    marker = Instantiate(marker);
                    marker.Initialize(targetTransform);
                    minimapManager.AddNewMarker(marker, objectType);
                    _init = true;
                }
                else
                {
                    minimapManager.ResetMarkerSprite(marker);
                }
            }            
        }

        public void MarkerDeath()
        {
            if(_init)
            {
                minimapManager.MarkerDied(marker);
            }
        }
    }
}
