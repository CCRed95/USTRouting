using System;
using System.Collections.Generic;
using System.Linq;

namespace Material.Design.Providers
{
	public class SequentialMaterialProviderProvider : IMaterialProviderProvider
	{
		#region Properties
		public List<IMaterialProvider> MaterialProviderSequence { get; }

		public CyclicalBehavior CyclicalMode { get; }

		public bool Reverse { get; set; }
		#endregion

		#region Fields
		private MirrorDirection mirrorDirection = MirrorDirection.Forward;
		private int currentIndex;
		#endregion

		#region Constructors
		public SequentialMaterialProviderProvider()
			: this(new List<IMaterialProvider>())
		{ }

		public SequentialMaterialProviderProvider(params IMaterialProvider[] materialSetSequence)
			: this(CyclicalBehavior.Repeat, materialSetSequence)
		{ }

		public SequentialMaterialProviderProvider(IList<IMaterialProvider> materialSetSequence)
			: this(CyclicalBehavior.Repeat, materialSetSequence)
		{ }

		public SequentialMaterialProviderProvider(CyclicalBehavior mode = CyclicalBehavior.Repeat,
			params IMaterialProvider[] materialSetSequence) : this(mode, materialSetSequence.ToList())
		{ }

		public SequentialMaterialProviderProvider(CyclicalBehavior mode, IList<IMaterialProvider> materialSetSequence)
		{
			MaterialProviderSequence = new List<IMaterialProvider>(materialSetSequence);
			CyclicalMode = mode;
		}
		#endregion

		#region Methods
		public IMaterialProvider ProvideNext(ProviderContext context)
		{
			switch (CyclicalMode)
			{
				case CyclicalBehavior.Repeat:
					{
						if (currentIndex > MaterialProviderSequence.Count - 1)
							currentIndex = 0;
						if (currentIndex < 0)
							currentIndex = MaterialProviderSequence.Count - 1;

						var currentSet = MaterialProviderSequence[currentIndex];
						if (Reverse)
							currentIndex--;
						else
							currentIndex++;
						return currentSet;
					}
				case CyclicalBehavior.Mirror:
					{
						if (currentIndex > MaterialProviderSequence.Count - 1)
						{
							currentIndex = MaterialProviderSequence.Count - 2;
							mirrorDirection = MirrorDirection.Backward;
						}
						else if (currentIndex < 0)
						{
							currentIndex = 1;
							mirrorDirection = MirrorDirection.Forward;
						}
						var currentSet = MaterialProviderSequence[currentIndex];

						switch (mirrorDirection)
						{
							case MirrorDirection.Forward:
								currentIndex++;
								break;
							case MirrorDirection.Backward:
								currentIndex--;
								break;
						}
						return currentSet;
					}
				default:
					throw new NotSupportedException($"Cyclical Mode {CyclicalMode} is not supported.");
			}
		}

		public void Reset(ProviderContext context)
		{
			if (Reverse)
				currentIndex = context.CycleLength - 1;
			else
				currentIndex = 0;
		}
		#endregion
	}
}
