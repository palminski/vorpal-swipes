using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalTrail : MonoBehaviour
{

    public Transform objectToFollow;

    private LineRenderer line;

    public float distIncrement = 0.1f;
    private Vector3 lastPosition;

    public bool limitLength = false;
    public int maxPositions = 10;

    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.useWorldSpace = false;
        Reset();
    }

    private void Reset() {
        line.positionCount = 0; //
        AddPoint(objectToFollow.localPosition);
    }

    private void AddPoint(Vector3 newPoint) {
        line.positionCount += 1;
        line.SetPosition(line.positionCount-1, newPoint);

        if (limitLength && line.positionCount > maxPositions) {
            TruncatePositions(maxPositions);
        }
        lastPosition = newPoint;
    }

    private void TruncatePositions(int newLength) {
        Vector3[] tempList = new Vector3[newLength];
        int nExtraItems = line.positionCount - newLength;
        for (int i=0; i< newLength; i++) {
            tempList[i] = line.GetPosition(i+nExtraItems);
        }
        line.positionCount = newLength;
        line.SetPositions(tempList);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currenPosition = objectToFollow.localPosition;

        if (Vector3.Distance(currenPosition,lastPosition) > distIncrement) {
            AddPoint(currenPosition);
        }
    }
}
