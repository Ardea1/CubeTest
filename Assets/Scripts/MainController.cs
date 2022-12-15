using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainController : MonoBehaviour
{
    [SerializeField]
    private SceneUi sceneUI;

    [SerializeField]
    private Transform currentCube;

    [SerializeField]
    private Transform pivotPoint;

    private float speed = 30, tSpeed = 0, tilt = 5;

    private float radius_one = 20, radius_two = 50, angularSpeed = 0.02f;

    private float positionX, positionY, angle = 0f;

    protected bool rotate = false;

    private float random;


    private void GetRandom()
    {
        random = Random.Range(1, 11);
    }

    private void StartCircling()
    {
        rotate = true;
    }

    private void StopCircling()
    {
        rotate = false;
    }

    private void MainMenu_OnClick(MainMenu.ButtonType buttonType)
    {
        switch (buttonType)
        {
            case MainMenu.ButtonType.Start:
                if (rotate == false)
                {
                    GetRandom();
                }
                
                StartCircling();
                break;

            case MainMenu.ButtonType.Stop:
                StopCircling();
                break;

            case MainMenu.ButtonType.Exit:
                Application.Quit();
                break;
        }
    }

    void Start()
    {
       sceneUI.MainMenu.OnClick += MainMenu_OnClick;
    }

    public void FixedUpdate()
    {
        if (rotate)
        {
            if (random % 2 == 0)
            {
                tSpeed += speed * Time.deltaTime;
                currentCube.eulerAngles = new Vector3(tilt, tSpeed, 0.0f);

                angle = angle + Time.deltaTime + angularSpeed;
                positionX = radius_one * Mathf.Cos(angle) + pivotPoint.position.x;
                positionY = radius_one * Mathf.Sin(angle) + pivotPoint.position.y;
                transform.position = new Vector2(positionX, positionY);

                if (angularSpeed > 0 && angle >= 360f)
                {
                    angle -= 360f;
                }
                else if (angularSpeed < 0 && angle <= 360f)
                {
                    angle += 360f;
                }
            }
            else
            {
                tSpeed += speed * Time.deltaTime;
                currentCube.eulerAngles = new Vector3(tilt, tSpeed, 0.0f);

                angle = angle + Time.deltaTime + angularSpeed;
                positionX = radius_two * Mathf.Cos(angle) + pivotPoint.position.x;
                positionY = radius_two * Mathf.Sin(angle) + pivotPoint.position.y;
                transform.position = new Vector2(positionX, positionY);

                if (angularSpeed > 0 && angle >= 360f)
                {
                    angle -= 360f;
                }
                else if (angularSpeed < 0 && angle <= 360f)
                {
                    angle += 360f;
                }
            }
            
        }
    }
}
