using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private int health;
    private readonly int MAX_HEALTH = 5;
    // Start is called before the first frame update
    void Start()
    {
        health = MAX_HEALTH;
    }

    public void Hit()
    {
        health -= 1;
        float healthUpdate = health / (float)MAX_HEALTH;
        Messenger<float>.Broadcast(GameEvent.HEALTH_CHANGED, healthUpdate);
        Debug.Log(healthUpdate);
        Debug.Log("Health:" + health);
        if (health == 0)
        {
            //Debug.Break();
            Messenger.Broadcast(GameEvent.PLAYER_DEAD);
        }
    }

    public void FirstAid(int healthAdded)
    {
        health += healthAdded;
        if (health > MAX_HEALTH)
        {
            health = MAX_HEALTH;
        }
        float healthPercent = ((float)health) / MAX_HEALTH;
        Messenger<float>.Broadcast(GameEvent.HEALTH_CHANGED, healthPercent);
    }
}
