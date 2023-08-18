## Ink Dialogues
[Ink documentation](https://github.com/inkle/inky/blob/0.14.1/app/resources/Documentation/WritingWithInk.md) |
[Ink API documentation](../Ink/Documentation/API%20Documentation.pdf)


For writing dialogues I recommend using [Inky](https://github.com/inkle/inky/releases/tag/0.14.1)
![screenshot.gif](..%2F..%2F..%2F_DocsResources%2Fscreenshot.gif)

### Ink Syntax
Ink is a scripting language for writing interactive narrative. Only selected features are used in this project:

|     Aspect     |                 Syntax                  |              Example               |
|:--------------:|:---------------------------------------:|:----------------------------------:|
|     import     |        `INCLUDE <path to file>`         |       `INCLUDE someFile.ink`       |
|      knot      |           `=== knotName ===`            |       `=== MakeEnemies ===`        |
|      tag       |  `#tagName callName param1 param2 ...`  | `#function HatePlayer:Lady Madlen` |
|      line      | `Character: <line finished with enter>` |      `Player: Your mother.\n`      |
| onetime choice |            `* [Choice name]`            |            `[Be Rude]`             |
| sticky choice  |            `+ [Choice name]`            |            `[Go Away]`             |
|  basic branch  |             `-> <knotName>`             |              `-> END`              |

- tags should fit [TagParser.cs](../Code/Dialogue/Helpers/TagParser.cs)
- TODO: conditions


### Remarks
- Dialogues can be tested in Unity Editor or in Inky IDE
- Enter key is used to change the speaker.)
- tags are separated by ';' (TODO: maybe should be by '\n')
- function related tags may be replaced by ink functions

