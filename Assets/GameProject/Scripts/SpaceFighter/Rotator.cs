using System;
using UnityEngine;


namespace SpaceFighter
{
    class Rotator
    {
        Transform _transform;
        Vector3 _previousPosition;

        public Rotator(Transform transform)
        {
            _transform = transform;
            _previousPosition = transform.position;
        }

        public void Update()
        {
            var newPosition = _transform.position;
            var diff = newPosition.x - _previousPosition.x;
            var placeholder = Mathf.Abs(diff) > 0.001f;
            _transform.rotation = new Quaternion();
            if (placeholder && diff > 0)
            {
                _transform.Rotate(Vector3.up, -30);
            }
            else if (placeholder && diff < 0)
            {
                _transform.Rotate(Vector3.up, 30);
            }

            _previousPosition = newPosition;
        }
    };
}
