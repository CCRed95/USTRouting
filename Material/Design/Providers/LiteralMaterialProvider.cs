using Material.Static;

namespace Material.Design.Providers
{
	public class LiteralMaterialProvider : IMaterialProvider
	{
		public MaterialSet MaterialSet { get; set; } = Palette.Blue;


		public LiteralMaterialProvider() { }

		public LiteralMaterialProvider(MaterialSet materialSet)
		{
			MaterialSet = materialSet;
		}

		#region Methods
		public MaterialSet ProvideNext(ProviderContext context)
		{
			return MaterialSet;
		}

		public void Reset(ProviderContext context)
		{
		}
		public IMaterialProvider Slice(double offsetPercentage, double lengthPercentage)
		{
			return this;
		}
		public IMaterialProvider SliceSimple(int index, SimpleSliceMode sliceMode)
		{
			return this;
		}

		#endregion

		#region Static Sequences
		public static LiteralMaterialProvider RedProvider = new LiteralMaterialProvider(Palette.Red);

		public static LiteralMaterialProvider PinkProvider = new LiteralMaterialProvider(Palette.Pink);

		public static LiteralMaterialProvider PurpleProvider = new LiteralMaterialProvider(Palette.Purple);

		public static LiteralMaterialProvider DeepPurpleProvider = new LiteralMaterialProvider(Palette.DeepPurple);

		public static LiteralMaterialProvider IndigoProvider = new LiteralMaterialProvider(Palette.Indigo);

		public static LiteralMaterialProvider BlueProvider = new LiteralMaterialProvider(Palette.Blue);

		public static LiteralMaterialProvider LightBlueProvider = new LiteralMaterialProvider(Palette.LightBlue);

		public static LiteralMaterialProvider CyanProvider = new LiteralMaterialProvider(Palette.Cyan);

		public static LiteralMaterialProvider TealProvider = new LiteralMaterialProvider(Palette.Teal);

		public static LiteralMaterialProvider GreenProvider = new LiteralMaterialProvider(Palette.Green);

		public static LiteralMaterialProvider LightGreenProvider = new LiteralMaterialProvider(Palette.LightGreen);

		public static LiteralMaterialProvider LimeProvider = new LiteralMaterialProvider(Palette.Lime);

		public static LiteralMaterialProvider YellowProvider = new LiteralMaterialProvider(Palette.Yellow);

		public static LiteralMaterialProvider AmberProvider = new LiteralMaterialProvider(Palette.Amber);

		public static LiteralMaterialProvider OrangeProvider = new LiteralMaterialProvider(Palette.Orange);

		public static LiteralMaterialProvider DeepOrangeProvider = new LiteralMaterialProvider(Palette.DeepOrange);

		public static LiteralMaterialProvider BrownProvider = new LiteralMaterialProvider(Palette.Brown);

		public static LiteralMaterialProvider GreyProvider = new LiteralMaterialProvider(Palette.Grey);

		public static LiteralMaterialProvider BlueGreyProvider = new LiteralMaterialProvider(Palette.BlueGrey);
		#endregion
	}
}
