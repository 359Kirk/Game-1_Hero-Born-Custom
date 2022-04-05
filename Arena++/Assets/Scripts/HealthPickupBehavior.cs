using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickupBehavior : MonoBehaviour
{
    public int HealthBoost = 3;
    public GameObject Particles;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            GameObject newParticles = Instantiate(Particles, this.transform.position, this.transform.rotation) as GameObject;
            Destroy(this.transform.parent.gameObject);
            Debug.Log("YOU AIN'T DYING ON ME!");
            

            GameBehavior _gameManager = GameObject.Find("GameBehavior").GetComponent<GameBehavior>();
            _gameManager.BoostHealth(HealthBoost);
        }
        
    }

}
