using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceFighter
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class SpaceEntity : MonoBehaviour
    {
        [SerializeField] 
        private float _maximumHP = 1;
        private float _currentHP = 1;

        [SerializeField] private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void Start()
        {
            _currentHP = _maximumHP;
            _rigidbody.gravityScale = 0f;
        }

        public void ApplyDamage(float damage)
        {
            _currentHP -= damage;
            if (_currentHP < 0 )
            {
                _currentHP = 0;
                Perish();
            }
        }

        public void Perish()
        {
            Destroy(gameObject);
        }
    }
}

