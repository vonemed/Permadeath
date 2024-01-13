using UnityEngine;

public class GizmoDrawer : MonoBehaviour
{
    private static GizmoDrawer _instance;

    public static GizmoDrawer Instance => _instance;

    private Vector3 _from;
    private Vector3 _to;
    private bool _draw = false;

    private void Awake()
    {
        _instance = this;
    }

    public void DrawRay(Vector3 from, Vector3 to)
    {
        _from = from;
        _to = to;
    }

    private void OnDrawGizmos()
    {
        if (_draw)
        {
            Debug.DrawRay(_from, _to, Color.red);
        }
    }
}