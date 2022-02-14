using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace SnowBuilder.Properties
{
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		private static ResourceManager resourceMan;

		private static CultureInfo resourceCulture;

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (resourceMan == null)
				{
					resourceMan = new ResourceManager("SnowBuilder.Properties.Resources", typeof(Resources).Assembly);
				}
				return resourceMan;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return resourceCulture;
			}
			set
			{
				resourceCulture = value;
			}
		}

		internal static Bitmap error => (Bitmap)ResourceManager.GetObject("error", resourceCulture);

		internal static Bitmap info => (Bitmap)ResourceManager.GetObject("info", resourceCulture);

		internal static string Program => ResourceManager.GetString("Program", resourceCulture);

		internal static Bitmap success => (Bitmap)ResourceManager.GetObject("success", resourceCulture);

		internal static Bitmap warning => (Bitmap)ResourceManager.GetObject("warning", resourceCulture);

		internal Resources()
		{
		}
	}
}
