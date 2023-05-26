# string methods

### Table of Contents

- [`Abbreviate(string, int)`](#abbreviatestring-int)
- [`Capitalize(string)`](#capitalizestring)
- [`Concat(string, string)`](#concatstring-string)
- [`Contains(string, char)`](#containsstring-char)
- [`EndsWith(string, char)`](#endswithstring-char)
- [`FirstIndexOf(string, char)`](#firstindexofstring-char)
- [`LastIndexOf(string, char)`](#lastindexofstring-char)
- [`Pad(string, int, char)`](#padstring-int-char)
- [`PadEnd(string, int, char)`](#padendstring-int-char)
- [`PadStart(string, int, char)`](#padstartstring-int-char)
- [`Repeat(string, int)`](#repeatstring-int)
- [`Reverse(string)`](#reversestring)
- [`Section(string, int, int)`](#sectionstring-int-int)
- [`StartsWith(string, char)`](#startswithstring-char)

---

## `Abbreviate(string, int)`

```cs
Abbreviate(string source, int maxLength);
```

### Description

_Abbreviates a string using ellipses._

### Parameters

**`source`** string - _The string to modify_

**`maxLength`** int - _Maximum length of the resulting string_

### Returns

`string` - _The abbreviated string_

#### Example

```cs
Abbreviate("Telerik Academy", 13)

//returns: Telerik Acade...
```

---

## `Capitalize(string)`

```cs
Capitalize(string source);
```

### Description

_Capitalizes a string changing the first character to title case. No other characters are changed. If source is empty returns empty string._

### Parameters

**`source`** string - _The string to modify_

### Returns

`string` - _The capitalized string or empty string if `source` is empty_

#### Example

```cs
Capitalize("academy")

//returns: Academy
```

---

## `Concat(string, string)`

```cs
Concat(string string1, string string2);
```

### Description

_Concatenates `string1` to the end of `string2`._

### Parameters

**`string1`** string - _The left part of the new string_

**`string2`** string - _The right part of the new string_

### Returns

`string` - _A string that represents the concatenation of string1 followed by string2's characters_

#### Example

```cs
Concat("Visual", "Studio")

//returns: VisualStudio
```

---

## `Contains(string, char)`

```cs
Contains(string source, char symbol);
```

### Description

_Checks if `source` contains a `symbol`._

### Parameters

**`source`** string - _The string to check_

**`symbol`** char - _The character to check for_

### Returns

`bool` - _`true` if `symbol` is within `source` or `false` if not_

#### Example

```cs
Contains("Academy", 'd')

//returns: true
```

---

## `StartsWith(string, char)`

```cs
StartsWith(string source, char target);
```

### Description

_Checks if the string `source` starts with the given character._

### Parameters

**`source`** string - _The string to inspect_

**`target`** char - _The character to search for_

### Returns

`bool` - _`true` if string starts with target, otherwise `false`_

#### Example

```cs
StartsWith("Academy", 'A');
//returns: true

StartsWith("Academy", 'a');
//returns: false
```

---

## `EndsWith(string, char)`

```cs
EndsWith(string source, char target);
```

### Description

_Checks if the string `source` ends with the given character._

### Parameters

**`source`** string - _The string to check_

**`target`** char - _The character to check for_

### Returns

`bool` - _`true` if the string ends with `target`, else `false`_

#### Example

```cs
EndsWith("Telerik", 'k')

//returns: true
```

---

## `FirstIndexOf(string, char)`

```cs
FirstIndexOf(string source, char target);
```

### Description

_Finds the first index of `target` within `source`._

### Parameters

**`source`** string - _The string to check_

**`target`** char - _The character to check for_

### Returns

`int` - _The first index of `target` within `source`, otherwise, -1_

#### Example

```cs
FirstIndexOf("Telerik Academy", 'e')

//returns: 1
```

---

## `LastIndexOf(string, char)`

```cs
LastIndexOf(string source, char target);
```

### Description

_Finds the last index of `target` within `source`._

### Parameters

**`source`** string - _The string to check_

**`target`** char - _The character to check for_

### Returns

`int` - _The last index `symbol` within `source` or -1 if no match_

#### Example

```cs
LastIndexOf("Telerik Academy", 'e')

//returns: 12
```

---

## `Pad(string, int, char)`

```cs
Pad(string source, int length, char paddingSymbol);
```

### Description

_Pads string on the left and right sides if it's shorter than length._

### Parameters

**`source`** string - _The string to pad_

**`length`** int - _The length of the string to achieve_

**`target`** char - _The character used as padding_

### Returns

`string`
_The padded string_

#### Example

```cs
Pad("C#", 8, '*');

//returns: ***C#***
```

---

## `PadEnd(string, int, char)`

```cs
PadEnd(string source, int length, char paddingSymbol);
```

### Description

_Pads `source` on the right side with `PaddingSymbol` enough times to reach length `length`._

### Parameters

**`source`** string - _The string to pad_

**`length`** int - _The length of the string to achieve_

**`target`** char - _The character used as padding_

### Returns

`string` - _The padded string_

#### Example

```cs
PadEnd("C#", 6, '*');

//returns: C#****
```

---

## `PadStart(string, int, char)`

```cs
PadStart(string source, int length, char paddingSymbol);
```

### Description

_Pads `source` on the left side with `PaddingSymbol` enough times to reach length `length`._

### Parameters

**`source`** string - _The string to pad_

**`length`** int - _The length of the string to achieve_

**`target`** char - _The character used as padding_

### Returns

`string` - _The padded string_

#### Example

```cs
PadStart("C#", 6, '*');

//returns: ****C#
```

---

## `Repeat(string, int)`

```cs
Repeat(string source, int times);
```

### Description

_Repeats the given string `times` times._

### Parameters

**`source`** string - _The string to repeat_

**`times`** int - _The number of times to repeat the string_

### Returns

`string` - _The repeated string_

#### Example

```cs
Repeat("C#", 3);

//returns: C#C#C#
```

---

## `Reverse(string)`

```cs
Reverse(string source);
```

### Description

_Reverses `source` so that the first element becomes the last, the second element becomes the second to last, and so on._

### Parameters

**`source`** string - _The string to reverse_

### Returns

`string` - _The reversed string_

#### Example

```cs
Reverse("C#");

//returns: #C
```

---

## `Section(string, int, int)`

```cs
Section(string source, int start, int end);
```

### Description

_Returns a new string, starting from `start` and ending at `end`._

### Parameters

**`source`** string - _The string to extract a section from_

**`start`** int - _The starting position in `source` (inclusive)_

**`end`** int - _The end position in `source` (inclusive)_

### Returns

`string` - _A new string, formed by the characters in `source`, starting from `start` to `end`_

#### Example

```cs
Section("**Telerik Academy**", 2, 16);

//returns: Telerik Academy
```

---
