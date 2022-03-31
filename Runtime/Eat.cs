using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using QuickVR;

public class Eat : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Animator targetAvatar = QuickSingletonManager.GetInstance<QuickVRManager>().GetAnimatorTarget();
        BoxCollider bCollider = targetAvatar.GetBoneTransform(HumanBodyBones.Head).gameObject.AddComponent<BoxCollider>();
        bCollider.isTrigger = true;
        bCollider.center = new Vector3(0.2f, 0.2f, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
