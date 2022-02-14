using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBuffBehavior : MonoBehaviour
{
    public float BoostMultiplier = 2.0f; 
    public float BoostSeconds = 5.0f;
    private void OnCollisionEnter(Collision collision)
    {
        
        
        if(collision.gameObject.name == "Player")
        {
            Destroy(this.transform.parent.gameObject);
            Debug.Log("GAS!GAS!GAS! I'M GONNA STEP ON THE GAS TONIGHT!");

            PlayerBehavior Player = collision.gameObject.GetComponent<PlayerBehavior>();
            Player.BoostSpeed(BoostMultiplier, BoostSeconds);
        }
    }
}
