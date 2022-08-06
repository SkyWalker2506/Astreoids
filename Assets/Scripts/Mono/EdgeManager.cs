using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeManager : MonoBehaviour
{
    Camera mainCamera;
    float depth;

    public static Vector3 UpperLeft;
    public static Vector3 UpperRight;
    public static Vector3 LowerLeft;
    public static Vector3 LowerRight;
    public static Vector3 RandomUpperEdgePosition => Vector3.Lerp(UpperLeft, UpperRight, Random.value);
    public static Vector3 RandomLowerEdgePosition => Vector3.Lerp(LowerLeft, LowerRight, Random.value);
    public static Vector3 RandomRightEdgePosition => Vector3.Lerp(LowerRight, UpperRight, Random.value);
    public static Vector3 RandomLeftEdgePosition => Vector3.Lerp(LowerLeft, UpperLeft, Random.value);


    private void Start()
    {
        depth = (Spaceship.Instance.transform.position.z - Camera.main.transform.position.z);
        mainCamera = Camera.main;
        SetEdges();
    }

    void SetEdges()
    {
        var upperLeftScreen = new Vector3(0, 1, depth);
        var upperRightScreen = new Vector3(1, 1, depth);
        var lowerLeftScreen = new Vector3(0, 0, depth);
        var lowerRightScreen = new Vector3(1, 0, depth);

        UpperLeft = mainCamera.ViewportToWorldPoint(upperLeftScreen);
        UpperRight = mainCamera.ViewportToWorldPoint(upperRightScreen);
        LowerLeft = mainCamera.ViewportToWorldPoint(lowerLeftScreen);
        LowerRight = mainCamera.ViewportToWorldPoint(lowerRightScreen);
    }

    public static Vector3 RandomEdgePosition()
    {
        int caseNo= Random.Range(0, 3);
        switch (caseNo)
        {
            case 0:
                return RandomUpperEdgePosition;
            case 1:
                return RandomLowerEdgePosition;
            case 2:
                return RandomRightEdgePosition;
            default:
                return RandomLeftEdgePosition;
        }
    }

}
