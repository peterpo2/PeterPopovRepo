## Database Design - Create a database model for a car rental system

You might have rented a car on your last vacation. You reserved your car online, and then picked it up from its designated location after paying all the previously-agreed charges. Once you were done, you returned it to the agency and perhaps paid some additional fees. 

Did you ever think about the system that makes all these things happen?

### **Description of the system**

A car rental company rents cars to customers. The company owns several cars. Each car has a brand, model name, production year, mileage color, and so on. Cars are divided into different categories: small, mid-size, large, limousines.

The company has many locations where you can rent a car. The rental locations are located in different cities throughout the country. There can be more than one company location in a city.
Anyone over 21 who has a valid driver’s license can rent a car.

Customers under 25 or over 75 years pay different (higher) charges then other customers.

Before renting a car, a customer usually makes a reservation for a car. A customer specifies the dates when the car will be rented, the pick-up location, the drop-off location, and the category of car he wants to rent. 

When a customer rents a car, he declares the pick-up and drop-off location, and the drop-off date. The customer can buy various types of insurance. He can also decide that he doesn’t need insurance because the insurance is covered otherwise, for example by his credit card company. The customer can choose additional options such as the possibility of an early drop-off, various refueling options, etc.

The customer pays the charges when he returns the car.

### **Start With a System Description**

You should always start creating a database model with a description of a system.

Take a look at the description and highlight all nouns. The nouns in the description can roughly be divided into three categories: tables, attributes, and examples.

- Tables represent primary entities in the system: people, physical objects, events, transactions, etc.
  
- Attributes are properties associated with a primary entity. They describe features of your entity. In the database model they will be the columns in your tables.
  
- Examples are just that, examples. They help you understand the data types of certain attributes and they help you understand the relationship between different entities.

### **Tables, Relationships, Columns**

- Once your nouns are highlighted, identify the tables. You don’t have to model everything at once. Focus on the core functionality of the system first.

- When you have the tables, figure out the relationships between the tables. This step might lead to introducing new intermediate (junction) tables.

- Finally add the columns to the tables.
  
At this point, you should read the description again and see if anything is missing. There will be something to add. Add the new tables, the new relationships, and the new columns. Read the description again...

### **Important Notes**

Creating a database model is an iterative process. Don’t try to model everything at once. Start with the core entities of your system. You can add more details later.

It is OK to ask questions. No matter how precise the description is, you will always have some doubts. Something will always be unspecified. Ask questions about the things you’re not sure about. If you can’t ask questions, make a reasonable assumption and note down the assumption you make.

There is always more than one way to model each system. Some models are clearly bad, but with most others it’s difficult to judge if they are right or wrong. As you gain experience, you’ll get more confident about your design decisions.