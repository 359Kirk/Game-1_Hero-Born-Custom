using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBuffBehavior : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            Destroy(this.transform.parent.gameObject);
            Debug.Log("GAS!GAS!GAS! I'M GONNA STEP ON THE GAS TONIGHT!");
        }
    }
}
