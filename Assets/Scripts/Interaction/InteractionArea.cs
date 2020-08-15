using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TistouUnity
{
    namespace PuzzleAdventurePack
    {
        public class InteractionArea : MonoBehaviour
        {
            /*Ontriggerenter, if other is interactable, add to list of interactables closeby, select closest item, load choices available on that interactable.
             * Load some UI-controller that just shows button and action in text over item.
             * If player presses button, that option is selected? How do? Dunno, let's just try.
             */
            public Interactable InteractableFocus;
            private List<Interactable> _interactables;
            private void Start()
            {
                _interactables = new List<Interactable>();
            }
            private void Update()
            {
                UpdateFocus();
                if (Input.GetMouseButtonDown(0))
                {
                    if (InteractableFocus)
                    {
                        InteractableFocus.Pick();
                        _interactables.Remove(InteractableFocus);
                        InteractableFocus = null;
                    }
                }
            }
            private void OnTriggerEnter(Collider other)
            {
                var interactable = other.GetComponent<Interactable>();
                if (interactable)
                {
                    _interactables.Add(interactable);
                }
            }
            private void OnTriggerExit(Collider other)
            {
                var interactable = other.GetComponent<Interactable>();
                if (interactable)
                {
                    _interactables.Remove(interactable);
                    if (interactable.Equals(InteractableFocus)){
                        InteractableFocus = null;
                        interactable.UnFocus();
                    }
                }
            }
            private void UpdateFocus()
            {
                if(_interactables.Count > 0)
                {
                    var oldFocus = InteractableFocus;
                    InteractableFocus = Proximity.FindClosest(transform, _interactables);
                    if(InteractableFocus != null)
                    {
                        if (!InteractableFocus.Equals(oldFocus))
                        {
                            if (oldFocus)
                            {
                                oldFocus.UnFocus();
                            }
                            InteractableFocus.Focus();
                            //Focus has changed, so reset the old interactive and show ui on the new interactive.
                            //Load available choices on item-connect to player buttonpress?

                            //UI, show available choises on item
                        }
                    }
                }
            }
        }
    }
}