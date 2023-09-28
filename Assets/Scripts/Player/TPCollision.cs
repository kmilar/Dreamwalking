
using UnityEngine;

public class TPCollision : MonoBehaviour
{
    void OnCollisionEnter (Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Finish") 
        {
            Debug.Log("Welcome to the Arena of Dreams!");
        }
    }
}
