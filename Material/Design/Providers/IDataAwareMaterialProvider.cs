namespace Material.Design.Providers
{
	public interface IDataAwareMaterialProvider : IMaterialProvider
	{
		MaterialSet ProvideNextDataAware(DataAwareProviderContext context, double dataPoint);
	}
}
