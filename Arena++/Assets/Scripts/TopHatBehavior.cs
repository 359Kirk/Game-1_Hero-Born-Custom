using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopHatBehavior : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(this.transform.parent.gameObject);
            Debug.Log("Item collected!");

            PlayerBehavior Player = collision.gameObject.GetComponent<PlayerBehavior>();
            Player.showHat();
        }
        
    }

 }

