# Phonies
.PHONY: all build clean package test clear qml

# Variables
SHELL := /bin/bash
RM := rm -rf
APP := Notepad
TEMP := build $(APP).spec

# Toggle Booleans
RUN_EXEC := false

# Rules
all : clear build #clean test
clear :
	@$(RM) $(TEMP) dist
build : qml #package
package : $(SCRIPT)
	@$(pyinstaller) \
	--clean \
	-n $(APP) \
	-F \
	--add-data "style.scss:." \
	$(SCRIPT)
qml : $(wildcard *.qml)
	@qmlscene main.qml
clean :
	@$(RM) $(TEMP)
test :
ifeq ($(RUN_EXEC),true)
	@cd dist && ./$(APP)
endif