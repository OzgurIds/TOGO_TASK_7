using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{

    public GameManager manager;

    void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Obstacle":
                manager.StopGame("Lose");
                break;
            case "Finish":
                manager.StopGame("Win");
                break;
            case "Collectable":
                if (tag != "Biggie")
                {
                    manager.Collect();
                    other.gameObject.SetActive(false);
                }
                break;
        }

    }
}
