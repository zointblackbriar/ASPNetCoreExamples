using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Opc.Ua.Client;
using Opc.Ua;
using System.Threading;

namespace TestSemanticAPI
{
    public enum ExitCode : int
    {
        Ok = 0,
        ErrorCreateApplication = 0x11,
        ErrorDiscoverEndpoints = 0x12,
        ErrorCreateSession = 0x13,
        ErrorBrowseNamespace = 0x14,
        ErrorCreateSubscription = 0x15,
        ErrorMonitoredItem = 0x16,
        ErrorAddSubscription = 0x17,
        ErrorRunning = 0x18,
        ErrorNoKeepAlive = 0x30,
        ErrorInvalidCommandLine = 0x100
    };

    public class OPCUAClient
    {
        public void setEndpoint()
        {
            string endPointURL = "opc.tcp://localhost:51210/UA/SampleServer";
        }
    }

    public class ClientMode
    {
        string endPointURL;
        bool autoAccept = false;
        int runTimeValue = Timeout.Infinite;
        public ClientMode(string _endpointURL, bool _autoAccept, int _stopTimeout)
        {
             endPointURL = _endpointURL;
             autoAccept = _autoAccept;
             runTimeValue = _stopTimeout;
        }
    }
}

