using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace SpaceFighter
{
    public class Events : MonoBehaviour
    {
        public UnityEvent PressFire;
        public UnityEvent ReleaseFire;
        public static Events Instance { get; private set; }
        private void Awake()
        {
            // If there is an instance, and it's not me, delete myself.

            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }

        private void Start()
        {
            PressFire = new UnityEvent();
            ReleaseFire = new UnityEvent();
        }
    }

}

