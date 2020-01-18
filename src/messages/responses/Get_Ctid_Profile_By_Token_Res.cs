﻿using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Get_Ctid_Profile_By_Token_Res()
        {
            ProtoOAGetCtidProfileByTokenRes args = Serializer.Deserialize<ProtoOAGetCtidProfileByTokenRes>(_processorMemoryStream);

            // log

            OnGetCtidProfileByTokenRes_Received?.Invoke(args);
        }

        public event GetCtidProfileByTokenResReceived OnGetCtidProfileByTokenRes_Received;

        public delegate void GetCtidProfileByTokenResReceived(ProtoOAGetCtidProfileByTokenRes args);
    }
}