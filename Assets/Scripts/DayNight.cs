using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{
    private float speed = 12f;
    private void FixedUpdate()
    {
        this.gameObject.transform.Rotate(speed * Time.fixedDeltaTime, 0f , 0f);
    }
}
