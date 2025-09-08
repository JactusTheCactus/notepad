.PHONY: all build

SHELL := /bin/bash
QT := $(wildcard *.qml)

all : build
build : $(QT)
	@qmlscene main.qml