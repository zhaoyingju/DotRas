﻿using System;
using System.Runtime.InteropServices;
using System.Text;
using static DotRas.Internal.Interop.NativeMethods;

namespace DotRas.Internal.Interop
{
    internal interface IRasApi32
    {
        int RasEnumConnections(
            RASCONN[] lpRasConn,
            ref int lpCb,
            ref int lpConnections);

        int RasDial(
            ref RASDIALEXTENSIONS lpRasDialExtensions,
            string lpszPhoneBook,
            ref RASDIALPARAMS lpRasDialParams,
            Ras.NotifierType dwNotifierType,
            RasDialFunc2 lpvNotifier,
            out IntPtr lphRasConn);

        int RasGetConnectStatus(
            IntPtr hRasConn,
            ref RASCONNSTATUS lpRasConnStatus);

        int RasGetCredentials(
            string lpszPhonebook,
            string lpszEntryName,
            ref RASCREDENTIALS lpCredentials);

        int RasGetErrorString(
            int uErrorValue,
            StringBuilder lpszErrorString,
            int cBufSize);

        int RasGetConnectionStatistics(
            IntPtr hRasConn,
            [In, Out] ref RAS_STATS lpStatistics);

        int RasGetLinkStatistics(
            IntPtr hRasConn, 
            int dwSubEntry, 
            ref RAS_STATS lpStatistics);

        int RasHangUp(IntPtr hRasConn);

        int RasValidateEntryName(
            string lpszPhonebook,
            string lpszEntryName);
    }
}