using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bloco : MonoBehaviour
{
        public int hits;
        public int kill_hits = 1;
        void Start () {
            hits = 0;
            
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
                hits ++;
                if (hits >=kill_hits) {
                    Destroy(gameObject);
                    hits=0;
                }


           else if (hits==1) {
            if (kill_hits == 3) // pink
                transform.GetComponent<Renderer> ().material.color = new Color(0 , 201 , 254, 1 ); //blue
            if (kill_hits == 2) // blue
                transform.GetComponent<Renderer> ().material.color = new Color(0 , 255 , 0, 1 );  //green
           }else if (hits ==2 )
                transform.GetComponent<Renderer> ().material.color = new Color(0 , 255 , 0, 1 ); //green
        }
}