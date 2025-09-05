.PHONY: all build format

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

all : build format

build : $(SCSS)
	$(foreach FILE,SCSS,sass $^ $(CSS))

format : $(FILES)
	$(foreach FILE,FILES,prettier --write $^)