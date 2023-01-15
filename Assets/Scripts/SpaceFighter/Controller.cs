using UnityEngine;

namespace SpaceFighter
{
    public class Controller : MonoBehaviour
    {
        [SerializeField] private GameObject _pawnGameObject;
        private Rigidbody2D _pawnRigidbody;

        [SerializeField] private float _maxSpeed = 5.0f;
        [SerializeField] private float _smoothTime = 0.1f;

        private Vector2 _targetPosition;
        private Vector2 _currentVelocity;


        private void Awake()
        {
            if (_pawnGameObject == null)
            {
                _pawnGameObject = transform.parent.gameObject;
            }
            _pawnRigidbody = _pawnGameObject.GetComponent<Rigidbody2D>();
            _targetPosition = _pawnRigidbody.position;
        }

        private void Update()
        {
            if(Input.GetMouseButton(0))
            {
                _targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }

            _pawnGameObject.transform.position = Vector2.SmoothDamp(_pawnGameObject.transform.position, _targetPosition, ref _currentVelocity, _smoothTime, _maxSpeed, Time.deltaTime);
        }
    }

}