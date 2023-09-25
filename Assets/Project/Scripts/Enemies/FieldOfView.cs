using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float m_dstVision;
    [Range(0, 360)]
    public float m_angleVision;
    public Transform target;
    [SerializeField] private LayerMask targetMask;
    [SerializeField] private List<Transform> targetsVisibles = new List<Transform>();
    private RaycastHit m_targetHit;
    private void FixedUpdate()
    {
        Detected(target, m_dstVision, m_angleVision);
    }

    private void OnDrawGizmos() {

        // FieldOfView fov = (FieldOfView)target;

        Color color = new Color(1, 0, 0, 0.2f);

        Handles.color = color;
        Handles.DrawSolidArc(
            transform.position,
            transform.up,
            Quaternion.AngleAxis(-m_angleVision * 0.5f, transform.up) * transform.forward,
            m_angleVision,
            m_dstVision
        );

    }
    public void Detected(
        Transform targetTrasfom,
        float distanceVision,
        float angleVision
        )
    {
        targetsVisibles.Clear();
        Vector3 dirToTarget = targetTrasfom.position - transform.position;
        //.Distance, calcula ladistancia entre los dos vectores
        // float dirToTarget = Vector3.Distance(enemyTransform.position, targetTrasfom.position);

        //Si la distancia entre el enemigo y el target es menor a la distancia de vision
        if (dirToTarget.magnitude <= distanceVision)
        {

            //Si el producto punto entre el vector normalizado() y (0,0,1) es >()MAYOR
            //que el coseno de el angulo de vision (* 0.5 o ( / 2)) * Mathf.Deg2Rad(##)
            //##Para convertirlo en radianes revisar este if
            if (Vector3.Dot(
                dirToTarget.normalized, transform.forward
                ) >
                Mathf.Cos(angleVision * 0.5f * Mathf.Deg2Rad)
            )
            {
                // RaycastHit hit;
                // Physics.Raycast(transform.position, dirToTarget, out hit);
                // Debug.Log(hit.transform.tag);
                // Debug.Log("in the angle of vision" + targetTrasfom.position);
                // Debug.DrawRay(transform.position, dirToTarget.normalized);
                // drawRay(transform.position, dirToTarget, dirToTarget.magnitude);

                // drawRay(transform.position, transform.forward, dirToTarget.magnitude, targetTrasfom);
                if (drawRay(transform.position, dirToTarget))
                {
                    targetsVisibles.Add(targetTrasfom);
                }
            }
        }
    }
    private bool drawRay(Vector3 from, Vector3 to/*, float dist/*, LayerMask mask, Transform target*/)
    {
        Physics.Raycast(from, to, out m_targetHit);
        return Physics.Raycast(from, to, out m_targetHit) && m_targetHit.transform.CompareTag("Player");
    }
    public RaycastHit Hit
    {
        get { return m_targetHit; }
    }
    public List<Transform> getTargetList()
    {
        return targetsVisibles;
    }
    public bool WatchingPlayer
    {
        get { return targetsVisibles.Count != 0; }
    }
    public bool InRange
    {
        get { return Vector3.Distance(transform.position, target.position) <= m_dstVision; }
    }
    public Transform getTarget
    {
        get { return target; }
    }
    public float getDistVision{get{return m_dstVision;}}

}
