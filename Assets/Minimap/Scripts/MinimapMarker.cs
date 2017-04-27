using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SideMiniMap {

    public class MinimapMarker : MonoBehaviour {

        private Transform _targetTransform;
        private SpriteRenderer _renderer;

        public void Initialize(Transform p_target)
        {
            _targetTransform = p_target;
        }

        public void MUpdate()
        {
            
            if(_targetTransform!=null)
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
    }
}
