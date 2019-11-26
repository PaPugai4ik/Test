using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
     bool isActive = false;
    float i = 1.4f;
    private void Update()
    {
        if (isActive)
        {
            if (i<0)
            {
                Destroy(gameObject);
            }
            else
            {
                i -= Time.deltaTime;
            }
            
        }
    }
    public void Active() {
        isActive = true;
    }
}
