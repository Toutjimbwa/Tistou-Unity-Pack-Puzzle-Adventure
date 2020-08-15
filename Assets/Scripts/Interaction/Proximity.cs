using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TistouUnity
{
    namespace PuzzleAdventurePack
    {
        public static class Proximity
        {
            public static Interactable FindClosest(Transform center, List<Interactable> interactables)
            {
                Transform[] transforms = interactables.Select(f => f.transform).ToArray();
                Transform closestTransform = transforms.OrderBy(t => (center.position - t.position).sqrMagnitude).FirstOrDefault();
                if (closestTransform != null)
                {
                    return closestTransform.GetComponent<Interactable>();
                }
                else
                {
                    return null;
                }
            }
        }
    }
}