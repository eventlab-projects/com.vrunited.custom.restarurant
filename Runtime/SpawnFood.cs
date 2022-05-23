using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;

using QuickVR;

using UnityEngine.XR.Interaction.Toolkit;

public class SpawnFood : MonoBehaviour
{

    // Start is called before the first frame update
    protected virtual IEnumerator Start()
    {
        QuickVRInteractionManager interactionManager = QuickSingletonManager.GetInstance<QuickVRInteractionManager>();

        interactionManager.GetVRInteractorHandLeft().EnableInteractorGrabDirect(true);
        interactionManager.GetVRInteractorHandRight().EnableInteractorGrabDirect(true);

        foreach (XRGrabInteractable interactable in FindObjectsOfType<XRGrabInteractable>())
        {
            interactable.selectEntered.AddListener(OnGrabInteractable);
            PhotonView networkView = interactable.GetComponent<PhotonView>();
            if (networkView)
            {
                networkView.OwnershipTransfer = OwnershipOption.Takeover;
            }
        }

        yield return new WaitForSeconds(1);

        Animator targetAvatar = QuickSingletonManager.GetInstance<QuickVRManager>().GetAnimatorTarget();
        Transform tEat = targetAvatar.GetBoneTransform(HumanBodyBones.Head).CreateChild("__Eat__");
        BoxCollider bCollider = tEat.gameObject.AddComponent<BoxCollider>();
        bCollider.isTrigger = true;
        bCollider.size = new Vector3(0.2f, 0.2f, 0.3f);
    }

    protected virtual void OnGrabInteractable(SelectEnterEventArgs args)
    {
        //Debug.Log("FOOD GRABBED!!!");
        args.interactable.GetComponent<PhotonView>().RequestOwnership();
    }
}
