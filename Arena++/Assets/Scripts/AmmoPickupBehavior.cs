using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickupBehavior : MonoBehaviour
{
    public int AmmoPickup = 10;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            Destroy(this.transform.parent.gameObject);
            Debug.Log("RESUPPLY SECURED!");

            GameBehavior _gameManager = GameObject.Find("GameBehavior").GetComponent<GameBehavior>();
            _gameManager.AmmoResupply(AmmoPickup);
        }
    }
}
