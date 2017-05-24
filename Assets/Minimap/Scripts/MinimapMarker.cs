using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SideMiniMap {

    public class MinimapMarker : MonoBehaviour {

        private Transform _targetTransform;
        private SpriteRenderer _renderer;
        private TYPE _markerType;
        private bool _shouldFollow;
        public bool shouldFollow
        {
            get { return _shouldFollow; }
            set { _shouldFollow = value; }
        }

        public void Initialize(Transform p_target)
        {
            _targetTransform = p_target;
        }

        public void MUpdate()
        {            
            if(_targetTransform!=null && _shouldFollow)
            {
                
                transform.position = _targetTransform.position;
            }
        }

        public void SetSprite(Sprite p_sprite)
        {
            if(_renderer!=null) _renderer.sprite = p_sprite;
            else
            {
                _renderer = GetComponent<SpriteRenderer>();
                if (_renderer != null) _renderer.sprite = p_sprite;
            }
        }

        public TYPE GetMarkerType()
        {
            return _markerType;
        }

        public void SetMarkerType(TYPE p_type)
        {
            _markerType = p_type;
        }
    }
}
