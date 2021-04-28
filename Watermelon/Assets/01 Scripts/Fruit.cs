using System.Collections.Generic;
using UnityEngine;

public enum eFruit
{
    Grape,
    Cherry,
    Orange,
    Lemon,
    Kiwi,
    Tomato,
    Peach,
    Pineapple,
    Coconut,
    HalfWatermelon,
    Watermelon
}

public class Fruit : MonoBehaviour
{
    private eFruit type;
    
    private float conversion =  0.00026f; //m를 픽셀 단위로 변환 (반올림) 
    private float timeStep;

    private float gravity;
    private Vector2 currentSpeed =Vector2.zero;

    private Rect allowedArea = new Rect(-2.5f, -4.5f, 5f, 9f);
    [SerializeField]
    private bool isAllowedArea = false;

    //private Vector2 position;
    //public Vector2 Position => position;

    //Fruit(Vector3 _position) {
    //    position = _position;
    //}

    private void Awake()
    {
        timeStep = 1 / Time.fixedDeltaTime; //50
        gravity = Physics2D.gravity.y * conversion * 1.54f; 
        Debug.Log(gravity);
    }

    public void Update()
    {
    }

    public void FixedUpdate()
    {
        currentSpeed.y += gravity;

        if(isAllowedArea)
            CheckInActiveAllowedArea();

        transform.position = new Vector2(transform.position.x, transform.position.y + currentSpeed.y);
    }

    private void CheckInActiveAllowedArea()
    {

        if (transform.position.x < allowedArea.xMin)
        {
            transform.position = new Vector2(allowedArea.xMin, transform.position.y);
            currentSpeed.x = 0f;
        }
        if (transform.position.x > allowedArea.xMax)
        {
            transform.position = new Vector2(allowedArea.xMax, transform.position.y);
            currentSpeed.x = 0f;
        }
        if (transform.position.y < allowedArea.yMin)
        {
            transform.position = new Vector2(transform.position.x, allowedArea.yMin);
            currentSpeed.y = 0f;
        }
        if (transform.position.y > allowedArea.yMax)
        {
            transform.position = new Vector2(transform.position.x, allowedArea.yMax);
            currentSpeed.y = 0f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
