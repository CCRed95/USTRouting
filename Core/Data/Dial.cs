using System.Runtime.CompilerServices;
using Core.Collections;

namespace Core.Data
{
	public enum Dial
	{
		P = 200,
		K = 206,

	}
	public class DialInfo
	{
		public int CellID { get; }
		public string Description { get; }
		public int Sequence { get; }
		public int UPH { get; }

		public DialInfo(int cellid, string description = "", int sequence = -1, int uph = -1)
		{
			CellID = cellid;
			Description = description;
			Sequence = sequence;
			UPH = uph;
		}
	}
	public class DialDefinitions : FlexEnum<DialInfo>
	{
		public DialDefinitions(DialInfo value, [CallerMemberName]string fieldName = null, [CallerLineNumber] int line = 0)
			: base(value, fieldName, line)
		{
		}
		public static DialDefinitions A = new DialDefinitions(new DialInfo(100, "Trackpad PCBA/FR", 1));
		public static DialDefinitions M = new DialDefinitions(new DialInfo(105, "Trackpad", 2));
		public static DialDefinitions B = new DialDefinitions(new DialInfo(110, "Trackpad FPC Solder/Test", 3));
		public static DialDefinitions C = new DialDefinitions(new DialInfo(120, "Case Top & Button", 4));
		public static DialDefinitions D = new DialDefinitions(new DialInfo(130, "Trackpad to Case Top", 5));
		public static DialDefinitions E = new DialDefinitions(new DialInfo(140, "Trigger Frame", 6));

		public static DialDefinitions G = new DialDefinitions(new DialInfo(160, "Bumper and Trigger Frame to Main PCB", 7));
		public static DialDefinitions R = new DialDefinitions(new DialInfo(165, "Joystick Cap", 8)); 
		public static DialDefinitions H = new DialDefinitions(new DialInfo(170, "FPC Insert To Main Board", 9));
		public static DialDefinitions I = new DialDefinitions(new DialInfo(180, "Battery Lever and Latch to Lower Case", 10));
		public static DialDefinitions J = new DialDefinitions(new DialInfo(190, "Upper Case to Lower Case and Label", 11));
		public static DialDefinitions P = new DialDefinitions(new DialInfo(200, "RF Test", 12));
		public static DialDefinitions Q = new DialDefinitions(new DialInfo(204, "Battery Door", 13));
		public static DialDefinitions K = new DialDefinitions(new DialInfo(206, "Test", 14));
		public static DialDefinitions S = new DialDefinitions(new DialInfo(410, "Load Main Circuit Board", 15));

		public static DialDefinitions ST = new DialDefinitions(new DialInfo(208));

		public static DialDefinitions V = new DialDefinitions(new DialInfo(250));
		public static DialDefinitions X = new DialDefinitions(new DialInfo(260));
		public static DialDefinitions Y = new DialDefinitions(new DialInfo(270));
		
		public static DialDefinitions CD = new DialDefinitions(new DialInfo(501, "Depalletizer"));
		public static DialDefinitions CT = new DialDefinitions(new DialInfo(502, "TrayLoader"));
		public static DialDefinitions CC = new DialDefinitions(new DialInfo(503, "Cartoner"));
		public static DialDefinitions CS = new DialDefinitions(new DialInfo(504, "Sleever"));
		public static DialDefinitions CP = new DialDefinitions(new DialInfo(505, "CasePack"));
		public static DialDefinitions CE = new DialDefinitions(new DialInfo(601, "Carton Erector"));

		public static DialDefinitions LP = new DialDefinitions(new DialInfo(506, "Link Palletizer"));
		public static DialDefinitions LD = new DialDefinitions(new DialInfo(507, "Link Depalletizer"));
		public static DialDefinitions LT = new DialDefinitions(new DialInfo(508, "Link Trayloader"));
		public static DialDefinitions LC = new DialDefinitions(new DialInfo(509, "Link Cartoner"));
		public static DialDefinitions LS = new DialDefinitions(new DialInfo(510, "Link Palletizer"));
		public static DialDefinitions LCP = new DialDefinitions(new DialInfo(511, "Link Case Pack"));
		public static DialDefinitions LE = new DialDefinitions(new DialInfo(602, "Link Carton Erector"));
	}
}
