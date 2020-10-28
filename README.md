# AtosLibrary

## About this project
AtosLibrary was created as a part of the *Atos Lab* course that took place in 2020. The course focused mainly on practicing how to write clean code in .NET CORE (C#). It also touched on many other topics, such as SOLID principles, CQRS, unit testing, data validation, databases and Git basics.

After every lecture, students were asked to add features mentioned before to their version of the website. Each student had a mentor, who supervised their progress and provided help or advice when needed.

## What is AtosLibrary?
AtosLibrary is a basic website dedicated for library workers. It allows the user to manage Readers, Books and all their Rentals. 
To rent a book to someone, the worker will type in the initials of the person, as well as the book title. A new request will be created, that requires some action. The librarian will then have to go through the process of preparing the book and actually renting it to the person. After a book is returned, the librarian marks it as such. Both the start and end date of the rental are logged.

## User journey
This is how the simplified process of renting a book looks like:
1. Click on *'Reserve a book'* button.
2. Type in Reader Name & Surname, as well as the Book Name. Confirm by clicking *'Create'*.
3. Go to *Management > Reservations* and find the reservation.
4. Click *'Prepare book'*. Ideally, this is when the librarian would go to take the book from a shelf.
5. Click *'Book Ready'* to change the reservation's status from *'In preparation'* to *'Ready'*.
6. After the person shows up in the library, click 'Rent book' and give them the book. The record will move from *Reservations* to *Management > Active Rentals*.
7. After the person returns the book, go to *Management > Active rentals*.
8. Find the right rental and click 'Return book'. The book will be returned and the rental logged.

## Technologies used
- .NET Core 3.1 (C#)
- HTML
- CSS (Bulma framework)
- JavaScript
- SQL

## What did I learn?
This project posed many interesting challenges. I learned the importance of writing clean code and correct architecture. Seeing the results was very encouraging and I often found myself doing more than what the course required. Because of that, I managed to learn not only about the backend, but also a bit about the frontend. Because of using a CSS framework, I was also able to practice working with documentation. Applying different CSS styles was definitely satisfying! 

This project is not perfect and could still be improved, which is why I'm going to keep working hard to learn what is necessary to make it better! :) 
