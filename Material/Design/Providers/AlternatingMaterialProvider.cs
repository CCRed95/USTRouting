using Material.Static;

namespace Material.Design.Providers
{
	public class AlternatingMaterialProvider : IMaterialProvider
	{
		#region Properties

		public MaterialSet MaterialSet1 { get; set; } = Palette.Blue;

		public MaterialSet MaterialSet2 { get; set; } = Palette.Green;
		#endregion

		#region Fields
		private int currentIndex;
		#endregion

		#region Constructors
		public AlternatingMaterialProvider() { }

		public AlternatingMaterialProvider(MaterialSet materialSet1, MaterialSet materialSet2)
		{
			MaterialSet1 = materialSet1;
			MaterialSet2 = materialSet2;
		}
		#endregion

		#region Methods
		public MaterialSet ProvideNext(ProviderContext context)
		{
			var materialSet = currentIndex % 2 == 0 ? MaterialSet1 : MaterialSet2;
			currentIndex++;
			return materialSet;
		}

		public void Reset(ProviderContext context)
		{
			currentIndex = 0;
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
		public static AlternatingMaterialProvider AltGP =
			new AlternatingMaterialProvider(Palette.Green, Palette.Pink);

		public static AlternatingMaterialProvider AltGPRev =
			new AlternatingMaterialProvider(Palette.Pink, Palette.Green);

		public static AlternatingMaterialProvider NonAltB =
			new AlternatingMaterialProvider(Palette.Blue, Palette.Blue);
		#endregion
	}
}

