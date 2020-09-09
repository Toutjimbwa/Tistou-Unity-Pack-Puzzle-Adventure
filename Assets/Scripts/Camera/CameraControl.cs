using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TistouUnity
{
    namespace PuzzleAdventurePack
    {
        public class CameraControl : MonoBehaviour
        {
            private static CameraControl _activeControl;
            private static List<CameraControl> _readyControls = new List<CameraControl>();
            public int Grade = 0;
            protected Camera _camera;
            protected AudioListener _audioListener;
            private static void SelectCameraControl()
            {
                //Check which camera is prioritized
                var cameraControl = _readyControls.OrderByDescending(cc => cc.Grade).FirstOrDefault();
                //If it has changed, disable last active control, enable active control
                if (!cameraControl.Equals(_activeControl))
                {
                    if(_activeControl)
                    {
                        _activeControl.Inactivate();
                    }
                    _activeControl = cameraControl;
                    _activeControl.Activate();
                }
            }

            protected static void Add(CameraControl cc)
            {
                if (_readyControls.Contains(cc))
                {
                    Debug.Log($"YES {cc.gameObject.name} cameracontrol exists");
                }
                _readyControls.Add(cc);
                SelectCameraControl();
            }

            protected static void Remove(CameraControl cc)
            {
                _readyControls.Remove(cc);
                SelectCameraControl();
                cc.Inactivate();
            }

            private void Activate()
            {
                _camera.enabled = true;
                _audioListener.enabled = true;
                var dc = GetComponentInChildren<DynamicCamera>(true);
                if (dc)
                {
                    dc.enabled = true;
                }
            }

            private void Inactivate()
            {
                _camera.enabled = false;
                _audioListener.enabled = false;
                var dc = GetComponentInChildren<DynamicCamera>(true);
                if (dc)
                {
                    dc.enabled = false;
                }
            }

            public void ResetReadyControls()
            {
                _readyControls.Clear();
            }
        }
    }
}