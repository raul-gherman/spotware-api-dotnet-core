using System;
using System.Collections.Generic;

namespace spotware
{
    public partial class Client
    {
        private Dictionary<uint, Action> _dispatcher;

        private void Prepare_Dispatcher() => _dispatcher = new Dictionary<uint, Action>
            {
                {50, Process_Error_Res},
                {51, Process_Heartbeat_Event},
                {2101, Process_Application_Auth_Res},
                {2103, Process_Account_Auth_Res},
                {2105, Process_Version_Res},
                {2107, Process_Trailing_SL_Changed_Event},
                {2113, Process_Asset_List_Res},
                {2115, Process_Symbols_List_Res},
                {2117, Process_Symbol_By_Id_Res},
                {2119, Process_Symbols_For_Conversion_Res},
                {2120, Process_Symbol_Changed_Event},
                {2122, Process_Trader_Res},
                {2123, Process_Trader_Update_Event},
                {2125, Process_Reconcile_Res},
                {2126, Process_Execution_Event},
                {2128, Process_Subscribe_Spots_Res},
                {2130, Process_Unsubscribe_Spots_Res},
                {2131, Process_Spot_Event},
                {2132, Process_Order_Error_Event},
                {2134, Process_Deal_List_Res},
                {2138, Process_Get_Trendbars_Res},
                {2140, Process_Expected_Margin_Res},
                {2141, Process_Margin_Changed_Event},
                {2142, Process_Oa_Error_Res},
                {2144, Process_Cash_Flow_History_List_Res},
                {2146, Process_Get_Tickdata_Res},
                {2147, Process_Accounts_Token_Invalidated_Event},
                {2148, Process_Client_Disconnect_Event},
                {2150, Process_Get_Accounts_By_Access_Token_Res},
                {2152, Process_Get_Ctid_Profile_By_Token_Res},
                {2154, Process_Asset_Class_List_Res},
                {2155, Process_Depth_Event},
                {2157, Process_Subscribe_Depth_Quotes_Res},
                {2159, Process_Unsubscribe_Depth_Quotes_Res},
                {2161, Process_Symbol_Category_List_Res},
                {2163, Process_Account_Logout_Res},
                {2164, Process_Account_Disconnect_Event},
                {2165, Process_Unsubscribe_Live_Trendbar_Res},
                {2168, Process_Margin_Call_List_Res},
                {2170, Process_Margin_Call_Update_Res},
                {2171, Process_Margin_Call_Update_Event},
                {2172, Process_Margin_Call_Trigger_Event},
                {2174, Process_Refresh_Token_Res},
            };
    }
}