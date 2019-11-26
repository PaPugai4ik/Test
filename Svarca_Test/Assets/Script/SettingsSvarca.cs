using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SettingsSvarca : MonoBehaviour
{
    string[] start = new string[] { "3", "2", "1", "Go!" };
    [SerializeField] GameObject t_Timer;
    [SerializeField] GameObject Show;
    [SerializeField] GameObject Soed;

    [SerializeField]GameObject point;

    Vector3 Pos;
    Vector3 dir=new Vector3(0.7f,0.7f,0);
    GameObject obj;
    float Sensitivity=1;
    int Timer = 4;
    [SerializeField] GameObject Panel;
    bool isPause=false;
    bool isStartSvarca = false;
    bool isStart = true;
    private void Start()
    {
        Panel.SetActive(false);
        point.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&isPause==false&& isStart)
        {
            isStart = false;
            StartCoroutine(StartSvarca());

        }

        if (Cursor.visible == false)
        {
            onSvarca();
        }

        if (Input.GetKeyDown(KeyCode.P)&&Cursor.visible==true&&!t_Timer.activeSelf)
        {
            Panel.SetActive(!Panel.activeSelf);
        }

    }
    public void onStartShow()
    {
        obj.GetComponentInChildren<Timer>().Active();
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
        isStart = true;
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
    void onSvarca()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = new Ray(GameObject.FindGameObjectWithTag("Spawn").transform.position, new Vector3(0, 3, 5));
            if (Physics.Raycast(ray, out hit))
            {
                if (obj == null)
                {
                    obj = Instantiate(Show, hit.point, Quaternion.identity);
                    Pos = point.transform.position;
                    isStartSvarca = true;
                }
                if (point.transform.position.y > (Pos.y + dir.y) ||
                    point.transform.position.y < (Pos.y - dir.y) ||
                    point.transform.position.x > (Pos.x + dir.x) ||
                    point.transform.position.x < (Pos.x - dir.x))
                {
                    if (isStartSvarca)
                    {
                        onStartShow();
                    }
                    obj = Instantiate(Show, hit.point, Quaternion.identity);
                    obj.transform.parent = Soed.transform;
                    Pos = point.transform.position;
                    isStartSvarca = true;
                }
                else
                {
                    if (obj.transform.localScale == new Vector3(3, 3, 1))
                    {
                        Destroy(obj);
                    }
                    else
                    {
                        obj.transform.localScale += new Vector3(0.05f, 0.05f, 0);
                    }
                }
            }
        }
        else
        {
            if (isStartSvarca && obj != null)
            {
                onStartShow();
                isStartSvarca = false;
            }
        }
        point.transform.Translate(new Vector3(Input.GetAxis("Mouse X") * Sensitivity, Input.GetAxis("Mouse Y") * Sensitivity, 0));
    }
    
}
