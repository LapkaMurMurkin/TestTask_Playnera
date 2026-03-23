using System;

using UnityEngine;

namespace TestTask_Playnera
{
    public class HandAnimationEvents : MonoBehaviour
    {
        public event Action OnGetCream;
        public void InvokeOnGetCream() => OnGetCream?.Invoke();

        public event Action OnGetCreamEnd;
        public void InvokeOnGetCreamEnd() => OnGetCreamEnd?.Invoke();

        public event Action OnReturnCream;
        public void InvokeOnReturnCream() => OnReturnCream?.Invoke();

        public event Action OnReturnCreamEnd;
        public void InvokeOnReturnCreamEnd() => OnReturnCreamEnd?.Invoke();

        public event Action OnGetBlushBrush;
        public void InvokeOnGetBlushBrush() => OnGetBlushBrush?.Invoke();

        public event Action OnGetBlushBrushEnd;
        public void InvokeOnGetBlushBrushEnd() => OnGetBlushBrushEnd?.Invoke();

        public event Action OnReturnBlushBrush;
        public void InvokeOnReturnBlushBrush() => OnReturnBlushBrush?.Invoke();

        public event Action OnReturnBlushBrushEnd;
        public void InvokeOnReturnBlushBrushEnd() => OnReturnBlushBrushEnd?.Invoke();

        public event Action OnGetBlushBrushColorEnd;
        public void InvokeOnGetBlushBrushColorEnd() => OnGetBlushBrushColorEnd?.Invoke();

        public event Action OnGetLipstick;
        public void InvokeOnGetLipstick() => OnGetLipstick?.Invoke();

        public event Action OnGetLipstickEnd;
        public void InvokeOnGetLipstickEnd() => OnGetLipstickEnd?.Invoke();

        public event Action OnDOLipstickEnd;
        public void InvokeOnDOLipstickEnd() => OnDOLipstickEnd?.Invoke();

        public event Action OnReturnLipstick;
        public void InvokeOnReturnLipstick() => OnReturnLipstick?.Invoke();

        public event Action OnReturnLipstickEnd;
        public void InvokeOnReturnLipstickEnd() => OnReturnLipstickEnd?.Invoke();
    }
}