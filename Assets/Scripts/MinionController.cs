using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionController : MonoBehaviour {
   
    // Variables
    [SerializeField]
    private int childCount = 5;
    [SerializeField]
    public float angle, range, rotationSpeed;
    [SerializeField]
    List<GameObject> minions = new List<GameObject>();

    // Loading screen initialization
    private void Awake()
    {
        range = 1;
        angle = 360 / childCount;
        rotationSpeed = 50;

        for (int i = 0; i < transform.childCount; i++)
        {
            if(i < childCount)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
            minions.Add(transform.GetChild(i).gameObject);
        }
    }

    float x, y;
    Vector3 formation;
    public void DetermineFormation(bool fromLevelUp)
    {
        if (fromLevelUp)
        {
            for (int i = 0; i < minions.Count; i++)
            {
               
                if (transform.rotation.eulerAngles.z < 0)
                {

                    x = Mathf.Sin(Mathf.Deg2Rad * (transform.rotation.eulerAngles.z + (angle * i))) * range;
                    y = Mathf.Cos(Mathf.Deg2Rad * (transform.rotation.eulerAngles.z + (angle * i))) * range;
                    //while (x != Mathf.Sin(Mathf.Deg2Rad * (transform.rotation.eulerAngles.z + (angle * i))) * range 
                    //    && y != Mathf.Cos(Mathf.Deg2Rad * (transform.rotation.eulerAngles.z + (angle * i))) * range)
                    //{
                    //    x = Mathf.MoveTowards(x, Mathf.Sin(Mathf.Deg2Rad * (transform.rotation.eulerAngles.z + (angle * i))) * range, Time.deltaTime);
                    //    y = Mathf.MoveTowards(y, Mathf.Cos(Mathf.Deg2Rad * (transform.rotation.eulerAngles.z + (angle * i))) * range ,Time.deltaTime);
                    //    //x = Mathf.Sin(Mathf.Deg2Rad * (transform.rotation.eulerAngles.z + (angle * i))) * range;
                    //    //y = Mathf.Cos(Mathf.Deg2Rad * (transform.rotation.eulerAngles.z + (angle * i))) * range;
                    //}
                }
                else
                {
                    x = Mathf.Sin(Mathf.Deg2Rad * (transform.rotation.eulerAngles.z - (angle * i))) * range;
                    y = Mathf.Cos(Mathf.Deg2Rad * (transform.rotation.eulerAngles.z - (angle * i))) * range;

                    //while (x != Mathf.Sin(Mathf.Deg2Rad * (transform.rotation.eulerAngles.z - (angle * i))) * range
                    //   && y != Mathf.Cos(Mathf.Deg2Rad * (transform.rotation.eulerAngles.z - (angle * i))) * range)
                    //{
                    //    x = Mathf.MoveTowards(x, Mathf.Sin(Mathf.Deg2Rad * (transform.rotation.eulerAngles.z - (angle * i))) * range, Time.deltaTime);
                    //    y = Mathf.MoveTowards(y, Mathf.Cos(Mathf.Deg2Rad * (transform.rotation.eulerAngles.z - (angle * i))) * range, Time.deltaTime);
                    //    //x = Mathf.Sin(Mathf.Deg2Rad * (transform.rotation.eulerAngles.z + (angle * i))) * range;
                    //    //y = Mathf.Cos(Mathf.Deg2Rad * (transform.rotation.eulerAngles.z + (angle * i))) * range;
                    //}
                }                
                formation = Vector2.right * x + Vector2.up * y;
                minions[i].transform.position = transform.position + formation;
               
            }
        }
        else
        {
            for (int i = 0; i < minions.Count; i++)
             {
                x = Mathf.Sin(Mathf.Deg2Rad * angle * i) * range;
                y = Mathf.Cos(Mathf.Deg2Rad * angle * i) * range;
                formation = Vector2.right * x + Vector2.up * y;
                minions[i].transform.position = transform.position + formation;
            }
        }
    }

    // Use this for initialization
    void Start () {
        DetermineFormation(false);
    }

    // Update is called once per frame
    void Update () {
        transform.Rotate(Vector3.back * Time.deltaTime * rotationSpeed);
    }
}
