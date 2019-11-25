using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    private float mag = 5f;
    private float detDist = 0.5f;
    private float radius;

    Vector3 moveDirection;

    private Ray ray;
    private RaycastHit hit;


    private float size = 1;

    // Start is called before the first frame update
    void Start()
    {
        radius = GetComponent<SphereCollider>().radius;

        int[] r = { 0, 2 };
        int[] yRange = { -1, 1 };
        float x_speed = Random.Range(-1.0f,1.0f);
        float y_speed = (1 - Mathf.Abs(x_speed)) * yRange[Random.Range(r[0], r[1])];
        moveDirection = new Vector3(x_speed, 0, y_speed);
    }

    // Update is called once per frame
    void Update()
    {
        float angle = FindAngle(moveDirection.x, moveDirection.z);
        /*
        //Center
        ray[0] = new Ray(transform.position, moveDirection);
        //Left
        ray[1] = new Ray(transform.position - new Vector3(Mathf.Cos(angle) * size, 0 , Mathf.Sin(angle) * size), moveDirection);
        //Right
        ray[2] = new Ray(transform.position + new Vector3(Mathf.Cos(angle) * size, 0, Mathf.Sin(angle) * size), moveDirection);
        

        if (Physics.Raycast(ray[0], out hit, detDist) || Physics.Raycast(ray[1], out hit, detDist) || Physics.Raycast(ray[2], out hit, detDist))
        {
            Debug.Log("hit a wall");
            moveDirection = Vector3.Reflect(moveDirection, hit.normal);
            
        }
        */

        ray = new Ray(transform.position, moveDirection);
        if (Physics.SphereCast(ray, radius, out hit, detDist))
        {
            if (!hit.collider.GetComponent<Tags>().FindTag("player")) {
                Debug.Log("hit not a player");
                moveDirection = Vector3.Reflect(moveDirection, hit.normal);

                moveDirection = new Vector3(moveDirection.x, 0.0f, moveDirection.z);
            }
        }

        transform.Translate(moveDirection * mag * Time.deltaTime);
    }

    private float FindAngle(float x, float y)
    {
        float hyp = Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(y, 2));
        float HYP = Mathf.Atan(y / x);

        //Special Case
        if (x == 0)
        {
            if (y > 0) HYP = Mathf.PI * (1 / 2);
            else if (y < 0) HYP = Mathf.PI * (3 / 2);
        }
        
        //1 to 4
        int quadrant = 0;

        //Which Quadrant is the angle in?
        if (y >= 0) {
            if (x >= 0) quadrant = 1;
            else if (x < 0) quadrant = 2;
        }
        else if (y < 0)
        {
            if (x <= 0) quadrant = 3;
            else if (x > 0) quadrant = 4;
        }

        //Make sure that the HYP degree is positive
        if (HYP < 0) HYP += 2 * Mathf.PI;

        //Get Relative Angle
        if (HYP > 0) HYP = HYP - 0;
        else if (HYP < Mathf.PI) HYP = Mathf.PI - HYP;
        else if (HYP > Mathf.PI) HYP = HYP - Mathf.PI;
        else if (HYP < 2 * Mathf.PI) HYP = (2 * Mathf.PI) - HYP;

        //Find True Angle
        if (quadrant == 1) HYP = HYP + 0;
        else if (quadrant == 2) HYP = Mathf.PI - HYP;
        else if (quadrant == 3) HYP = HYP + Mathf.PI;
        else if (quadrant == 4) HYP = (2 * Mathf.PI) - HYP;

        return HYP;
    }
}
