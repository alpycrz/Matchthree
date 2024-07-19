using Components;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Events
{
    public class InputEvents
    {
        public UnityAction<Tile, Vector3> MouseDownGrid;
        public UnityAction<Vector3> MouseUpGrid;
    }
}