<!--
# Notepad
![Static Badge](https://img.shields.io/badge/Bash-4EAA25?style=for-the-badge&logo=Gnu%20bash&logoColor=FFF)![Static Badge](https://img.shields.io/badge/Make-6D00CC?style=for-the-badge&logo=Make&logoColor=FFF)![Static Badge](https://img.shields.io/badge/Qt-41CD52?style=for-the-badge&logo=Qt&logoColor=FFF)![Static Badge](https://img.shields.io/badge/Ubuntu-E95420?style=for-the-badge&logo=Ubuntu&logoColor=FFF)
## Features to add:
1. Automatically generated complex formatting tags
1. Buttons to insert tags around the cursor
1. File Saving/Loading
1. Support for my [Neographies](https://github.com/JactusTheCactus/conscript-font-gen)
	- [AbugidaR](https://github.com/JactusTheCactus/conscript-font-gen/tree/main/AbugidaR)
	- [Cascadic](https://github.com/JactusTheCactus/conscript-font-gen/tree/main/Cascadic)
## Syntax
-->
|Formatted|Raw|Escaped|
|-|-|-|
|**Bold**|`{=\|Bold\|=}`|`{{=\|Bold\|=}}`|
|*Italic*|`{*\|Italic\|*}`|`{{*\|Italic\|*}}`|
|`Monospace`|`{.\|Monospace\|.}`|`{{.\|Monospace\|.}}`|
|<ins>Underline</ins>|`{_\|Underline\|_}`|`{{_\|Underline\|_}}`|
|~~Strikethrough~~|`{-\|Strikethrough\|-}`|`{{-\|Strikethrough\|-}}`|
<!--
For now, nesting will be used (`{=|{*|Bold+italic|*}|=}`), but eventually complex tag support (`{=*|Bold+Italic|*=}`) will be implemented to be used instead
