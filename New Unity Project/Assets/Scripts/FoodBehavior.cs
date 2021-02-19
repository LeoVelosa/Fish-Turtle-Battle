using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBehavior : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "TurtleRed")
        {
            Destroy(this.transform.gameObject);

            Debug.Log("Fish food stolen!");
        }
    }
}
