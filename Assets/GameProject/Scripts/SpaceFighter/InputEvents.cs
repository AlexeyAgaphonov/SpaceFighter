using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;


namespace SpaceFighter
{
    public class InputEvents : MonoBehaviour
    {
        public UnityEvent PressFire;
        public UnityEvent ReleaseFire;
        private void Awake()
        {
            PressFire = new UnityEvent();
            ReleaseFire = new UnityEvent();
        }
    }

}

