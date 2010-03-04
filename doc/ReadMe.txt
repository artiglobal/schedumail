Building ScheduMail
------------------------------
Dependencies
- Ruby  (Windows Installer available at http://rubyinstaller.org/download.html)
- Albacore (Run install InstallGems.bat at the project root to install)

SqlLite Database
- Instructions for deploying database goes here


Configuration
ScheduMail includes a template configuration file (build/config/env.setting.template) for managing build and runtime settings.  Copy and rename this file to make environmental specific settings.  A default environment of "local" is assumed by the build scripts.

Ex. env.settings.template copy and rename local.settings

You can create multiple environment settings files to distinguish between different deployment environments (ie. prod.settings, myserver.settings, etc.)


Available Build Tasks
To view the available build tasks, use a command line in the project root and enter the following command:
rake --tasks





