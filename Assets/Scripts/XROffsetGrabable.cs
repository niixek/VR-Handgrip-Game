using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XROffsetGrabable : XRGrabInteractable
{

    private Vector3 initAttachLocalPos;
    private Quaternion initAttachLocalRot;

    // Start is called before the first frame update
    void Start()
    {
        if (!attachTransform)
        {
            GameObject grab = new GameObject("Grab Pivot");
            grab.transform.SetParent(transform, false);
            attachTransform = grab.transform;
        }

        initAttachLocalPos = attachTransform.localPosition;
        initAttachLocalRot = attachTransform.localRotation;
    }

    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        if(interactor is XRDirectInteractor)
        {
            attachTransform.position = interactor.transform.position;
            attachTransform.rotation = interactor.transform.rotation;
        }
        else
        {
            attachTransform.localPosition = initAttachLocalPos;
            attachTransform.localRotation = initAttachLocalRot;
        }

        base.OnSelectEntered(interactor);
    }
}
