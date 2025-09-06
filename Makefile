# Phonies
.PHONY: all build python clean package test clear

# Variables
SHELL := /bin/bash
VENV := vEnv/bin/
pyinstaller := $(VENV)pyinstaller
python := $(VENV)python3
pip := $(VENV)pip3
RM := rm -rf
SCRIPT := script.py
APP := Notepad
TEMP := build $(APP).spec

# Toggle Booleans
RUN_PYTHON := false
RUN_EXEC := true

# Rules
all : clear build clean test
clear :
	@$(RM) $(TEMP) dist
build : python package
python : $(SCRIPT)
ifeq ($(RUN_PYTHON),true)
	@$(python) $(SCRIPT)
endif
package : $(SCRIPT)
	@$(pyinstaller) \
	--clean \
	-n $(APP) \
	-F \
	--add-data "style.scss:." \
	$(SCRIPT)
clean :
	@$(RM) $(TEMP)
test :
ifeq ($(RUN_EXEC),true)
	@cd dist && ./$(APP)
endif