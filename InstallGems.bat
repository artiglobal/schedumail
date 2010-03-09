@ECHO *** Update Gems
@call gem update --system

@ECHO *** Installing Rake / Albacore
@call gem install rake rake-compiler albacore
pause