.PHONY: all build format

all : build format

build : style.scss
	sass style.scss style.css

format : $(wildcard \
	*.css \
	*.json \
	*.map \
	*.scss \
	*.html \
	*.md \
)
	$(foreach FILE,FILES,prettier --write $^)