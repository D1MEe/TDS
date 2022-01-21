using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public GameObject bullet;
    public Transform ShotPoint;
    public Joystick Attack;

    private Vector2 FireInput;
    public float StartTimeBtvShot;
    public float offset;

    private float timeBtvShot;
    

    void Update()
    {
        FireInput = new Vector2(Attack.Horizontal,Attack.Vertical);

        //Rotate();
        JoystickRotate();
        if(timeBtvShot <= 0)
        {
            if (FireInput.x != 0 || FireInput.y != 0)
            {
                Shot();
            }
        }
        else
        {
            timeBtvShot -= Time.deltaTime;
        }
    }

    void Shot()
    {
        Instantiate(bullet, ShotPoint.position, transform.rotation);
        timeBtvShot = StartTimeBtvShot;
    }
    void Rotate()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotz + offset);
    }
    void JoystickRotate()
    {
        float rotz = Mathf.Atan2(Attack.Vertical, Attack.Horizontal) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotz + offset);
    }
}
