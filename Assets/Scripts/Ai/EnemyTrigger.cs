using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerGU.Controllers
{
    public class EnemyTrigger : MonoBehaviour
    {
        public Action<GameObject> TriggerEnter;
        public Action<GameObject> TriggerExit;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            TriggerEnter?.Invoke(collision.gameObject);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            TriggerExit?.Invoke(collision.gameObject);
        }
    }
}

