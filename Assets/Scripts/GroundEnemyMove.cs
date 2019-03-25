using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemyMove : MonoBehaviour
{
    public bool isRight = true;
    public float movementSpeed = 2f;

    void Start()
    {

    }

    /*  private void FixedUpdate()
      {
          movementSpeed = 2f;
          if (isRight == true)
          {
              transform.Translate(movementSpeed, 0, 0, Space.World);
          }
          else
          {
              transform.Translate(-movementSpeed, 0, 0, Space.World);
          }
      }

      private void OnTriggerStay2D(Collider2D collision)
      {

          if (collision.tag == "Player")
          {
              movementSpeed = 0f;
          }
          else
          {
              movementSpeed = 2f;
          }
      }
      */
    public void OnTriggerEnter2D(Collider2D collision)
      {
          if (collision.tag == "EndOfPlatform")
          {
              if (isRight == true)
              {
                  isRight = false;
                  transform.Rotate(0, 180, 0);
              }
              else
              {
                  isRight = true;
                  transform.Rotate(0, 180, 0);
              }

          }
      }
      
}
