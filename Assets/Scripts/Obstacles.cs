using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public GameObject course1;
    public GameObject course2;
    public GameObject course3;
    public GameObject enemyCourse1;
    public GameObject enemyCourse2;

    public GameObject triShift;
    public GameObject sqShift;
    public GameObject penShift;
    public GameObject hexShift;
    public GameObject hepShift;
    public GameObject octShift;


    private int courseRange;
    private int shiftShape;

    private int enemyCourse;
    //public bool enemyAlive;

    // Start is called before the first frame update
    void Start()
    {
        //enemyAlive = false;
        InvokeRepeating("createObstacle", 0.2f, 4);
    }

    // Update is called once per frame
    void Update()
    {
        courseRange = Random.Range(1, 6);
        enemyCourse = Random.Range(1, 3);

        shiftShape = Random.Range(3, 9);
    }

    void createObstacle()
    {
        if (courseRange == 1)
        {
            Instantiate(enemyCourse1);
        }

        else if (courseRange == 2)
        {
            Instantiate(course2);
        }

        else if (courseRange == 3)
        {
            Instantiate(course3);
        }

        else if (courseRange == 4)
        {
            if (shiftShape == 3)
            {
                Instantiate(triShift);
            }

            else if (shiftShape == 4)
            {
                Instantiate(sqShift);
            }

            else if (shiftShape == 5)
            {
                Instantiate(penShift);
            }

            else if (shiftShape == 6)
            {
                Instantiate(hexShift);
            }

            else if (shiftShape == 7)
            {
                Instantiate(hepShift);
            }

            else
            {
                Instantiate(octShift);
            }
        }

        else
        {
            /*if (enemyAlive)
            {
                Instantiate(course1);
            }

            else
            {*/
            if (enemyCourse == 1)
            {
                Instantiate(enemyCourse1);
            }
            else
            {
                Instantiate(enemyCourse2);
            }

                //enemyAlive = true;
            //}
        }
    }

}
