# API Design - Create an API

In this activity you will get to know Postman better by writing some requests. Before starting, or should you get stuck, you can go over the [documentation](https://www.mockapi.io/docs) of the site we will be using.

## 1. Register

Go to [mockAPI.io](https://www.mockapi.io/) and register.

## 2. Create a new project

Create a new project and give it a name.

![create a new project](images/01.%20create%20a%20new%20project.jpg)

![new project](images/02.%20new%20project.jpg)

## 3. Create a new resource

Click on `New Resource` and give it a name (remember the REST guidelines, it must be plural).

![users resource](images/04.%20users%20resource.jpg)

Down here you can define how your resources will look. Besides the ID, which every resource has, you can add your own fields as well. Add a few like `first_name`, `last_name`, `email`, etc. (don't go overboard). In the first column you need to enter the name of the field, then in the second its type. The type can be a `String`, a `Number` and so on. It can also be `Faker.js`.

![resource schema](images/05.%20new%20resource%20schema.jpg)

If you pick `Faker.js` for the type a third column appears where you can pick a randomly generated field like a random name or email. Try it.

![random field](images/06.%20random%20fields.jpg)

Scroll down and you will see all the available endpoints.

![endpoints](images/07.%20endpoints.jpg)

After you are done with the users click ***Create*** at the bottom. To fill with actual data, click here:

![fill with data](images/08.%20fill%20with%20data.gif)

## 4. Test it out

So far so good. Now open Postman and try to query your data. The API's URL can be found here:

![api url](images/09.%20api%20url.jpg)

Go to Postman and execute a `GET` at `https://{{you-api}}.mockapi.io/users`. If all went well you should get some randomly generated users back.

## 5. Add addresses

Let's add another resource - an addresses.

![add addresses](images/10.%20add%20address.jpg)

## 6. Link users to addresses

Link the `users` and `addresses` resource like so:

![link resources](images/12.%20link%20resources.gif)

Now edit the `users` schema. Add another field, give it a name and pick `Child Resource` for the type and `addresses` for the schema. Now users have addresses!

![child resources](images/11.%20child%20resource.gif)

## 7. Tasks checklist

Great. Now let's execute some requests.

1. [ ] Query all users
1. [ ] Create a new users with `first_name` = John and `last_name` = Doe
1. [ ] Query all users whose first or last name is John
1. [ ] Create a new user with address
1. [ ] Modify an existing user
1. [ ] Delete an existing user
1. [ ] Query all users sorted by `first_name`
1. [ ] Query all users sorted by `first_name`, descending
1. [ ] Query only 5 users
1. [ ] Query only 5 users, starting at page 3
1. [ ] Query only 5 users, starting at page 3, sorted by `last_name`
