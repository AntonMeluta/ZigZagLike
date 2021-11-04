using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystallControl : MonoBehaviour
{
    public void CollisionWithPlayer()
    {
        gameObject.SetActive(false);
    }
}
