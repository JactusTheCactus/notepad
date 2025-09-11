# Notepad
![Static Badge](https://img.shields.io/badge/Bash-4EAA25?style=for-the-badge&logo=Gnu%20bash&logoColor=FFF)![Static Badge](https://img.shields.io/badge/Make-6D00CC?style=for-the-badge&logo=Make&logoColor=FFF)![Static Badge](https://img.shields.io/badge/Qt-41CD52?style=for-the-badge&logo=Qt&logoColor=FFF)![Static Badge](https://img.shields.io/badge/Ubuntu-E95420?style=for-the-badge&logo=Ubuntu&logoColor=FFF)
## Features to add
1. Automatically generated complex formatting tags
1. Buttons to insert tags around the cursor
1. File Saving / Loading
1. Support for my [Neographies](https://github.com/JactusTheCactus/conscript-font-gen)
	- [AbugidaR](https://github.com/JactusTheCactus/conscript-font-gen/tree/main/AbugidaR)
	- [Cascadic](https://github.com/JactusTheCactus/conscript-font-gen/tree/main/Cascadic)
## Syntax
The format sequence is `{#|Text|#}`
- `Text`: Formatted Text
- `#`: Formatting
	|	`#`	|	Format					|
	|------:|:--------------------------|
	|	`=`	|	**Bold**				|
	|	`*`	|	*Italic*				|
	|	`.`	|	`Monospace`				|
	|	`_`	|	<ins>Underline</ins>	|
	|	`-`	|	~~Strikethrough~~		|
The escape sequence is `{{#|Text|#}}` and renders as {#|Text|#}.
> [!NOTE]
> For now, nesting will be used, but eventually complex tag support will be implemented and is to be used instead
>> Nesting: `{=|{*|Bold+italic|*}|=}`
>
>> Complex:
>> 1. `{#|Text|#}`
>> 2. `{# #|Text|# #}`
>> 3. `{# # #|Text|# # #}`
>> 4. `{# # # #|Text|# # # #}`
>> 5. `{# # # # #|Text|# # # # #}`

> [!NOTE]
> Complex symbol logic is currently being developed, but, as of now, only supports 2 symbols in a single tag
>> `{# #|Text|# #}`
