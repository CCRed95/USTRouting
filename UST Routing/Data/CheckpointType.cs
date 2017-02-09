namespace UST_Routing.Data
{
	public enum CheckpointType
	{
		Unknown = 0,
		Import = 100,
		PreRouteMailCall = 200,
		ImportII = 300,
		PreRouteUnconfirmed = 400,
		Export = 500,
		ScheduleMailText = 600,
		ScheduleCalls = 700,
		UnconfirmedCalls = 800,
		UnconfirmedCallsII = 900
	}
}
