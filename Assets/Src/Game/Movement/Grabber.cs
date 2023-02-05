using System.Collections;
using System.Collections.Generic;
using Game.Src.Game;
using UnityEngine;
using UnityEngine.Serialization;

public class Grabber : MonoBehaviour
{
    public Transform holdPosition;
    public InsideCollider grabCollider;

    private GameObject _grabbing;

    public bool GrabActivated { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        grabCollider.Filter = collider1 => { return collider1.CompareTag(Tags.Grab); };
    }

    // Update is called once per frame
    void Update()
    {
        if (GrabActivated)
        {
            if (_grabbing != null)
            {
                _grabbing.transform.SetParent(null);

                var angle = transform.forward;
                angle.y = 0.3f;
                angle *= 20;

                _grabbing.GetComponent<Rigidbody>().isKinematic = false;
                _grabbing.GetComponent<Rigidbody>().velocity = angle;
                _grabbing = null;

                return;
            }

            Grab();
        }
        FollowObject();
    }


    private void FollowObject()
    {
        if (_grabbing)
        {
            _grabbing.transform.SetPositionAndRotation(holdPosition.position, holdPosition.rotation);
        }
    }

    private void Grab()
    {
        var closest = grabCollider.GetClosestTo(transform);
        if (closest != null)
        {
            _grabbing = closest;
            _grabbing.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}