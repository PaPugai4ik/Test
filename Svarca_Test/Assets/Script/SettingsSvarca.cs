using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Soed")]
public class SettingsSvarca : ScriptableObject
{
    public GameObject Soed;
    [SerializeField]
    [Range(1, 4)]
    int D;
    private int I=0;
    private void OnEnable()
    {
        switch (D)
        {
            case 1:I = 30;break;
            case 2: I = 65; break;
            case 3: I = 105; break;
            case 4: I = 150; break;
        }
    }
}
