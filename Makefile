.PHONY: all build format python

FILES := $(wildcard \
	*.css \
	*.json \
	*.map \
	*.scss \
	*.html \
	*.md \
)

SCSS := $(wildcard \
	*.scss \
)
CSS := $(patsubst %.scss,%.css,$(SCSS))

PY := $(wildcard *.py)

all : build format python

build : $(SCSS)
	$(foreach FILE,SCSS,sass $^ $(CSS))

format : $(FILES)
	$(foreach FILE,FILES,prettier --write $^)

python : script.py
	python3 script.py