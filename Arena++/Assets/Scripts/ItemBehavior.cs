using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior : MonoBehaviour
{
    public GameObject Particles;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameObject newParticles = Instantiate(Particles, this.transform.position, this.transform.rotation) as GameObject;
            Destroy(this.transform.parent.gameObject);
            Debug.Log("Item collected!");

            GameBehavior _gameManager = GameObject.Find("GameBehavior").GetComponent<GameBehavior>();
            _gameManager.Items += 1;
        }
    }
}
