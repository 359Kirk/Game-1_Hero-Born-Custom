using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoostBehavior : MonoBehaviour
{
    public float BoostMultiplier = 2.0f;
    public float BoostSeconds = 5.0f;
    public GameObject Particles;

    private void OnCollisionEnter(Collision collision)
    {


        if (collision.gameObject.name == "Player")
        {
            GameObject newParticles = Instantiate(Particles, this.transform.position, this.transform.rotation) as GameObject;
            Destroy(this.transform.parent.gameObject);
            Debug.Log("Look Mom I can Fly");

            PlayerBehavior Player = collision.gameObject.GetComponent<PlayerBehavior>();
            Player.JumpBoost(BoostMultiplier, BoostSeconds);
        }
    }
}
