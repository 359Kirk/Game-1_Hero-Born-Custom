using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickupBehavior : MonoBehaviour
{
    public int AmmoPickup = 10;
    public GameObject Particles;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            GameObject newParticles = Instantiate(Particles, this.transform.position, this.transform.rotation) as GameObject;
            Destroy(this.transform.parent.gameObject);
            Debug.Log("RESUPPLY SECURED!");

            GameBehavior _gameManager = GameObject.Find("GameBehavior").GetComponent<GameBehavior>();
            _gameManager.AmmoResupply(AmmoPickup);
        }
    }
}
