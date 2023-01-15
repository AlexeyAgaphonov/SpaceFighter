using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SpaceFighter
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Vector2 _direction = Vector2.up;
        [SerializeField] private BulletDescription _bulletDescription;
        private float _lifeTimer = 0.0f;

        public void Initialize(BulletDescription bulletDescription, Vector2 direction)
        {
            _bulletDescription = bulletDescription;
        }

        void Update()
        {
            _lifeTimer += Time.deltaTime;
            if (_lifeTimer > _bulletDescription.lifetime)
            {
                Destroy(gameObject);
            }

            transform.position = transform.position + new Vector3(_direction.x, _direction.y, 0f) * Time.deltaTime * _bulletDescription.speed;
        }
    }

}
