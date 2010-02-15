using System.Collections.Generic;
using Spark;
using Spark.FileSystem;

namespace OpenRasta.Codecs.Spark.Configuration
{
	public class SparkConfiguration : ISparkConfiguration
	{
		private readonly SparkServiceContainer container;

		public SparkConfiguration()
		{
			container = new SparkServiceContainer();
			container.SetServiceBuilder<ISparkSettings>(c => CreateSparkSettings());
			container.SetServiceBuilder<ISparkViewEngine>(c => new SparkViewEngine(c.GetService<ISparkSettings>())
			                                                   	{
			                                                   		ExtensionFactory = new OpenRastaSparkExtensionsFactory()
			                                                   	});
		}

		#region ISparkConfiguration Members

		public ISparkServiceContainer Container
		{
			get { return container; }
		}

		#endregion

		private SparkSettings CreateSparkSettings()
		{
			var result = new SparkSettings
			             	{
			             		PageBaseType = typeof (SparkResourceView).Name
			             	};
			result.AddViewFolder(ViewFolderType.VirtualPathProvider,
			                     new Dictionary<string, string> {{"virtualBaseDir", "~/views/"}});
			result.AddNamespace("OpenRasta.Web.Markup");
			result.AddNamespace("OpenRasta.Web");
			result.AddNamespace("OpenRasta.Codecs.Spark");
			result.AddNamespace("System.Linq");
			result.AddNamespace("OpenRasta.Codecs.Spark.Extensions");
			return result;
		}
	}
}