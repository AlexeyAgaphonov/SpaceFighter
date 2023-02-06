using SpaceFighter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;


namespace SpaceFighter
{
    public class MovingController : MonoBehaviour, IController
    {
        [Inject(Id = "ParentGameObject")]
        private GameObject _pawnGameObject;

        [SerializeField]
        private float _movementSpeed = 5f;

        public void Initialize(float movementSpeed)
        {
            _movementSpeed = movementSpeed;
        }
        
        private void Update()
        {
            var currentPosition = _pawnGameObject.transform.position;
            _pawnGameObject.transform.position = currentPosition + _movementSpeed * Time.deltaTime * Vector3.down;
        }
    }
}
