SHELL := /bin/bash
.PHONY: all build python clean package prerequisite
all : prerequisite build clean
prerequisite :
	@source vEnv/bin/activate
build : python package
python : script.py
#	@python3 script.py
package :
	@pyinstaller -F script.py
clean :