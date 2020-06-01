using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float returnTargetAngle(Vector2 playerPos, Vector2 playerVelo, float shotSpeed)
    {
        float dist = Vector2.Distance(Vector2.zero, playerPos); //calculate distance to players tank using vector2.zero as input position is relative.
        
        float shotTime = dist / shotSpeed;

        Vector2 predictedPoint = playerVelo * shotTime;

        float targetAngle = Vector2.SignedAngle(Vector2.up, (predictedPoint).normalized);

        if (targetAngle < 0f)
        {
            targetAngle = 360f - targetAngle;
        }

        //I know this is wrong and does not take into account whether the player is moving towards to away from the gun. 

        return targetAngle;
    }
}
