require 'albacore'

PROJECT_ROOT = File.dirname(__FILE__)

namespace :build do

	desc "Create debug and release builds"
	task :all => [:debug, :release]

	desc "Create a debug build"
	Albacore::MSBuildTask.new(:debug) do |msb|
		outdir = File.join(PROJECT_ROOT, "build/debug/")
	  msb.properties = {:configuration => :Debug, :OutDir => outdir}
	  msb.targets [:Clean, :Rebuild]
	  msb.solution = "src/ScheduMail.sln"
	end
	
	desc "Create a release build"
	Albacore::MSBuildTask.new(:release) do |msb|
		outdir = File.join(PROJECT_ROOT, "build/release/")
	  msb.properties = {:configuration => :Release, :OutDir => outdir}
	  msb.targets [:Clean, :Rebuild]
	  msb.solution = "src/ScheuMail.sln"
	end
	
end