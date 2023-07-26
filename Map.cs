using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    private Transform PointToSpawnMap;
    private Transform PointToSpawnMap1;
    private Transform PointToSpawnMap2;
    private Transform PointToSpawnMap3;
    public GameObject minimap;
    private float distance;
    private Transform point;
    private Transform point1;
    private Transform point2;
    private Transform point3;
    public float Range;
    public float Tgian;
    private float timetospawn;
    // Start is called before the first frame update
    void Start()
    {
        timetospawn = Tgian;
        point = GameObject.FindGameObjectWithTag("Map").transform;
        point1 = GameObject.FindGameObjectWithTag("Map1").transform;
        point2 = GameObject.FindGameObjectWithTag("Map2").transform;
        point3 = GameObject.FindGameObjectWithTag("Map3").transform;
        PointToSpawnMap = GameObject.FindGameObjectWithTag("Map02").transform;
        PointToSpawnMap1 = GameObject.FindGameObjectWithTag("Map03").transform;
        PointToSpawnMap2 = GameObject.FindGameObjectWithTag("Map04").transform;
        PointToSpawnMap3 = GameObject.FindGameObjectWithTag("Map05").transform;
        distance =  Vector2.Distance(transform.position, point.position);
        
    }

    // Update is called once per frame
    void Update()
    {
        Test();
    }

    private void Test()
    {
        timetospawn-=Time.deltaTime;
        distance =  Vector2.Distance(transform.position, point.position);
        if (timetospawn <= 0)
        {
        if (Vector2.Distance(transform.position, point.position) <= Range)
        {
            Instantiate(minimap, PointToSpawnMap.position, Quaternion.identity);
             timetospawn = Tgian;
        }
        else if (Vector2.Distance(transform.position, point1.position) <= Range)
        {
            Instantiate(minimap, PointToSpawnMap1.position, Quaternion.identity);
             timetospawn = Tgian;
        }
        else if (Vector2.Distance(transform.position, point2.position) <= Range)
        {
            Instantiate(minimap, PointToSpawnMap2.position, Quaternion.identity);
             timetospawn = Tgian;
        }
        else if (Vector2.Distance(transform.position, point3.position) <= Range)
        {
            Instantiate(minimap, PointToSpawnMap3.position, Quaternion.identity);
             timetospawn = Tgian;
        }
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
