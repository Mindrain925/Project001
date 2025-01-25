using UnityEngine;

public class ArrowDrawer : MonoBehaviour
{
    LineRenderer arrowLine = null;
    Vector3 drawStartPos;
    Vector3 drawEndPos;
    private void Start()
    {
        arrowLine = GetComponent<LineRenderer>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(Camera.main.transform.position, ray.direction * 200, Color.red, 1f);

            int layerMask = (1 << LayerMask.NameToLayer("Ground"));                                 //레이를 쏠 바닥의 레이어 마스크
            if (Physics.Raycast(ray.origin, ray.direction, out RaycastHit hit, 200f, layerMask))    //바닥에 레이 쏘기.
            {
                drawStartPos = hit.point;       //화살표의 시작점.
            }
        }
        else if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            int layerMask = (1 << LayerMask.NameToLayer("Ground"));                                 //레이를 쏠 바닥의 레이어 마스크
            if (Physics.Raycast(ray.origin, ray.direction, out RaycastHit hit, 200f, layerMask))    //바닥에 레이 쏘기.
            {
                drawEndPos = hit.point;     //화살표의 끝점.
                DrawArrow(drawEndPos);
            }
        }
    }
    public void DrawArrow(Vector3 pointer)
    {
        float arrowheadSize = 1;
        pointer.y = drawStartPos.y;

        float percentSize = (float)(arrowheadSize / Vector3.Distance(drawStartPos, pointer));
        arrowLine.positionCount = 4;
        arrowLine.SetPosition(0, drawStartPos);
        arrowLine.SetPosition(1, Vector3.Lerp(drawStartPos, pointer, 0.999f - percentSize));
        arrowLine.SetPosition(2, Vector3.Lerp(drawStartPos, pointer, 1 - percentSize));
        arrowLine.SetPosition(3, pointer);
        arrowLine.widthCurve = new AnimationCurve(

        new Keyframe(0, 0.4f),
        new Keyframe(0.999f - percentSize, 0.4f),
        new Keyframe(1 - percentSize, 1f),
        new Keyframe(1 - percentSize, 1f),
        new Keyframe(1, 0f));
    }
}