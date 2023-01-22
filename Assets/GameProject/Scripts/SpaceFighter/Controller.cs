using UnityEngine;
using Zenject;

namespace SpaceFighter
{
    public class Controller : MonoBehaviour
    {
        [Inject(Id = "SpaceFighterEvents")] InputEvents _events;
        [SerializeField] private GameObject _pawnGameObject;

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
            _targetPosition = _pawnGameObject.transform.position;
        }

        private void Start()
        {
            var weapons = transform.parent.Find("Weapons")?.GetComponent<Weapons>();
            if (weapons != null)
            {
                _events.PressFire.AddListener(weapons.StartFiring);
                _events.ReleaseFire.AddListener(weapons.FinishFiring);
            }
            
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _events.PressFire.Invoke();
            }
            else if (Input.GetMouseButtonUp(0)) 
            {
                _events.ReleaseFire.Invoke();
            }

            if(Input.GetMouseButton(0))
            {
                _targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }

            _pawnGameObject.transform.position = Vector2.SmoothDamp(_pawnGameObject.transform.position, _targetPosition, ref _currentVelocity, _smoothTime, _maxSpeed, Time.deltaTime);
        }
    }

}