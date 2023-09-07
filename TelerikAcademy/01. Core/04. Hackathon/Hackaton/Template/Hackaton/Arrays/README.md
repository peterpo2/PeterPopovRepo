# Array methods

### Table of Contents
- [`AddFirst(int[], int)`](#addfirstint-int)
- [`AddLast(int[], int)`](#addlastint-int)
- [`AppendAll(int[], int[])`](#appendallint-int)
- [`Contains(int[], int)`](#containsint-int)
- [`Copy(int[], int[] int)`](#copyint-int-int)
- [`CopyFrom(int[], int, int[], int, int)`](#copyfromint-int-int-int-int)
- [`Fill(int[], int)`](#fillint-int)
- [`FirstIndexOf(int[], int)`](#firstindexofint-int)
- [`InsertAt(int[], int, int)`](#insertatint-int-int)
- [`IsValidIndex(int[], int)`](#isvalidindexint-int)
- [`LastIndexOf(int[], int)`](#lastindexofint-int)
- [`RemoveAllOccurrences(int[], int)`](#removealloccurrencesint-int)
- [`Reverse(int[])`](#reverseint)
- [`Section(int[], int, int)`](#sectionint-int-int)

---

## `AddFirst(int[], int)`

```cs
AddFirst(int[] source, int element);
```

### Description

*Adds `element` at the start of `source`*

### Parameters

**`source`** int[] - *The array to add to*

**`element`** int - *The element to add*

### Returns

`int[]` - *A new array, the original array with `element` at head position*

#### Example

```cs
var array = new int[] { 1, 2, 3 };
AddFirst(array, 4);
```
Result
```
{ 4, 1, 2, 3 }
```

***

## `AddLast(int[], int)`

```cs
AddLast(int[] source, int element);
```

### Description

*Adds `element` to the end of `source`.*

### Parameters

**`source`** int[] - *The array to add to*

**`element`** int - *The element to add*

### Returns

`int[]` - *A new array, the original array with `element` at the end*

#### Example

```cs
AddLast(new int[] { 1, 2, 3}, 4);
```
Result
```
{ 1, 2, 3, 4 }
```

***

## `AppendAll(int[], int[])`

```cs
AppendAll(int[] source, int[] elements);
```

### Description

*Adds all `elements` to the end of `source`.*

### Parameters

**`source`** int[] - *The array to add to*

**`elements`** int[] - *The array of elements to add*

### Returns

`int[]` - *A new array, the original array with all `elements` at the end*

#### Example

```cs
AppendAll(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 });
```
Result
```
{ 1, 2, 3, 4, 5, 6 }
```

***

## `Contains(int[], int)`

```cs
Contains(int[] source, int element);
```

### Description

*Checks if `source` contains `element`*

### Parameters

**`source`** int[] - *The array to check in*

**`element`** int - *The elements to check for*

### Returns

`bool` - *`true` if `source` contains `element`, otherwise, `false`*

#### Example

```cs
Contains(new int[] { 1, 2, 3}, 2);
```
Result
```
True
```

***

## `copy(int[], int[] int)`

```cs
Copy(int[] source, int[] destinationArray, int element);
```

### Description

*Copies `count` elements from `sourceArray` into `destinationArray`*

### Parameters

**`source`** int[] - *The array to copy from*

**`destinationArray`** int[] - *The array to copy to*

**`count`** int - *The number of elements to copy*

### Returns

`void`

#### Example

```cs
var source = new int[] { 1, 2, 3}; // { 1, 2, 3 }
var destination = new int[2]; // { 0, 0 }
Copy(source, destination, 2);
```
Result
```
destination is now { 1, 2 }
```

***

## `CopyFrom(int[], int, int[], int, int)`

```cs
CopyFrom(int[] sourceArray, int sourceStartIndex, int[] destinationArray, int destStartIndex, int count);
```

### Description

*Copies elements from `sourceArray`, starting from `sourceStartIndex` into `destinationArray`, starting from `destStartIndex`, taking `count` elements.*

### Parameters

**`sourceArray`** int[] - *The array to copy from*

**`sourceStartIndex`** int[] - *The starting index in sourceArray*

**`destinationArray`** int[] - *The array to copy to*

**`destStartIndex`** int[] - *The starting index in destinationArray*

**`count`** int - *The number of elements to copy*

### Returns

`void`

#### Example

```cs
int[] array = {1, 2, 3, 4, 5};
sourceStartIndex = 0;
int[] destinationArray = new int[4];
destStartIndex = 1;
count = 2;

CopyFrom(array, sourceStartIndex, destinationArray, destStartIndex, count);
```
Result
```
destinationArray is now { 0, 1, 2, 0 }
```

***

## `Fill(int[], int)`

```cs
Fill(int[] source, int element);
```

### Description

*Fills `source` with `element`.*

### Parameters

**`source`** int[] - *The array to fill*

**`element`** int - *The element to fill with*

### Returns

`void`

#### Example

```cs
var source = new int[3];
int filler = 1;

Fill(source, filler);
```
Result
```
source is now { 1, 1, 1 }
```

***

## `FirstIndexOf(int[], int)`

```cs
FirstIndexOf(int[] source, int target);
```

### Description

*Finds the first index of `target` within `source`.*

### Parameters

**`source`** int[] - *The array to check in*

**`target`** int - *The element to check for*

### Returns

`int` - The first index of `target` within `source`, otherwise, -1

#### Example

```cs
var source = new int[] { 1, 2, 2, 3 };
int target = 2;
FirstIndexOf(source, target);
```
Result
```
1
```

***

## `InsertAt(int[], int, int)`

```cs
Insert(int[] source, int index, int element);
```

### Description

*Inserts `element` at index `index` in `source`.*

### Parameters

**`source`** int[] - *The array to insert in*

**`index`** int - *The index to insert at*

**`element`** int - *The element to insert*

### Returns

`int[]` - *A new array with `element` in it*

#### Example

```cs
var source = new int[] { 1, 2, 4, 5 };
int index = 2;
int element = 3;

InsertAt(source, index, element);
```
Result
```
{ 1, 2, 3, 4, 5 }
```

***

## `IsValidIndex(int[], int)`

```cs
isValidIndex(int[] source, int index);
```

### Description

*Checks if `index` is a valid index in `source`.*

### Parameters

**`source`** int[] - *The array to check against*

**`index`** int - *The index to check for*

### Returns

`bool` - *`true` if `index` is valid, otherwise, `false`*

#### Example

```cs
IsValidIndex(new int[] { 1, 2 }, 2);
```
Result
```
False
```

***

## `LastIndexOf(int[], int)`

```cs
LastIndexOf(int[] source, int target);
```

### Description

*Finds the last index of `target` within `source`*

### Parameters

**`source`** int[] - *The array to check in*

**`target`** int - *The element to check for*

### Returns

`int` - *The last index of `target` within `source`, otherwise, -1*

#### Example

```cs
LastIndexOf(new int[] { 1, 2, 3, 4, 2 }, 2);
```
Result
```
4
```

***

## `RemoveAllOccurrences(int[], int)`

```cs
RemoveAllOccurrences(int[] source, int element);
```

### Description

*Removes all occurrences of `element` within `source`*

### Parameters

**`source`** int[] - *The array to remove from*

**`target`** int - *The element to check for*

### Returns

`int[]` - *A new array with all occurences of `element` removed*

#### Example

```cs
RemoveAllOccurrences(new int[] { 1, 2, 3, 4, 2 }, 2);
```
Result
```
{ 1, 3, 4 }
```

***

## `Reverse(int[])`

```cs
Reverse(int[] arrayToReverse);
```

### Description

*Reverses `arrayToReverse`*

### Parameters

**`arrayToReverse`** int[] - *The array to reverse*

### Returns

`void`

#### Example

```cs
Reverse(new int[] { 1, 2, 3, 4, 2})
```
Result
```
arrayToReverse is now { 2, 4, 3, 2, 1 }
```

***

## `Section(int[], int, int)`

```cs
Section(int[] source, int startIndex, int endIndex);
```

### Description

*Returns a new array, from `source`, starting from `startIndex` and until `endIndex`*

### Parameters

**`source`** int[] - *The array to create the new array from*

**`startIndex`** int - *The starting index*

**`endIndex`** int - *The end index*

### Returns

`int[]` - *A new array starting from `startIndex` and until `endIndex`*

#### Example

```cs
Section(new int[] { 1, 2, 3, 4, 2 }, 0, 3)
```
Result
```
{ 1, 2, 3, 4 }
```

***
