-- Create a view named Popular Books that lists books with the highest number of loans.
create view popular_books as
select books.title, count(*) nb_loans
from books inner join loans on books.book_id = loans.book_id
group by books.book_id
order by nb_loans desc;

-- use the view
select * from popular_books;

