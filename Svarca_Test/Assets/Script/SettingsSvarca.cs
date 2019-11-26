using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SettingsSvarca : MonoBehaviour
{
    string[] start = new string[] { "3", "2", "1", "Go!" };
    [SerializeField] GameObject t_Timer;
    [SerializeField]GameObject point;
    float Sensitivity=1;
    int Timer = 4;
    [SerializeField] GameObject Panel;
    bool isPause=false;
    bool isStartSvarca = false;
    private void Start()
    {
        Panel.SetActive(false);
        point.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&isPause==false)
        {
            StartCoroutine(StartSvarca());

        }

        if (Cursor.visible == false)
        {
            point.transform.Translate(new Vector3(Input.GetAxis("Mouse X") * Sensitivity, Input.GetAxis("Mouse Y") * Sensitivity, 0));
        }

        if (Input.GetKeyDown(KeyCode.P)&&Cursor.visible==true&&!t_Timer.activeSelf)
        {
            Panel.SetActive(!Panel.activeSelf);
        }
    }
    IEnumerator StartSvarca()
    {
        
        if (Cursor.visible == true)
        {
            t_Timer.SetActive(true);
            for (int i = 0; i < Timer;)
            {
                t_Timer.GetComponent<Text>().text = start[i];
                yield return new WaitForSeconds(0.9f);
                i++;
            }
            t_Timer.SetActive(false);
        }
        Cursor.visible = !Cursor.visible;
        point.SetActive(!point.activeSelf);
        Timer = start.Length;
    }
    public void OnStart()
    {
        isPause = false;
        Panel.SetActive(false);
    }
    public void OnQuit()
    {
        Application.Quit();
    }
    public void OnSensitivity(GameObject dropdown)
    {
        Sensitivity = dropdown.GetComponent<Slider>().value;
        dropdown.GetComponentInChildren<Text>().text= dropdown.GetComponent<Slider>().value.ToString();
    }
}
