using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AcdimaStore.Services
{
    public interface ICrossScanning
    {
        Task<string> ScanAsync(bool flashOn);
    }
}
