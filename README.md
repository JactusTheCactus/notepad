# Notepad

## Features to add:

- [ ] Automatically generated complex formatting tags
	- For now, nesting will be used (`{=|{*|Bold+italic|*}|=}`), but eventually complex tags (`{=*|Bold+Italic|*=}`) can be used instead
- [ ] Tag escaping
	- `{=|Bold|=}` => **Bold**
	- `\{=|Bold|=}` => {=|Bold|=}
- [ ] Buttons to insert tags around the cursor
- [ ] File Saving/Loading
- [ ] Support for my Neographies[^Neo]
    - AbugidaR[^AbR]
    - AlphabetD[^AlD]

## Syntax

|Syntax|Formatted|
|-:|:-|
|`{=\|Bold\|=}`|**Bold**|
|`{*\|Italic\|*}`|*Italic*|
|`{.\|Monospace\|.}`|`Monospace`|
|`{_\|Underline\|_}`|<ins>Underline</ins>|
|`{-\|Strikethrough\|-}`|<s>Strikethrough</s>|

## Tech Stack

![Static Badge](https://img.shields.io/badge/Python-3776AB?style=for-the-badge&logo=Python&logoColor=FFF)
![Static Badge](https://img.shields.io/badge/Qt-41CD52?style=for-the-badge&logo=Qt&logoColor=FFF)
![Static Badge](https://img.shields.io/badge/Make-6D00CC?style=for-the-badge&logo=Make&logoColor=FFF)
![Static Badge](https://img.shields.io/badge/Sass-CC6699?style=for-the-badge&logo=Sass&logoColor=FFF)

***

[^Neo]: [Neographies' Repo](https://github.com/JactusTheCactus/conscript-font-gen)

[^AbR]: [AbugidaR](https://github.com/JactusTheCactus/conscript-font-gen/tree/eb32dcf2e69f757c483aa0ffe4746b8387cea251/AbugidaR)

[^AlD]: [AlphabetD](https://github.com/JactusTheCactus/conscript-font-gen/tree/eb32dcf2e69f757c483aa0ffe4746b8387cea251/AlphabetD)