include FileTest
require 'albacore'

COMPILE_TARGET = "debug"
PROJECT_ROOT = File.dirname(__FILE__)
OUTPUT_DIR = File.join(PROJECT_ROOT, "build/bin/#{COMPILE_TARGET}/")

	desc "Create build"
	task :all => [:config, :compile]
	
	desc "Prepares the working directory for a new build"
	task :clean do
	  Dir.mkdir OUTPUT_DIR unless exists?(OUTPUT_DIR)
	end

	desc "Expand .config files for the correct environment"
	expandtemplates :config, [:env] do |tmp, args|
		args.with_defaults(:env => "local")
		tmp.expand_files "build/config/web.config.template" => "src/ScheduMail.WebMvcSpark/web.config"
		tmp.expand_files "build/config/schedulmailrunner.app.config.template" => "src/ScheduMailRunner/app.config"
		tmp.data_file = "build/config/#{args.env}.settings"
	end

	desc "Create a build"
	msbuild :compile => [:clean] do |msb|
		
	  msb.properties = {:configuration => :Debug, :OutDir => OUTPUT_DIR}
	  msb.targets [:Clean, :Rebuild]
	  msb.verbosity = "minimal"
	  msb.solution = "src/ScheduMail.sln"
	end
	
	desc "Runs unit tests"
	task :test => [:unit_test]
	 
	desc "Runs unit tests"
	nunit  :unit_test => [:compile] do |nunit|
	  testpath = "build/bin/#{COMPILE_TARGET}"
	  nunit.path_to_command = "lib/NUnit/nunit-console.exe"
	  nunit.assemblies "#{testpath}/ScheduMail.CoreTest.dll", "#{testpath}/ScheduMail.Spark.TemplateParserTest.dll", "#{testpath}/ScheduMail.UnitsOfWorkTests.dll"
	end