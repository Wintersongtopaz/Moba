using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//Path Editor: A custom editor script used to easily move path points in the Scene vieo
[CustomEditor(typeof(NavPath))]
public class PathEditor : Editor
{
    int targetIndex;

    public void OnSceneGUI()
    {
        Tools.current = Tool.None;
        NavPath navPath = target as NavPath;

        for (int i = 0; i < navPath.pathPoints.Count; i++)
        {
            //Handles.Button(); A scene view button
            if(Handles.Button(navPath.pathPoints[i], Quaternion.identity, 1f, 1f, Handles.SphereHandleCap))
            {
                targetIndex = i;
                break;
            }
        }

        if (targetIndex >= 0 && targetIndex < navPath.pathPoints.Count)
        {
            //Handles.PositionHandle(): Creates a position handle to move path points
            navPath.pathPoints[targetIndex] = Handles.PositionHandle(navPath.pathPoints[targetIndex], Quaternion.identity);

        }
    }
}
//Nav Path: Holds a sequential list of points representing a path
public class NavPath : MonoBehaviour
{
    public List<Vector3> pathPoints; // points in the path
    public bool loop; // whether the pathloops at the end
    //Draw a sphere at each point and a line from one point to the next
    void OnDrawGizmos()
    {
        if (pathPoints.Count == 0) return;

        for(int i = 0; i < pathPoints.Count - 1; i++)
        {
            Gizmos.DrawLine(pathPoints[i], pathPoints[i + 1]);
            Gizmos.DrawSphere(pathPoints[i], 0.5f);
        }
        Gizmos.DrawSphere(pathPoints[pathPoints.Count - 1], 0.5f);
        if (loop)
        {
            Gizmos.DrawLine(pathPoints[pathPoints.Count - 1], pathPoints[0]);
        }
    }
}
