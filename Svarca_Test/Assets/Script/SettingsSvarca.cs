using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SettingsSvarca : MonoBehaviour
{
    [SerializeField]GameObject point;
    float Sensitivity=1;
    float Timer = 4f;
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
        if (Input.GetKeyDown(KeyCode.Space)&&isPause==false&&isStartSvarca==false)
        {
            isStartSvarca = !isStartSvarca;
            while (Timer <= 0)
            {
                StartCoroutine(StartSvarca());
            }
            Cursor.visible = !Cursor.visible;
            point.SetActive(!point.activeSelf);
        }

        if (Cursor.visible == false)
        {
            point.transform.Translate(new Vector3(Input.GetAxis("Mouse X") * Sensitivity, Input.GetAxis("Mouse Y") * Sensitivity, 0));
            Debug.Log(Input.mousePosition);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPause = !isPause;
            Panel.SetActive(!Panel.activeSelf);
            point.SetActive(false);
            Cursor.visible = true;

        }
        if (isPause)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
    IEnumerator StartSvarca()
    {
        yield return new WaitForSeconds(1);
        Timer -= 1;

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
