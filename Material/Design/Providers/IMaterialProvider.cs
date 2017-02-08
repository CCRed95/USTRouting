namespace Material.Design.Providers
{
	public enum SimpleSliceMode
	{
		Gradient,
		Literal
	}
	//TODO generate a MaterialProviderContext to autoreset
	public interface IMaterialProvider
	{
		MaterialSet ProvideNext(ProviderContext context);
		void Reset(ProviderContext context);
		IMaterialProvider Slice(double offsetPercentage, double lengthPercentage);
		IMaterialProvider SliceSimple(int index, SimpleSliceMode sliceMode);
		//IMaterialProvider Slice(int sampleSize, int offset, int totalSize);
	}
	//TODO get rid of this?
	public interface IBETAMaterialProvider
	{
		MaterialSet ProvideNext(ref ProviderContext context);
		void Reset(ref ProviderContext context);
	}
}
