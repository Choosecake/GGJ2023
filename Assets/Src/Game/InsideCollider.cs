using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

public class InsideCollider : MonoBehaviour
{
    public Predicate<Collider> Filter { get; set; }


    public HashSet<GameObject> _insideCollider = new();
    public int Inside = 0;

    [CanBeNull]
    public GameObject GetClosestTo(Transform baseTransform)
    {
        GameObject closest = null;
        float closestDistance = 0;

        foreach (var o in _insideCollider)
        {
            var distance = Vector3.Distance(baseTransform.position, o.transform.position);

            if (closest == null || distance < closestDistance)
            {
                closest = o;
                closestDistance = distance;
            }
        }

        return closest;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (Filter != null && !Filter(other))
        {
            return;
        }

        _insideCollider.Add(other.gameObject);
        Inside = _insideCollider.Count;;

    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit");
        if (Filter != null && !Filter(other))
        {
            return;
        }
        _insideCollider.Remove(other.gameObject);
        Inside = _insideCollider.Count;
    }
    

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}