using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TistouUnity
{
    namespace PuzzleAdventurePack
    {
        public class CameraControl : MonoBehaviour
        {
            public static CameraControl ActiveControl;
            public static List<CameraControl> ReadyControls = new List<CameraControl>();
            public int Grade = 0;
            protected Camera _camera;
            protected AudioListener _audioListener;
            public static void SelectCameraControl()
            {
                //Check which camera is prioritized
                var control = ReadyControls.OrderBy(cc => cc.Grade).FirstOrDefault();
                //If it has changed, disable last active control, enable active control
                if (!control.Equals(ActiveControl))
                {
                    ActiveControl.Inactivate();
                    ActiveControl = control;
                    ActiveControl.Activate();
                }
            }

            public static void Add(CameraControl cc)
            {
                Debug.Log(cc.gameObject.name);
                ReadyControls.Add(cc);
                SelectCameraControl();
            }

            public static void Remove(CameraControl cc)
            {
                ReadyControls.Remove(cc);
                SelectCameraControl();
                cc.Inactivate();
            }

            public void Activate()
            {
                _camera.enabled = true;
                _audioListener.enabled = true;
                var dc = GetComponentInChildren<DynamicCamera>(true);
                if (dc)
                {
                    dc.enabled = true;
                }
            }

            public void Inactivate()
            {
                _camera.enabled = false;
                _audioListener.enabled = false;
                var dc = GetComponentInChildren<DynamicCamera>(true);
                if (dc)
                {
                    dc.enabled = false;
                }
            }
        }
    }
}