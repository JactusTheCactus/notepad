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

- [![Python](https://img.shields.io/badge/Python-3776AB?logo=python&logoColor=fff)](#)
	- ![Qt](https://img.shields.io/badge/Qt-%23217346.svg?style=for-the-badge&logo=Qt&logoColor=white)
- Make
- [![CSS](https://img.shields.io/badge/CSS-639?logo=css&logoColor=fff)](#)
	- [![Sass](https://img.shields.io/badge/Sass-C69?logo=sass&logoColor=fff)](#)![SASS](https://img.shields.io/badge/SASS-hotpink.svg?style=for-the-badge&logo=SASS&logoColor=white)

[^Neo]: [Neographies' Repo](https://github.com/JactusTheCactus/conscript-font-gen)

[^AbR]: [AbugidaR](https://github.com/JactusTheCactus/conscript-font-gen/tree/eb32dcf2e69f757c483aa0ffe4746b8387cea251/AbugidaR)

[^AlD]: [AlphabetD](https://github.com/JactusTheCactus/conscript-font-gen/tree/eb32dcf2e69f757c483aa0ffe4746b8387cea251/AlphabetD)