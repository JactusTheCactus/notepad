# Notepad
## Features to add:
1. Automatically generated complex formatting tags[^Auto]
1. Buttons to insert tags around the cursor
1. File Saving/Loading
1. Support for my Neographies[^Neo]
## Syntax
- `{=\|Bold\|=}` => **Bold**
- `{*\|Italic\|*}` => *Italic*
- `{.\|Monospace\|.}` => `Monospace`
- `{_\|Underline\|_}` => <ins>Underline</ins>
- `{-\|Strikethrough\|-}` => <s>Strikethrough</s>
- Double curly braces escape formatting
	- `{=|Bold|=}` => **Bold**
	- `{{=|Bold|=}}` => {=|Bold|=}
## Tech Stack
![Static Badge](https://img.shields.io/badge/Bash-4EAA25?style=for-the-badge&logo=Gnu%20bash&logoColor=FFF)
![Static Badge](https://img.shields.io/badge/Make-6D00CC?style=for-the-badge&logo=Make&logoColor=FFF)
![Static Badge](https://img.shields.io/badge/Qt-41CD52?style=for-the-badge&logo=Qt&logoColor=FFF)
![Static Badge](https://img.shields.io/badge/Ubuntu-E95420?style=for-the-badge&logo=Ubuntu&logoColor=FFF)
[^Neo]: [Neographies Repo](https://github.com/JactusTheCactus/conscript-font-gen) ([AbugidaR](https://github.com/JactusTheCactus/conscript-font-gen/tree/main/AbugidaR) & [Cascadic](https://github.com/JactusTheCactus/conscript-font-gen/tree/main/Cascadic))
[^Auto]: For now, nesting will be used (`{=|{*|Bold+italic|*}|=}`), but eventually complex tags (`{=*|Bold+Italic|*=}`) will be used instead
