all : build run # `all` is currently pointless, but will be necessary after `build` is properly implemented
build :
	@echo "No Build Configuration Available"
run : $(QML)
	@qmlscene main.qml