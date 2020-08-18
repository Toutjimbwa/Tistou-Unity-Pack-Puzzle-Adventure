using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TistouUnity
{
    namespace PuzzleAdventurePack
    {
        public class Item : Interactable
        {
            public float floatY = 0.5f;
            private Transform _model;
            public Vector3 _modelOriginalPos;
            private void Start()
            {
                _model = transform.Find("Model");
                _modelOriginalPos = _model.localPosition;
            }
            public override void Focus()
            {
                ModelUp();
            }
            public override void UnFocus()
            {
                ModelDown();
            }
            public override void Pick()
            {
                GetComponent<Collider>().enabled = false;
                GetComponent<Rigidbody>().isKinematic = true;
                var player = GameObject.FindGameObjectWithTag("Player");
                transform.parent = player.GetComponentInChildren<Inventory>().transform;
                transform.localPosition = new Vector3(0, 0, 0);
            }
            private void ModelUp()
            {
                _model.localPosition = _modelOriginalPos + new Vector3(0, 0.2f, 0);
            }
            private void ModelDown()
            {
                _model.localPosition = _modelOriginalPos;
            }
            public bool InInventory()
            {
                return GetComponentInParent<Inventory>() ? true : false;
            }
        }
    }
}