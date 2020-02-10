# The_Shop

This is a simple shop with all the basic functionalities mentioned in task.
Run the program by running The_Shop/bin/Debug/The_Shop.exe file.

Note: Program is implemented using C#. MySql is used as a database management system.
You should have at least .Net framework 4.5.2 installed on your computer to run the program.

1) Administrator panel (Add, Edit, Remove shop items, Add workers)
Admin credentials: login - admin@mail.ru , pass - admin

Note: As an addition to mentioned functionalities in the task, admin is also able to
* Remove worker.
* Add, edit and delete product in warehouse. Edition is implemented only for product quantity.
* Access to accounting form and follow the trading process.

2) Shop (View items, My Bag)
Customer credentials: You can register to sign in and shop ;)
Every customer has 1000$ amount in his/her wallet initially. This is done for proper testing of buying process.

Customer adds the product to shopping basket by clicking on it's icon.
Then he/she can click on basket icon and see added products, prices per product, summary price, and available money in wallet.
Program also allows customer to remove product(s) from basket and summary price is being updated regarding to it.
After buying products, their quantities in shop and money in wallet are being updated.

3) Accounting (Income, Stock)
Worker and Admin are able to access accounting form and see
* Available products in warehouse and their quantities.
* Summary amount of saled products and earned money.

Note: Worker is also able to add/edit a product to shop from wirehouse and set product amount and price.
Worker can't buy a product.
