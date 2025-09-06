.PHONY: all build clean format python
FILES := $(wildcard *.json *.md *.scss)
PY := $(wildcard *.py)
all : format build clean
format : $(FILES)
	@for FILE in $(FILES); do \
		prettier --write $$FILE; \
	done
build : python
python : script.py
	@python3 script.py
clean :