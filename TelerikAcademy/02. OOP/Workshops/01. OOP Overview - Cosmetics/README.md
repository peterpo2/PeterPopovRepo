# OOP Workshop - Cosmetics shop 1

### Preface

Before you start coding, read this document from top to bottom. It has some valuable information that will make your work way easier.

### 1. Description
You are given a software system that is used to manage a cosmetics shop. The shop already has a working Engine. You do not have to touch anything in it. Just use it.

Each product has **name, brand, price and gender**.

There are **categories** of products. Each **category** has **name** and products can be **added or removed**. The same product can be added to a category more than once. 

There is also a **shopping cart**. Products can be **added or removed** from it. The same product can be added to the shopping cart more than once. The shopping cart can calculate the **total price** of all products in it.
- Your **task** is to **finish the implementation** of the classes to model the cosmetics shop.
- The **NotImplementedExceptions** should give you an idea where to write code.

### 2. The `Category` class
- Minimum category name’s length is 2 symbols and maximum is 15 symbols.
- Adding the same product to one category more than once is allowed.
- When removing product from category, if the product is not found you should throw an exception.
- Category’s `Print()` should return text in the following format:

```
#Category: {category name}
 #{Name} {Brand}
 #Price: {price}
 #Gender: {genderType}
 ===
 #{Name} {Brand}
 #Price: {price}
 #Gender: {genderType}
 ===
```

```
#Category: {category name}
 #No products in this category
```

### 3. The `Product` class
- Minimum product name’s length is 3 symbols and maximum is 10 symbols.
- Minimum brand name’s length is 2 symbols and maximum is 10 symbols.
- Price cannot be negative.
- Gender type can be **"Men"**, **"Women"** or **"Unisex"**.
- Print returns text in the following format: _(you might consider reusing this in the category print.)_
```
#{Name} {Brand}
#Price: {Price}
#Gender: {GenderType}
```

### 4. The `Shopping cart` class
- Adding the same product more than once is allowed.
- When removing a product from the shopping cart throw an exception if it is not in it.

> **Constraint 1** - If a null value is passed to some mandatory property, your program should throw a proper exception. 

### Input example

```
CreateProduct MyMan Nivea 10.99 Men
CreateCategory Shampoos
AddToCategory Shampoos MyMan
AddToShoppingCart MyMan
ShowCategory Shampoos 
TotalPrice
RemoveFromCategory Shampoos MyMan
ShowCategory Shampoos
RemoveFromShoppingCart MyMan
TotalPrice
```

### Output Example

```
Product with name MyMan was created!
Category with name Shampoos was created!
Product MyMan added to category Shampoos!
Product MyMan was added to the shopping cart!
#Category: Shampoos
 #MyMan Nivea
 #Price: $10.99
 #Gender: Men
 ===
$10.99 total price currently in the shopping cart!
Product MyMan removed from category Shampoos!
#Category: Shampoos
 #No products in this category
Product MyMan was removed from the shopping cart!
No products in shopping cart!
```

### Unit Tests

- You have been given unit tests to keep track your progress.
- Should you get stuck, check out the tests' names to guide you what you should do. For now, the names of the test methods are enough to point you to what may be wrong.
- You can run all tests with the **Test Explorer**. Open it from `View -> Test Explorer` and when open, click the green button `Run All Tests In View`. You can also run a single test - open the test file, double-click on the `[TestMethod]` and select `Run tests`.

## Step by step guide

> **Hint**: You don't need to take care of the Engine class and the Main method but of course you could try to understand how they work.

1. Start with the `Product` class
   - Apply the Encapsulation principle to all the fields (make sure all fields are private, implement the properties).

2. Finish the `ShoppingCart` class
    - Initialize the `products` collection (encapsulate it, don't allow direct access to it).

    ```csharp
    public ShoppingCart()
    {
        this.products = new List<Product>();
    }
    ```

    - Implement the methods.

3. Finish the `Category` class
   - Initialize the `products` collection.
   - Implement the methods (you may leave the Print method for later).

4. Navigate to the `Repository` class

    - Implement the `Find` methods - they should go through the respective collections and return the item that has the given name. What should happen if there is no item with that name? Maybe throw an exception?
    - Implement the `Create` methods - they accept the needed arguments to create a category or a product.
    - Implement the `Exists` methods - they go through the respective collections and return `true` if there is an item that has the given name.

5. Implement `Print()` methods in both the `Category` and `Product` classes.

   - To test the `Print()` method you need to run the application, pass the sample input and check the output.


>You are given a template of the Cosmetics shop. Please take a look at it carefully before you try to do anything. Try to understand all the classes and how they are supposed to interact with each other.
