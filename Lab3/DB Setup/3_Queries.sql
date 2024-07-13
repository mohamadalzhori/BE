-- Retrieve all books published in a specific year.
select *
from books
where published_year = 1997;

-- List all loans that are overdue (books that haven't been returned by their due date).
select *
from loans
where returned = false and return_date < current_date;

-- Find books borrowed by a specific borrower.

select books.book_id, books.title, books.author_id, books.isbn, books.published_year
from books inner join loans on books.book_id = loans.book_id
where borrower_id = 1;

-- Calculate the total number of books in the library.
select count(*) as nb_of_books
from books;