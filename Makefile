.PHONY: all scss

all : scss

scss : style.scss
	sass style.scss style.css