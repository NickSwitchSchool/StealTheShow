using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float startSpeed;
    public float addedSpeed;
    public float addedSpeedMultiplier;

    void Update()
    {
        this.gameObject.transform.position += new Vector3(startSpeed * Time.deltaTime + (addedSpeed * addedSpeedMultiplier * Time.deltaTime), 0, 0);
        addedSpeedMultiplier += 0.01f * Time.deltaTime;
    }
}
