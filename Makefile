# Phonies
.PHONY: all build

# Variables
SHELL := /bin/bash
QT := $(wildcard \
	*.qml \
)

all : build
build : $(QT)
	@qmlscene main.qml