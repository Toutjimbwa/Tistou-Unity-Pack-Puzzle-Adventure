using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace TistouUnityPackPuzzleAdventure
{
    public class CameraControl : MonoBehaviour
    {
        public static CameraControl ActiveControl;
        public static List<CameraControl> ReadyControls;

        private int priority = 1;
        private Camera _camera;

        public static void ActivatePriority()
        {
            //Check which camera is prioritized
            CameraControl prio = ReadyControls.OrderBy(cc => cc.priority).FirstOrDefault();
            //If it has changed, disable last active control, enable active control
            if (!prio.Equals(ActiveControl))
            {
                Debug.Log("Camera has changed");
                //Disable ActiveControl
                //Change ActiveControl
                //Enable ActiveControl
            }
        }

        public static void Add(CameraControl cc)
        {
            ReadyControls.Add(cc);
            ActivatePriority();
        }

        public static void Remove(CameraControl cc)
        {
            ReadyControls.Remove(cc);
            ActivatePriority();
        }

        public void Activate()
        {
            _camera.enabled = false;
            DynamicCamera dc = GetComponentInChildren<DynamicCamera>(true);
            if (dc)
            {
                dc.enabled = true;
            }
        }

        public void Inactivate()
        {
            _camera.enabled = true;
            DynamicCamera dc = GetComponentInChildren<DynamicCamera>(true);
            if (dc)
            {
                dc.enabled = false;
            }
        }
    }
}