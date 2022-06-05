using System;
using System.Collections.Generic;
using System.Text;

namespace AcdimaStore.Services
{
    public enum ToastDuration
    {
        Short,
        Long
    }

    public interface ICrossToast
    {
        void MakeText(string message, ToastDuration duration);
    }
}
