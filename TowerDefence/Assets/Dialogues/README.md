## Ink Dialogues
[Ink documentation](https://github.com/inkle/inky/blob/0.14.1/app/resources/Documentation/WritingWithInk.md) |
[Ink API documentation](../Ink/Documentation/API%20Documentation.pdf) |
[Unity html tags](https://docs.unity3d.com/Packages/com.unity.ugui@1.0/manual/StyledText.html) |

For writing dialogues I recommend using [Inky](https://github.com/inkle/inky/releases/tag/0.14.1)
![screenshot.gif](..%2F..%2F..%2F_DocsResources%2Fscreenshot.gif)

### Ink Syntax
Ink is a scripting language for writing interactive narrative. Here is a quick overview of basic keywords:

|     Aspect     |                  Syntax                   |              Example               |
|:--------------:|:-----------------------------------------:|:----------------------------------:|
|     import     |         `INCLUDE <path to file>`          |       `INCLUDE GLOBALS.ink`        |
|      knot      |            `=== knot_name ===`            |       `=== make_enemies ===`       |
|      tag       |   `#tagName callName param1 param2 ...`   | `#function HatePlayer:Lady Madlen` |
|      line      |  `Character: <line finished with enter>`  |      `Player: Your mother.\n`      |
| onetime choice |             `* [Choice name]`             |            `[Be rude]`             |
| sticky choice  |             `+ [Choice name]`             |            `[Go away]`             |
|     gather     | `- Character: <Line finished with enter>` |                                    |
|  basic branch  |             `-> <knot_name>`              |              `-> END`              |

- all NPC should begin with `INCLUDE` `GLOBALS.ink` and proper `<LocationName.ink>` file
- tags should fit [TagParser.cs](../Code/Dialogue/Helpers/TagParser.cs)
- tags are separated by ';' (TODO: maybe should be by '\n')
- enter key is used to change the speaker.

### conventions
- `knots` - snake_case
- `stitches` - snake_case
- `function` - snake_case
- `label` - snake_case
- `CONST` - UPPER_CASE
- `VAR` - PascalCase *
- `LIST` - PascalCase
- `LIST element` - snake_case

_(*) dot is replaced by '\_', ex. `VAR LadyMadlen_Trust`_

### Remarks
- function related tags may be replaced by ink functions
- Dialogues can be tested in Unity Editor or in Inky IDE
- html tags must wraps separate words (ex. `call me <b>Old</b> <b>Ben</b>`)

