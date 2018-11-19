
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

    public float speed;
    public List<Path> paths;
    public bool Loop;
    public Color pathColor = Color.yellow;
    float currentPathPercent;
    private Vector3[] pathPositions;
    private bool movingIsActive;
    public GameObject bossPath;

    void DrawPath(Transform[] path) //drawing the path in the Editor
    {
        Vector3[] pathPositions = new Vector3[path.Length];
        for (int i = 0; i < path.Length; i++)
        {
            pathPositions[i] = path[i].position;
        }
        Vector3[] newPathPositions = CreatePoints(pathPositions);
        Vector3 previosPositions = Interpolate(newPathPositions, 0);
        Gizmos.color = pathColor;
        int SmoothAmount = path.Length * 20;
        for (int i = 1; i <= SmoothAmount; i++)
        {
            float t = (float)i / SmoothAmount;
            Vector3 currentPositions = Interpolate(newPathPositions, t);
            Gizmos.DrawLine(currentPositions, previosPositions);
            previosPositions = currentPositions;
        }
    }
    Vector3 Interpolate(Vector3[] path, float t)
    {
        int numSections = path.Length - 3;
        int currPt = Mathf.Min(Mathf.FloorToInt(t * numSections), numSections - 1);
        float u = t * numSections - currPt;
        Vector3 a = path[currPt];
        Vector3 b = path[currPt + 1];
        Vector3 c = path[currPt + 2];
        Vector3 d = path[currPt + 3];
        return 0.5f * ((-a + 3f * b - 3f * c + d) * (u * u * u) + (2f * a - 5f * b + 4f * c - d) * (u * u) + (-a + c) * u + 2f * b);
    }

    Vector3[] CreatePoints(Vector3[] path)  //using interpolation method calculating the path along the path points
    {
        Vector3[] pathPositions;
        Vector3[] newPathPos;
        int dist = 2;
        pathPositions = path;
        newPathPos = new Vector3[pathPositions.Length + dist];
        System.Array.Copy(pathPositions, 0, newPathPos, 1, pathPositions.Length);
        newPathPos[0] = newPathPos[1] + (newPathPos[1] - newPathPos[2]);
        newPathPos[newPathPos.Length - 1] = newPathPos[newPathPos.Length - 2] + (newPathPos[newPathPos.Length - 2] - newPathPos[newPathPos.Length - 3]);
        if (newPathPos[1] == newPathPos[newPathPos.Length - 2])
        {
            Vector3[] LoopSpline = new Vector3[newPathPos.Length];
            System.Array.Copy(newPathPos, LoopSpline, newPathPos.Length);
            LoopSpline[0] = LoopSpline[LoopSpline.Length - 3];
            LoopSpline[LoopSpline.Length - 1] = LoopSpline[2];
            newPathPos = new Vector3[LoopSpline.Length];
            System.Array.Copy(LoopSpline, newPathPos, LoopSpline.Length);
        }
        return (newPathPos);
    }
    void OnDrawGizmos()
    {
        for (int i = 0; i < paths.Count; i++)
        {
            DrawPath(paths[i].pathPoints);
        }
    }
    private void Awake()
    {
        bossPath.transform.SetParent(null);
        SetPath(paths[0]);
    }
    public void SetPath(Path path)
    {
        currentPathPercent = 0;
        speed = path.speed;
        pathPositions = new Vector3[path.pathPoints.Length];       //transform path points to vector3
        for (int i = 0; i < pathPositions.Length; i++)
        {
            pathPositions[i] = path.pathPoints[i].position;
        }
        transform.position = NewPositionByPath(pathPositions, 0); //sending the enemy to the path starting point
        
        movingIsActive = true;
    }
    private void Update()
    {
        if (movingIsActive)
        {
            currentPathPercent += speed / 100 * Time.deltaTime;     //every update calculating current path percentage according to the defined speed

            transform.position = NewPositionByPath(pathPositions, currentPathPercent); //moving the 'Enemy' to the path position, calculated in method NewPositionByPath
            
            if (currentPathPercent > 1)                    //when the path is complete
            {
             
                int i = Random.Range(0, paths.Count);
                SetPath(paths[i]);
            }
        }
    }
    Vector3 NewPositionByPath(Vector3[] pathPos, float percent)
    {
        return Interpolate(CreatePoints(pathPos), currentPathPercent);
    }
}
[System.Serializable]
public class Path
{
    public Transform[] pathPoints;
    public float speed;
}
