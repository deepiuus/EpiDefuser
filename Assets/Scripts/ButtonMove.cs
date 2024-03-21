using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMovement : MonoBehaviour
{
    public float speed = 5f;
    public float minX = 0f;
    public float maxX = 10f;
    public float minY = 0f;
    public float maxY = 10f;
    private Vector3 direction = new Vector3(1, 1, 0).normalized;
    private bool isClicked = false;

    void Start()
    {
        MoveButton();
    }

    void Update()
    {
        if (!isClicked)
        {
            MoveButton();
        }
    }

    void MoveButton()
    {
        Vector3 movement = direction * speed * Time.deltaTime;
        transform.Translate(movement);
        Vector3 newPosition = transform.position;
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);
        transform.position = newPosition;

        if (transform.position.x <= minX || transform.position.x >= maxX)
        {
            direction.x *= -1;
        }
        if (transform.position.y <= minY || transform.position.y >= maxY)
        {
            direction.y *= -1;
        }
    }

    public void OnButtonClick()
    {
        isClicked = true;
    }
}
