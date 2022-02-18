using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloco2 : MonoBehaviour
{
        public int hits;

        void Start () {
            hits = 0;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
                hits ++;
                if (hits >=2) {
                    Destroy(gameObject);
                    hits=0;
                }
                
        }
}